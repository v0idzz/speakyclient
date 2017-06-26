using System;
namespace SpeakyClient
{
    public partial class UserInfoWindow : Gtk.Window
    {
        public UserInfoWindow() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }
    }
}
