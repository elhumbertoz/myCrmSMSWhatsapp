using myCrmSMSWhatsapp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myCrmSMSWhatsapp.Models 
{
    class ChatData : INotifyPropertyChanged
    {
        public string whatsAppContactId { get; set; }

        private int _unreadCount;

        public int unreadCount { 
            get 
            {
                return _unreadCount;
            }
            set {
                _unreadCount = value;
                NotifyPropertyChanged();
            } 
        }

        public bool isGroup { get; set; }
        public string name { get; set; }
        public string preferredName { get; set; }
        public string comment { get; set; }
        public string pushname { get; set; }
        public string phoneNumber { get; set; }
        public DateTime lastActivity { get; set; }

        private string _profilePictureUrl;
        public string profilePictureUrl
        {
            get
            {
                return _profilePictureUrl;
            }
            set
            {
                _profilePictureUrl = value;

                if (pictureBox == null)
                    pictureBox = new PictureBox();

                try
                {
                    pictureBox.Load(_profilePictureUrl);
                    _profilePicture = pictureBox.Image;
                    NotifyPropertyChanged("profilePicture");
                }
                catch (Exception) { }
            }
        }

        private PictureBox pictureBox;
        private Image _profilePicture = Global.PersonIcon;

        public Image profilePicture { 
            get 
            {
                return _profilePicture;
            } 
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
