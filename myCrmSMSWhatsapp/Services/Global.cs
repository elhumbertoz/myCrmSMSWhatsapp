using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myCrmSMSWhatsapp.Services
{
    class Global
    {
        // API de SMSWhatsApp para acceder al servicio
        public const string urlLogin = "https://crm-core.gigamax.ec/api/authenticate/login";
        public const string urlGetMessages = "https://crm-core.gigamax.ec/api/whatsApp/Messages/GetMessagesByContactId";
        public const string urlSendMessage = "https://crm-core.gigamax.ec/api/whatsapp/messages/sendmessage";
        public const string urlGetMessageMedia = "https://crm-core.gigamax.ec/api/whatsapp/messages/getmessagemedia";
        public const string urlGetContacts = "https://crm-core.gigamax.ec/api/WhatsApp/Contacts/GetWhatsAppContacts";
        public const string urlgGetContactPhotoProfile = "https://crm-core.gigamax.ec/api/WhatsApp/Contacts/GetProfilePicByContactId";
        public const string urlSendSeen = "https://crm-core.gigamax.ec/api/whatsapp/Chats/SendSeenByContactId";
        public const string urlDownloadDocument = "https://crm-core.gigamax.ec/api/whatsapp/MessagesPublic/DownloadDocumentByMediaKey";

        // SignalR sirve para establecer conecciones en tiempo real, se usa para recibir los mensajes
        public const string urlSignalRMessages = "https://crm-core.gigamax.ec/hubs/whatsapp/messages";
        public const string urlSignalRChats = "https://crm-core.gigamax.ec/hubs/whatsapp/chats";

        // Token de SMSWhatsApp (number)
        public const string PhoneToken = "ttbfbEwndBBabZQ8VniS";

        private static Image _PersonIcon;
        private static Image _NoImageIcon;
        private static Image _PdfIcon;

        public static Image PersonIcon
        {
            get
            {
                if (_PersonIcon == null)
                    _PersonIcon = Image.FromFile("Images\\person.png");
                return _PersonIcon;
            }
        }

        public static Image NoImageIcon
        {
            get
            {
                if (_NoImageIcon == null)
                    _NoImageIcon = Image.FromFile("Images\\noImage.png");
                return _NoImageIcon;
            }
        }

        public static Image PdfIcon
        {
            get
            {
                if (_PdfIcon == null)
                    _PdfIcon = Image.FromFile("Images\\pdf-icon.png");
                return _PdfIcon;
            }
        }
    }
}
