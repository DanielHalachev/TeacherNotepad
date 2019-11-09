using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNUserInterface.ViewModels
{
    public class LoginViewModel: Screen
    {
        private string _userName;//underscore means it's just a backing field that holds the value and passes it to the property
        private string _password;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                NotifyOfPropertyChange(() => UserName);//works with properties, not fields. That's why I am using it with the property
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }
        public bool CanLogIn(string userName, string password)
        {
            if(userName.Length>0&& password.Length > 0)
            {
                return true;
            }
            return false;
        }
        public void LogIn(string userName, string password)
        {
            Console.WriteLine();
        }
    }
}
