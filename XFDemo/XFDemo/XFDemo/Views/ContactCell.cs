using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace XFDemo.Views
{
    public class ContactCell : ViewCell
    {
        public ContactCell()
        {
            Image btnInfo = new Image();
            Image contactPic = new Image();
            Label lblContactName = new Label();
            Label lblContactEmail = new Label();
            StackLayout cellWrap = new StackLayout();

            contactPic.Source = Device.OnPlatform(null, ImageSource.FromFile("ic_account_box.png"), null);
            contactPic.HorizontalOptions = LayoutOptions.Start;
            
            lblContactName.SetBinding(Label.TextProperty, "Name");
            lblContactName.TextColor = Color.Black;

            lblContactEmail.SetBinding(Label.TextProperty, "Email");
            lblContactEmail.TextColor = Color.Gray;

            StackLayout infoWrap = new StackLayout
            {
                Padding = new Thickness(5, 0, 0, 0),
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    lblContactName,
                    lblContactEmail
                }
            };

            btnInfo.Source = Device.OnPlatform(null, ImageSource.FromFile("ic_info_outline.png"), null);
            btnInfo.HorizontalOptions = LayoutOptions.End;

            cellWrap.Orientation = StackOrientation.Horizontal;
            cellWrap.Children.Add(contactPic);
            cellWrap.Children.Add(infoWrap);
            cellWrap.Children.Add(btnInfo);
            cellWrap.Padding = new Thickness(10, 0);
            
            View = cellWrap;
        }
    }
}
