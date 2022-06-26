using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myCrmSMSWhatsapp
{
    public partial class Form1 : Form
    {

        // API de SMSWhatsApp para acceder al servicio
        private const string urlLogin = "https://crm-core.gigamax.ec/api/authenticate/login";
        private const string urlSendMessage = "https://crm-core.gigamax.ec/api/whatsapp/messages/sendmessage";
        private const string urlGetMessageMedia = "https://crm-core.gigamax.ec/api/whatsapp/messages/getmessagemedia";

        // SignalR sirve para establecer conecciones en tiempo real, se usa para recibir los mensajes
        private const string urlSignalRMessages = "https://crm-core.gigamax.ec/hubs/whatsapp/messages";

        // Token de SMSWhatsApp (number)
        private const string PhoneToken = "ttbfbEwndBBabZQ8VniS";

        // Variables locales
        private LoginData loginData;
        private HubConnection connection;
        private List<MessageData> messages = new List<MessageData>();

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
            txtPhone.Text = "593969626740";
            txtMessage.Text = "Hola, esta es una prueba.";
            txtFileName.Text = "C:\\Users\\elhum\\OneDrive\\Imágenes\\SMSWhatSApp.png";
            txtMimeType.Text = "image/png";
            picFile.Image = Image.FromFile(txtFileName.Text);

            // Binding source para mostrar en el grid los mensajes
            bsMessages.DataSource = messages;
            grdMessages.AutoGenerateColumns = false;
            grdMessages.DataSource = bsMessages;
        }

        // Iniciar sesión en el CRM
        private void btnLogin_Click(object sender, EventArgs e)
        {
            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
            btnLogin.Enabled = false;
            Login();
        }

        // Iniciar sesión en el CRM
        private async void Login()
        {
            var httpClient = new HttpClient();

            // Inicia sesión con los servicios de CRm de SMSWhatsApp
            var Response = await httpClient.PostAsJsonAsync(urlLogin,
                new
                {
                    username = txtUsername.Text,
                    password = txtPassword.Text
                });

            if (Response.IsSuccessStatusCode)
            {
                // Datos recibidos en el inicio de sesión
                loginData = JsonSerializer.Deserialize<LoginData>( await Response.Content.ReadAsStringAsync() );

                // Habilita controles para enviar mensajes
                txtPhone.Enabled = true;
                txtMessage.Enabled = true;
                btnSend.Enabled = true;
                
                // Activando SignalR para recibir actualizaciones
                connection = new HubConnectionBuilder()
                    .WithAutomaticReconnect()
                    .WithUrl(
                        urlSignalRMessages, options =>
                        {
                            options.AccessTokenProvider = () => Task.FromResult(this.loginData.token);
                        })
                    .Build();

                // Evento que recibirá actualizaciones de mensajes nuevos recibidos
                // En este envento se reciben los mensajes enviados y recibidos
                connection.On<MessageData>("MessagesUpdate", (messageData) =>
                {
                    // Se almacena en una lista los mensajes recibidos para mostrarlos en el grid
                    this.bsMessages.Add(messageData);
                });

                connection.On<MessageMediaData>("MessagesMediaUpdate", (mediaData) =>
                {
                    SetMessageMedia(mediaData);
                });

                // Evento que recibirá actualizaciones sobre si el usuario recibió o leyó el mensaje
                connection.On<AckMessageData>("AckMessageUpdate", (ackData) =>
                {
                    // Se busca el mensaje por medio del ID UNICO
                    // 1 - Enviado
                    // 2 - Recibido
                    // 3 - Leído
                    // 4 - Play
                    var msg = this.messages.FirstOrDefault(msg => msg.whatsAppMessageUniqueId == ackData.whatsAppMessageUniqueId);
                    if (msg != null)
                        msg.ack = ackData.ack;

                    this.grdMessages.Refresh();
                });

                // Inicia la sincronización
                await connection.StartAsync();

                // Notificamos a SignalR el UserId
                NotifySignalRUserId();

                // En caso de reconección volvemos a notificar a SignalR el userId
                connection.Reconnected += async (connectionId) => 
                {
                    NotifySignalRUserId();
                };
            }
        }

        private async void NotifySignalRUserId()
        {
            // Se le notifica a SignalR que usuario somos y de cual chat queremos recibir notificaciones.
            // Únicamente recibiremos actualizaciones del telefono que está en txtPhone, para recibir
            // mensajes de todos los chats en lugar de usar txtPhone.Text + "@c.us" use "AllContacts"
            await connection.InvokeAsync("SetUserIdentity", loginData.userId, txtPhone.Text + "@c.us");
        }

        /* Para obtener el archivo de un mensaje específico */
        private async void GetMessageMedia(string whatsAppMessageUniqueId)
        {
            // Recuperar mensaje de media
            MessageMediaData mediaData = null;
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginData.token);
            try
            {
                mediaData = await httpClient
                    .GetFromJsonAsync<MessageMediaData>(urlGetMessageMedia + "/?whatsAppMessageUniqueId=" + whatsAppMessageUniqueId);
            }
            catch (Exception) { }

            if (mediaData != null)
            {
                SetMessageMedia(mediaData);
            }

        }

        // Buscar un archivo para atachar
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
            SendMessage();
        }

        /* Permite enviar mensaje */
        private async void SendMessage()
        {
            var fileName = Path.GetFileName(txtFileName.Text);
            var httpClient = new HttpClient();

            // Se usa la el token en el encabezado para autorizar el envío de mensaje
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginData.token);

            // Usando HTTP POST se llama al API para enviar el mensaje
            var Response = await httpClient.PostAsJsonAsync(urlSendMessage + "/?number=" + PhoneToken, new SendMessageData()
            {
                userId = loginData.userId,
                whatsAppContactId = txtPhone.Text + "@c.us",
                message = txtMimeType.Text.StartsWith("image") ? "" : txtMessage.Text, // El resto de archivos envian mensaje de texto
                caption = txtMimeType.Text.StartsWith("image") ? txtMessage.Text : "", // Las imágenes pueden usar un caption
                messageBase64 = false,
                media = Convert.ToBase64String(File.ReadAllBytes(txtFileName.Text)),
                fileName = fileName,
                mimeType = txtMimeType.Text
            });

            if (Response.IsSuccessStatusCode)
            {
                txtMessage.Text = ""; // En caso de que el mensaje sea enviado correctamente se borra el texto
            }
        }

        /* El archivo de Media llega de forma asincrónica 
         * Por eso debe ser insertado dentro del registro que le corresponde
         * La busqueda se hace mediante MediaKey         
         */
        private void SetMessageMedia(MessageMediaData mediaData)
        {
            foreach (var msg in this.messages.Where(m => m.mediaKey == mediaData.mediaKey))
            {
                msg.media_Data = mediaData.data;
                msg.media_FileName = mediaData.fileName;
                msg.media_FileName = mediaData.mimeType;
                msg.media_Thumbnail = mediaData.thumbnail;
                this.grdMessages.Refresh();
            }
        }
    }
}
