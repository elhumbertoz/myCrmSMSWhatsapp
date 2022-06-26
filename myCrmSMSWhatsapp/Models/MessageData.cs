using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myCrmSMSWhatsapp
{
    class MessageData
    {

        private string _media_data;
        private string _media_thumbnail;
        private Image _image;

        public int id { get; set; }
        public string userId { get; set; }
        public string userName { get; set; }
        public string whatsAppMessageUniqueId { get; set; }
        public string whatsAppChatUniqueId { get; set; }
        public int ack { get; set; }
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
        public string locationString { get; set; } // "-1.522225, -80.51515"
        public int whatsAppNumberId { get; set; }
        public string number { get; set; }
        public string authorName { get; set; }
        public string preferedName { get; set; }
        public string verfiedName { get; set; }
        public string pushname { get; set; }
        public bool ackUser { get; set; }

        

        public string media_MimeType { get; set; }
        
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
                return this.fromMe ? "Yo" : this.from.Replace(this.number, "").Replace("@c.us", "");
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
    }
}
