using System;
using SpeakyClient.Speaky.Api.Json.Classes;

namespace SpeakyClient
{
    public partial class UserInfoWindow : Gtk.Window
    {
        public UserInfoWindow(User user, Account account) :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            profilePicImage.Pixbuf = user.GetProfilePicture().Result;
            firstNameLbl.Text = user.firstname;
            lastNameLbl.Text = user.lastname;
            ageLbl.Text = (DateTime.Now.Subtract(DateTime.Parse(user.birthdate)).TotalDays / 365.25).ToString();
            genderLbl.Text = user.gender == 2 ? "female" : "male";
            addressLbl.Text = user.address;
            joinDateLbl.Text = user.createdAt;
            lastSeenLbl.Text = account.GetConversationUserByUser(user).lastSeen;
        }
    }
}
