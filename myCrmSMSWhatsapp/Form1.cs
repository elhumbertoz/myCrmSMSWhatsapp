using Microsoft.AspNetCore.SignalR.Client;
using myCrmSMSWhatsapp.Models;
using myCrmSMSWhatsapp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace myCrmSMSWhatsapp
{
    public partial class Form1 : Form
    {
        #region LocalVariables

        // Variables locales
        private LoginData LoginData;
        private WhatAppChats ChatsService;
        private WhatsAppMessages MessagesService;
        #endregion

        #region FormAndControlsEvents

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Usuario y contraseña de CRM
            txtUsername.Text = "humberto.zambrano@gigamax.ec";
            txtPassword.Text = "HZ2022ec";

            // Datos iniciales para las pruebas
            txtMessage.Text = "Hola, esta es una prueba.";
            txtFileName.Text = "Images\\SMSWhatsAPP.png";
            txtMimeType.Text = "image/png";
            picFile.Image = Image.FromFile(txtFileName.Text);

            dgvChats.AutoGenerateColumns = false;
            grdMessages.AutoGenerateColumns = false;
        }

        // Iniciar sesión en el CRM
        private void btnLogin_Click(object sender, EventArgs e)
        {
            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
            btnLogin.Enabled = false;
            Login();
        }

        private void btnSearchFile_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Imagen JPG (*.jpg)|*.jpg|Imagen PNG (*.png)|*.png|PDF (*.pdf)|*.pdf";
            dialog.Multiselect = false;
            dialog.ShowDialog();
            if (dialog.FileName != "")
            {
                txtFileName.Text = dialog.FileName.ToLower();
                if (txtFileName.Text.EndsWith("jpg"))
                {
                    txtMimeType.Text = "image/jpeg";
                    picFile.Image = Image.FromFile(txtFileName.Text);
                }

                if (txtFileName.Text.EndsWith("png"))
                {
                    txtMimeType.Text = "image/png";
                    picFile.Image = Image.FromFile(txtFileName.Text);
                }
                if (txtFileName.Text.EndsWith("pdf"))
                {
                    txtMimeType.Text = "application/pdf";
                    picFile.Image = null;
                }
            }

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            _ = MessagesService.SendMessage(txtMessage.Text, txtFileName.Text, txtMimeType.Text);
        }

        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            txtFileName.Text = "";
            txtMimeType.Text = "";
            picFile.Image = null;
        }

        private void dgvChats_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var chat = (ChatData)dgvChats.Rows[e.RowIndex].DataBoundItem;
            if (chat != null)
            {
                LoadMessages(chat.whatsAppContactId);
            }
        }

        private void grdMessages_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colImage.Index)
            {
                MessageData msg = (MessageData)grdMessages.Rows[e.RowIndex].DataBoundItem;

                if (msg.hasMedia && msg.media_FileName != "")
                {
                    SaveFileDialog sf = new SaveFileDialog();

                    sf.Title = "Guardar como";
                    sf.FileName = msg.media_FileName;
                    
                    if (msg.type == "image")
                    {
                        try
                        {
                            var ext = msg.media_MimeType.Split("/")[1];
                            sf.FileName = "adjunto." + ext;
                        }
                        catch (Exception) { }
                    }

                    if (sf.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            using (var client = new WebClient())
                            {
                                client.DownloadFile(Global.urlDownloadDocument + "/?mediaKey=" + HttpUtility.UrlEncode(msg.mediaKey), sf.FileName);
                            }
                            Process p = new Process();
                            p.StartInfo.UseShellExecute = true;
                            p.StartInfo.FileName = sf.FileName;
                            p.Start();
                        }
                        catch (Exception error) 
                        {
                            MessageBox.Show(error.Message);
                        }
                    }
                }
            }
        }
        #endregion

        #region WhatsAppMethods

        // Iniciar sesión en el CRM
        private async void Login()
        {
            var httpClient = new HttpClient();

            // Inicia sesión con los servicios de CRm de SMSWhatsApp
            var Response = await httpClient.PostAsJsonAsync(Global.urlLogin,
                new
                {
                    username = txtUsername.Text,
                    password = txtPassword.Text
                });

            if (Response.IsSuccessStatusCode)
            {
                // Datos recibidos en el inicio de sesión
                LoginData = JsonSerializer.Deserialize<LoginData>( await Response.Content.ReadAsStringAsync() );

                ChatsService = new WhatAppChats(LoginData, 100);
                ChatsService.ChatsLoaded += ChatsLoaded;
                ChatsService.ChatUpdated += ChatUpdated;
            }
        }

        private void LoadMessages(string contactId)
        {
            if (MessagesService == null || MessagesService.WhastAppContactId != contactId)
            {
                grdMessages.DataSource = null;

                if (MessagesService == null)
                {
                    MessagesService = new WhatsAppMessages(LoginData, contactId, 50);
                    MessagesService.MessagesLoaded += MessagesLoaded;
                    MessagesService.MessagesUpdated += MessageUploaded;

                    // Habilita controles para enviar mensajes
                    txtMessage.Enabled = true;
                    btnSearchFile.Enabled = true;
                    btnRemoveFile.Enabled = true;
                    btnSend.Enabled = true;
                }
                else
                {
                    if (contactId != MessagesService.WhastAppContactId)
                        MessagesService.WhastAppContactId = contactId;
                }
            }
        }

        private void EnsureSelected(DataGridView view, int rowToShow)
        {
            view.ClearSelection();
            view.Rows[rowToShow].Selected = true;
            EnsureVisibleRow(view, rowToShow);
        }

        private static void EnsureVisibleRow(DataGridView view, int rowToShow)
        {
            if (rowToShow >= 0 && rowToShow < view.RowCount)
            {
                var countVisible = view.DisplayedRowCount(false);
                var firstVisible = view.FirstDisplayedScrollingRowIndex;
                if (rowToShow < firstVisible)
                {
                    view.FirstDisplayedScrollingRowIndex = rowToShow;
                }
                else if (rowToShow >= firstVisible + countVisible)
                {
                    view.FirstDisplayedScrollingRowIndex = rowToShow - countVisible + 1;
                }
            }
        }
        #endregion

        #region WhatsAppEvents

        // Evento se desencadena cuando se cargan los chats
        private void ChatsLoaded(object sender, ChatData[] chats)
        {
            dgvChats.DataSource = ChatsService.Chats;
            dgvChats.ClearSelection();
        }

        private void ChatUpdated(object sender, ChatData chat)
        {
            foreach (DataGridViewRow row in dgvChats.Rows)
            {
                if (((ChatData)row.DataBoundItem).whatsAppContactId == chat.whatsAppContactId)
                {
                    EnsureSelected(dgvChats, row.Index);
                }
            }
        }
        
        private void MessagesLoaded(object sender, MessageData[] messages)
        {
            grdMessages.DataSource = MessagesService.Messages;
            
            if (grdMessages.RowCount > 1)
            {
                EnsureSelected(grdMessages, grdMessages.Rows.Count - 1);
            }
        }

        private void MessageUploaded(object sender, MessageData message)
        {
            if (grdMessages.Rows.Count > 0)
            {
                EnsureSelected(grdMessages, grdMessages.Rows.Count - 1);
            }
            if (dgvChats.Rows.Count > 0)
            {
                EnsureSelected(dgvChats, 0);
            }
        }

        #endregion

        
    }
}
