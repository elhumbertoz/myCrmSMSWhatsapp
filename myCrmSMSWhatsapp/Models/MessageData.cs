using myCrmSMSWhatsapp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace myCrmSMSWhatsapp.Models
{
    class MessageData : INotifyPropertyChanged
    {

        private string _media_data;
        private string _media_thumbnail;
        private Image _image = Global.NoImageIcon;

        public int id { get; set; }
        public string userId { get; set; }
        public string userName { get; set; }
        public string whatsAppMessageUniqueId { get; set; }
        public string whatsAppChatUniqueId { get; set; }

        private int _ack;

        public int ack
        {
            get
            {
                return _ack;
            }
            set
            {
                _ack = value;
                NotifyPropertyChanged("AckString");
            }
        }

        public bool hasMedia { get; set; }
        public string mediaKey { get; set; }
        public string body { get; set; }
        public string type { get; set; }  // chat, image, video, file, location
        public long timestamp { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string author { get; set; }
        public bool isForwarded { get; set; }
        public bool fromMe { get; set; }
        public bool hasQuoteMsg { get; set; }
        public string quotedMessageId { get; set; }
        public string quoted_AuthorName { get; set; }
        public string quoted_Body { get; set; }
        public string quoted_Type { get; set; }
        public string quoted_Thumbnail { get; set; }
        public string locationString { get; set; } 
        public int whatsAppNumberId { get; set; }
        public string number { get; set; }
        public string authorName { get; set; }
        public string preferedName { get; set; }
        public string verfiedName { get; set; }
        public string pushname { get; set; }
        public bool ackUser { get; set; }

        
        private string _media_MimeType;
        public string media_MimeType {
            get
            {
                return _media_MimeType;
            }
            set
            {
                _media_MimeType = value;
            }
        }
        
        public string media_Data 
        { 
            get
            {
                return _media_data;
            }
            set
            {
                _media_data = value;

                if (_media_data != null)
                {
                    byte[] bytes = Convert.FromBase64String(_media_data);
                    using (MemoryStream ms = new MemoryStream(bytes))
                    {
                        try
                        {
                            _image = Image.FromStream(ms);

                            NotifyPropertyChanged("image");
                        }
                        catch (Exception) { }
                    }
                }
            }
        }

        public string media_Thumbnail
        {
            get
            {
                return _media_thumbnail;
            }
            set
            {
                _media_thumbnail = value;

                if (_media_data == null && _media_thumbnail != null)
                {
                    byte[] bytes = Convert.FromBase64String(_media_thumbnail);
                    using (MemoryStream ms = new MemoryStream(bytes))
                    {
                        try
                        {
                            _image = Image.FromStream(ms);

                            NotifyPropertyChanged("image");
                        }
                        catch (Exception) { }
                    }

                }
            }
        }
        public string media_FileName { get; set; }
        public bool media_IsAudio { get; set; }
        public bool media_IsVideo { get; set; }
        public bool media_IsImage { get; set; }


        public Image image
        {
            get
            {
                if (_media_MimeType != null && _media_MimeType.ToLower().EndsWith("pdf"))
                    _image = Global.PdfIcon;

                return _image;
            }
        }


        public DateTime DateTime
        {
            get
            {
                return UnixTimeStampToDateTime(this.timestamp);
            }
        }

        public string FromString
        {
            get
            {
                if (fromMe)
                    return "Yo";
                else if (this.from.Contains("@g.us"))
                    return authorName;
                else
                    return this.from.Replace(this.number, "");
            }
        }

        public string AckString
        {
            get
            {
                if (!fromMe)
                    return "";
                if (ack == 1)
                    return "✓";
                if (ack == 2)
                    return "✓✓";
                if (ack >= 3)
                    return "✅✅";
                return "";
            }
        }


        private DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
