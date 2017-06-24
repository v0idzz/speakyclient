using System;
namespace SpeakyClient
{
    public partial class HomeWindow : Gtk.Window
    {
        private Account _account;

        public HomeWindow(Account account) :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            _account = account;
            var task = _account.GetProfilePictureAsync();
            task.Wait();
            profilePicImg.Pixbuf = task.Result.ScaleSimple(100, 100, Gdk.InterpType.Bilinear);
        }
    }
}
