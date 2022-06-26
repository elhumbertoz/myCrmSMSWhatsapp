using Microsoft.AspNetCore.SignalR.Client;
using myCrmSMSWhatsapp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myCrmSMSWhatsapp.Services
{
    class WhatAppChats
    {
        private LoginData LoginData;
        private HubConnection connection;

        private BindingSource bsChats = new BindingSource();
        private BindingList<ChatData> lsChats = new BindingList<ChatData>();

        private int PageSize;

        public EventHandler<ChatData[]> ChatsLoaded;
        public EventHandler<ChatData> ChatUpdated;

        public System.Windows.Forms.BindingSource Chats
        {
            get
            {
                return bsChats;
            }
        }

        public WhatAppChats(LoginData loginData, int pageSize)
        {
            this.LoginData = loginData;
            this.PageSize = pageSize;

            bsChats.DataSource = lsChats;

            _ = PrepareEvents();
            _ = LoadChats();
        }

        private async Task LoadChats()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", LoginData.token);
            try
            {
                var chats = await httpClient.GetFromJsonAsync<ChatData[]>(
                    Global.urlGetContacts +
                    "/?domainId=" + this.LoginData.domainId +
                    "&userId=" + this.LoginData.userId + 
                    "&pageSize=" + this.PageSize.ToString().Trim());

                if (chats != null)
                {
                    foreach (var chat in chats)
                    {
                        lsChats.Add(chat);
                    }
                    
                    bsChats.ResetBindings(true);

                    ChatsLoaded?.Invoke(this, chats);

                    GetAllProfilePicture();
                }
            }
            catch (Exception) { }
        }

        private async Task GetAllProfilePicture()
        {
            foreach (var chat in lsChats)
            {
                await getProfilePicture(chat);
            }
        }

        private async Task getProfilePicture(ChatData chat)
        {
            if (chat.profilePictureUrl == null)
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginData.token);

                var photoProfile = await httpClient.GetFromJsonAsync<PhotoProfileData>(
                        Global.urlgGetContactPhotoProfile +
                        "/?domainId=" + this.LoginData.domainId +
                        "&whatsAppContactId=" + chat.whatsAppContactId);

                if (photoProfile != null && photoProfile.url != null && photoProfile.url != "")
                {
                    chat.profilePictureUrl = photoProfile.url;
                }
            }
        }

        private async Task PrepareEvents()
        {
            // Activando SignalR para recibir actualizaciones
            connection = new HubConnectionBuilder()
                .WithAutomaticReconnect()
                .WithUrl(
                    Global.urlSignalRChats, options =>
                    {
                        options.AccessTokenProvider = () => Task.FromResult(this.LoginData.token);
                    })
                .Build();

            connection.On<ChatData>("ChatsUpdate", async (chatData) =>
            {
                var chat = lsChats.FirstOrDefault(c => c.whatsAppContactId == chatData.whatsAppContactId);
                if (chat != null)
                {
                    if (lsChats.Count > 0 && lsChats[0].whatsAppContactId != chat.whatsAppContactId)
                    {
                        lsChats.Remove(chat);
                        lsChats.Insert(0, chat);
                        ChatUpdated?.Invoke(this, chat);
                    }
                    chat.unreadCount = chatData.unreadCount;
                }
                else
                {
                    lsChats.Insert(0, chatData);
                    ChatUpdated?.Invoke(this, chatData);
                    await getProfilePicture(chatData);
                }
            });

            connection.On<string>("ContactChatSeen", (contactId) =>
            {
                var chat = lsChats.FirstOrDefault(c => c.whatsAppContactId == contactId);
                chat.unreadCount = 0;
            });

            // Inicia la sincronización
            await connection.StartAsync();

            await NotifySignalRUserId();

            // En caso de reconección volvemos a notificar a SignalR el userId
            connection.Reconnected += async (connectionId) =>
            {
                await NotifySignalRUserId();
            };
        }

        private async Task NotifySignalRUserId()
        {
            // Se le notifica a SignalR que usuario
            await connection.InvokeAsync("SetUserIdentity", LoginData.userId);
        }

    }
}
