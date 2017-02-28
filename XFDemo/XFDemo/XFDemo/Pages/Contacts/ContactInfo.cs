using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
//using Xamarin.Forms.Maps;
using XFDemo.Extensions;

namespace XFDemo.Pages.Contacts
{
    public class ContactInfo : ContentPage
    {
        StackLayout contactHeader = new StackLayout();
        StackLayout contactHeaderInfo = new StackLayout();
        StackLayout contactDetails = new StackLayout();
        StackLayout mapWrapper = new StackLayout();
        Image imgContact = new Image();
        Image imgMapDefault = new Image();
        Label lblContactName = new Label();
        Label lblContactEmail = new Label();
        Label lblContactAddress = new Label();
        Label lblContactPhone = new Label();
        Label lblCompany = new Label();
        Label lblContactCompany = new Label();
        //Map mapContactLocation;
        //Pin pinContactLocation;

        public ContactInfo(Model.Contact contactInfo)
        {
            imgContact.Source = Device.OnPlatform(null, ImageSource.FromFile("no_pic.png"), null);
            imgMapDefault.Source = Device.OnPlatform(null, ImageSource.FromFile("map_default.png"), null);
            imgMapDefault.Margin = new Thickness(0, 10, 0, 0);
            
            lblContactName.Text = contactInfo.Name;
            lblContactName.FontAttributes = FontAttributes.Bold;
            lblContactName.FontSize = 25;
            lblContactName.TextColor = Color.Black;
            lblContactName.VerticalOptions = LayoutOptions.Center;

            lblContactEmail.Text = contactInfo.Email;
            lblContactEmail.FontSize = 18;
            lblContactName.VerticalOptions = LayoutOptions.Center;

            lblContactAddress.Text = contactInfo.Address.GetFullAddress();
            lblContactAddress.FontSize = 16;
            lblContactAddress.TextColor = Color.Black;

            lblContactPhone.Text = contactInfo.Phone;
            lblContactPhone.FontSize = 16;
            lblContactPhone.TextColor = Color.Black;

            lblCompany.Text = "Company";
            lblCompany.FontSize = 18;
            lblCompany.TextColor = Color.Black;
            lblCompany.FontAttributes = FontAttributes.Bold;
            lblCompany.Margin = new Thickness(0, 15, 0, 0);

            lblContactCompany.Text = contactInfo.Company.Name;
            lblContactCompany.FontSize = 16;
            lblContactCompany.TextColor = Color.Black;

            //pinContactLocation = new Pin()
            //{
            //    Type = PinType.Place,
            //    Position = new Position(
            //        contactInfo.Address.Geo.Latitude, 
            //        contactInfo.Address.Geo.Longitude),
            //    Label = "Position pin"                
            //};

            //mapContactLocation = 
            //    new Map(
            //        MapSpan.FromCenterAndRadius(
            //            new Position(
            //                contactInfo.Address.Geo.Latitude,
            //                contactInfo.Address.Geo.Longitude),
            //            Distance.FromMiles(0.5)))
            //    {
            //        IsShowingUser = true,
            //        VerticalOptions = LayoutOptions.FillAndExpand
            //    };
            //mapContactLocation.Pins.Add(pinContactLocation);

            //mapWrapper.Padding = new Thickness(0, 10, 0, 0);
            //mapWrapper.Children.Add(mapContactLocation);

            contactDetails.Padding = new Thickness(0, 5, 0, 0);
            contactDetails.Children.Add(lblContactAddress);
            contactDetails.Children.Add(lblContactPhone);
            contactDetails.Children.Add(lblCompany);
            contactDetails.Children.Add(lblContactCompany);
            contactDetails.Children.Add(imgMapDefault);
            //contactDetails.Children.Add(mapWrapper);

            contactHeaderInfo.Padding = new Thickness(10, 0, 0, 0);
            contactHeaderInfo.VerticalOptions = LayoutOptions.Center;
            contactHeaderInfo.Orientation = StackOrientation.Vertical;
            contactHeaderInfo.Children.Add(lblContactName);
            contactHeaderInfo.Children.Add(lblContactEmail);

            contactHeader.VerticalOptions = LayoutOptions.Start;
            contactHeader.HorizontalOptions = LayoutOptions.Start;
            contactHeader.Orientation = StackOrientation.Horizontal;
            contactHeader.Children.Add(imgContact);
            contactHeader.Children.Add(contactHeaderInfo);

            Title = "XFDemo";
            Content = new StackLayout()
            {
                Padding = 20,
                Children =
                {
                    contactHeader,
                    contactDetails
                }
            };
        }
    }
}
