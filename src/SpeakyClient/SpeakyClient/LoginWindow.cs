using System;
namespace SpeakyClient
{
    public partial class LoginWindow : Gtk.Window
    {
        public LoginWindow() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }
    }
}
