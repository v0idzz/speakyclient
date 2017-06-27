using System;
using System.Diagnostics;
using SpeakyClient.Utils.UI;

namespace SpeakyClient
{
    public partial class HomeWindow : Gtk.Window
    {
        private Account _account;
        private Gtk.NodeView chatsView;

        public HomeWindow(Account account) :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();

            _account = account;

            var task = _account.GetProfilePictureAsync();
            task.Wait();

            profilePicImg.Pixbuf = task.Result.ScaleSimple(100, 100, Gdk.InterpType.Bilinear);
            nameLbl.Text = _account.Firstname;

            BuildTable();

            chatImgEvent.ButtonPressEvent += (s, e) =>
            {
                if (e.Event.Button == 1)
                {
                    var node = (ContactTreeNode)chatsView.NodeSelection.SelectedNode;
                    new UserInfoWindow(node.User, _account).Show();
                }
            };


        }

        private void BuildTable()
        {
            Gtk.NodeStore store = new Gtk.NodeStore(typeof(ContactTreeNode)); // https://bugzilla.xamarin.com/show_bug.cgi?id=51688
			foreach (var user in _account.Contacts)
            {
                store.AddNode(new ContactTreeNode(user));
            }
            chatsView = new Gtk.NodeView(store);

			chatsView.AppendColumn("First name", new Gtk.CellRendererText(), "text", 0);
			chatsView.AppendColumn("Last name", new Gtk.CellRendererText(), "text", 1);
			chatsView.AppendColumn("Country", new Gtk.CellRendererText(), "text", 2);

            chatsView.NodeStore = store;

            chatsView.NodeSelection.Changed += OnSelectionChanged;

			hbox2.Add(chatsView);
            var box = (Gtk.Box.BoxChild)hbox2[chatsView];
			box.Position = 1;

            hbox2.ShowAll();
        }

        async void OnSelectionChanged(object o, EventArgs args)
        {
            var selection = (Gtk.NodeSelection)o;
            var node = (ContactTreeNode)selection.SelectedNode;
            chatImg.Pixbuf?.Dispose();
            chatImg.Pixbuf = (await node.User.GetProfilePicture()).ScaleSimple(50, 50, Gdk.InterpType.Bilinear);

            chatNameLbl.Text = node.User.firstname + " " + node.User.lastname;
            additionalInfoLbl.Text = (node.User.isConnected ? "now" : _account.GetConversationUserByUser(node.User).lastSeen) + ", ";
            additionalInfoLbl.Text += node.User.address;
        }

        protected void OnGooglePlayBtnClicked(object sender, EventArgs e)
        {
            Process.Start("https://play.google.com/store/apps/details?id=appli.speaky.com");
        }

        protected void OnAppStoreBtnClicked(object sender, EventArgs e)
        {
            Process.Start("https://itunes.apple.com/be/app/speaky-instantly-learn-practice/id1118877445?mt=8");
        }
    }
}
