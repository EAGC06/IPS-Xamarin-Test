using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace XFDemo.Pages.Authentication
{
    public class Login : ContentPage
    {
        public Login()
        {
            //Views definitions
            Image appImage = new Image();
            Entry userName = new Entry();
            Entry password = new Entry();
            Button btnLogin = new Button();
            ActivityIndicator loading = new ActivityIndicator();

            //App Login Image
            appImage.Source = Device.OnPlatform(null, ImageSource.FromFile("ide_xamarin_studio.png"), null);
            
            userName.Placeholder = "Username";

            password.IsPassword = true;
            password.Placeholder = "Password";

            btnLogin.Text = "Login";
            btnLogin.TextColor = Color.White;
            btnLogin.BackgroundColor = Color.FromRgb(18, 137, 245);
            btnLogin.Clicked += (sender, args) =>
            {
                btnLogin.IsVisible = false;
                loading.IsRunning = true;
            };

            Title = "XFDemo";
            Content = new StackLayout
            {
                Padding = 20,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children =
                {
                    appImage,
                    userName,
                    password,
                    btnLogin,
                    loading
                }
            };
        }
    }
}
