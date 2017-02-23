using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using XFDemo.Model;
using XFDemo.Extensions;
using Xamarin.Forms;

namespace XFDemo.Pages.Authentication
{
    public class Login : ContentPage
    {
        //Views definitions
        Image appImage = new Image();
        Entry userName = new Entry();
        Entry password = new Entry();
        Button btnLogin = new Button();
        ActivityIndicator loading = new ActivityIndicator();

        public Login()
        {
            //App Login Image
            appImage.Source = Device.OnPlatform(null, ImageSource.FromFile("ide_xamarin_studio.png"), null);
            
            userName.Placeholder = "Username";

            password.IsPassword = true;
            password.Placeholder = "Password";

            btnLogin.Text = "Login";
            btnLogin.TextColor = Color.White;
            btnLogin.BackgroundColor = Color.FromRgb(18, 137, 245);
            btnLogin.Clicked += btnLogin_OnClicked;

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

        protected async void btnLogin_OnClicked(object sender, EventArgs e)
        {
            btnLogin.IsVisible = false;
            loading.IsRunning = true;

            UserCredentials user = new Model.UserCredentials()
            {
                Username = userName.Text,
                Password = password.Text
            };

            if (await user.AuthenticateAsync())
            {
                //TODO: Go to Contact List.
                btnLogin.Text = "Login correct";
            }

            else
            {
                //TODO: Error message handling
                btnLogin.Text = "Login incorrect";
            }

            loading.IsRunning = false;
            btnLogin.IsVisible = true;
        }
    }
}
