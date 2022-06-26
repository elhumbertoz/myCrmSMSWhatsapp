using Microsoft.AspNetCore.SignalR.Client;
using myCrmSMSWhatsapp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myCrmSMSWhatsapp.Services
{
    class WhatsAppMessages
    {

        private LoginData LoginData;
        private string ContactId;
        private int PageSize;
        private BindingSource bsMessages = new BindingSource();
        private BindingList<MessageData> lsMessages = new BindingList<MessageData>();
        private HubConnection connection;

        // Eventos
        public event EventHandler<MessageData> MessagesUpdated;
        public event EventHandler<MessageMediaData> MessagesMediaUpdated;
        public event EventHandler<MessageData> AckMessageUpdated;
        public event EventHandler<MessageData[]> MessagesLoaded;

        public WhatsAppMessages(LoginData loginData, string WhatsAppContactId, int pageSize)
        {
            this.LoginData = loginData;
            this.ContactId = WhatsAppContactId;
            this.PageSize = pageSize;

            this.bsMessages.DataSource = lsMessages;

            _ = PrepareEvents();
        }

        public string WhastAppContactId {  get
            {
                return this.ContactId;
            } 
            set
            {
                this.ContactId = value;

                // Actualiza el UserId y el contact de signalR para recibir notificaciones
                _ = NotifySignalRUserId();

                // Carga últimos (pageSize) mensajes del chat seleccionado
                _ = LoadMessages();
            }
        }

        private async Task LoadMessages()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginData.token);
            try
            {
                var messages = await httpClient.GetFromJsonAsync<MessageData[]>(
                    Global.urlGetMessages +
                    "/?domainId=" + this.LoginData.domainId +
                    "&userId=" + this.LoginData.userId +
                    "&whatsAppContactId=" + this.ContactId +
                    "&pageSize=" + this.PageSize.ToString().Trim());

                if (messages != null)
                {
                    lsMessages.Clear();
                    foreach (var msg in messages)
                    {
                        lsMessages.Add(msg);
                        if (msg.hasMedia && msg.type == "image" && msg.media_Thumbnail == null)
                        {
                            // GetMessageMedia(msg.whatsAppMessageUniqueId, false);
                        }
                    }

                    MessagesLoaded.Invoke(this, messages);

                    await MarkMessagesAsSeen();
                }
            }
            catch (Exception) { }
        }

        public async Task MarkMessagesAsSeen()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginData.token);

            // Marca los mensajes como leídos
            await httpClient.GetFromJsonAsync<MessageData[]>(
                Global.urlSendSeen +
                "/?domainId=" + this.LoginData.domainId +
                "&whatsAppContactId=" + this.ContactId);
        }

        private async Task PrepareEvents()
        {
            // Activando SignalR para recibir actualizaciones
            connection = new HubConnectionBuilder()
                .WithAutomaticReconnect()
                .WithUrl(
                    Global.urlSignalRMessages, options =>
                    {
                        options.AccessTokenProvider = () => Task.FromResult(this.LoginData.token);
                    })
                .Build();

            // Evento que recibirá actualizaciones de mensajes nuevos recibidos
            // En este envento se reciben los mensajes enviados y recibidos
            connection.On<MessageData>("MessagesUpdate", (messageData) =>
            {
                // Se almacena en una lista los mensajes recibidos para mostrarlos en el grid
                lsMessages.Add(messageData);
                MessagesUpdated?.Invoke(this, messageData);
                _ = MarkMessagesAsSeen();
            });

            connection.On<MessageMediaData>("MessagesMediaUpdate", (mediaData) =>
            {
                SetMessageMedia(mediaData);
                MessagesMediaUpdated?.Invoke(this, mediaData);
            });

            // Evento que recibirá actualizaciones sobre si el usuario recibió o leyó el mensaje
            connection.On<AckMessageData>("AckMessageUpdate", (ackData) =>
            {
                // Se busca el mensaje por medio del ID UNICO
                // 0 - No enviado
                // 1 - Enviado
                // 2 - Recibido
                // 3 - Leído
                // 4 - Play
                var msg = this.lsMessages.FirstOrDefault(msg => msg.whatsAppMessageUniqueId == ackData.whatsAppMessageUniqueId);
                if (msg != null)
                    msg.ack = ackData.ack;

                AckMessageUpdated?.Invoke(this, msg);
            });

            // Inicia la sincronización
            await connection.StartAsync();

            // Notificamos a SignalR el UserId
            await NotifySignalRUserId();

            // En caso de reconección volvemos a notificar a SignalR el userId
            connection.Reconnected += async (connectionId) =>
            {
                await NotifySignalRUserId();
            };

            await LoadMessages();
        }

        private async Task NotifySignalRUserId()
        {
            // Se le notifica a SignalR que usuario somos y de cual chat queremos recibir notificaciones.
            // Únicamente recibiremos actualizaciones del telefono que está en txtPhone, para recibir
            // mensajes de todos los chats en lugar de usar txtPhone.Text use "AllContacts"
            await connection.InvokeAsync("SetUserIdentity", LoginData.userId, ContactId);
        }

        public System.Windows.Forms.BindingSource Messages { 
            get 
            {
                return bsMessages;
            } 
        }

        /* Para obtener el archivo de un mensaje específico */
        private async void GetMessageMedia(string whatsAppMessageUniqueId, bool onlyThumbnail)
        {
            // Recuperar mensaje de media
            MessageMediaData mediaData = null;
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginData.token);
            try
            {
                mediaData = await httpClient
                    .GetFromJsonAsync<MessageMediaData>(Global.urlGetMessageMedia +
                        "/?whatsAppMessageUniqueId=" + whatsAppMessageUniqueId +
                        "&onlyThumbnail" + onlyThumbnail.ToString());
            }
            catch (Exception error) 
            {
                MessageBox.Show(error.Message);
            }

            if (mediaData != null)
            {
                SetMessageMedia(mediaData);
            }

        }

        /* Permite enviar mensaje */
        public async Task<SendMessageResponse> SendMessage(string Message, string FileName, string MimeType)
        {
            var onlyName = Path.GetFileName(FileName);
            var httpClient = new HttpClient();
            var data = new SendMessageData()
            {
                userId = LoginData.userId,
                whatsAppContactId = this.ContactId,
                message = MimeType.StartsWith("image") ? "" : Message, // El resto de archivos envian mensaje de texto
                caption = MimeType.StartsWith("image") ? Message : "", // Las imágenes pueden usar un caption
                messageBase64 = false,
                media = FileName != "" ? Convert.ToBase64String(File.ReadAllBytes(FileName)) : "",
                fileName = onlyName,
                mimeType = MimeType
            };

            // Se usa la el token en el encabezado para autorizar el envío de mensaje
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginData.token);

            // Usando HTTP POST se llama al API para enviar el mensaje
            var Response = await httpClient.PostAsJsonAsync(Global.urlSendMessage + "/?number=" + Global.PhoneToken, data);

            if (Response.IsSuccessStatusCode)
            {
                var sendMessageResponse = JsonSerializer.Deserialize<SendMessageResponse>(
                    await Response.Content.ReadAsStringAsync());

                return sendMessageResponse;
            }

            return null;
        }

        /* El archivo de Media llega de forma asincrónica 
         * Por eso debe ser insertado dentro del registro que le corresponde
         * La busqueda se hace mediante MediaKey */
        private void SetMessageMedia(MessageMediaData mediaData)
        {
            foreach (var msg in this.lsMessages.Where(m => m.mediaKey == mediaData.mediaKey))
            {
                msg.media_Data = mediaData.data;
                msg.media_FileName = mediaData.fileName;
                msg.media_FileName = mediaData.mimeType;
                msg.media_Thumbnail = mediaData.thumbnail;
            }
        }
    }
}
