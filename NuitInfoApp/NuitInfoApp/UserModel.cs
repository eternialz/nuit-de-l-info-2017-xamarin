using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace NuitInfoApp
{
    class UserModel : INotifyPropertyChanged
    {
        private String _username;

        public String Username
        {
            get { return _username; }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged("Username");
                }
            }
        }

        private String _email;
        public String Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged("Email");
                }
            }
        }

        private String _password;
        public String Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        private String _confirmPassword;
        public String ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                if (_confirmPassword != value)
                {
                    _confirmPassword = value;
                    OnPropertyChanged("ConfirmPassword");
                }
            }
        }
        private String _token;

        public String Token
        {
            get { return _token; }
            set
            {
                if (_token != value)
                {
                    _token = value;
                    OnPropertyChanged("Token");
                }
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
 
        protected virtual void OnPropertyChanged (string propertyName)
	{
            var changed = PropertyChanged;
            if (changed != null) {
                PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
            }
        }
    }
}
