using System;
using SpeakyClient.Speaky.LogIn;

namespace SpeakyClient
{
    public partial class LoginWindow : Gtk.Window
    {
        private LogInMethod _logInMethod;

        public LoginWindow(LogInMethod logInMethod) :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            _logInMethod = logInMethod;

            this.Title += _logInMethod.ToString();
        }

        protected void OnLogInBtnClicked(object sender, EventArgs e)
        {
            IAccountProvider accountProvider = null;
            switch (_logInMethod)
            {
                case LogInMethod.Facebook:
                    accountProvider = new FacebookLogin(usernameEntry.Text, passwordEntry.Text);
                    break;
                case LogInMethod.Google:
                    accountProvider = new GoogleLogin(usernameEntry.Text, passwordEntry.Text);
                    break;
                case LogInMethod.Normal:
                    accountProvider = new NormalLogin(usernameEntry.Text, passwordEntry.Text);
                    break;
            }

            if (accountProvider != null)
            {
                var account = accountProvider.Login();
            }
        }
    }
}
