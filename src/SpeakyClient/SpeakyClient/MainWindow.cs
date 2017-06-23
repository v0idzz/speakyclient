using System;
using System.Diagnostics;
using Gtk;
using SpeakyClient;
using SpeakyClient.Speaky.LogIn;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    private void ShowLoginWindow(LogInMethod logInMethod)
    {
        var loginWin = new LoginWindow(logInMethod);
        loginWin.Show();
        this.Destroy();
    }

    protected void OnFacebookLogInBtnClicked(object sender, EventArgs e)
    {
        ShowLoginWindow(LogInMethod.Facebook);
    }

    protected void OnGoogleLogInBtnClicked(object sender, EventArgs e)
    {
        ShowLoginWindow(LogInMethod.Google);
    }

    protected void OnNormalLogInBtnClicked(object sender, EventArgs e)
    {
        ShowLoginWindow(LogInMethod.Normal);
    }
}
