using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using XFDemo.Extensions;
using Plugin.Geolocator;
using Geo = Plugin.Geolocator.Abstractions;

namespace XFDemo.Pages.Contacts
{
    public class ContactInfo : ContentPage
    {
        ActivityIndicator loading = new ActivityIndicator();
        StackLayout contactHeader = new StackLayout();
        StackLayout contactHeaderInfo = new StackLayout();
        StackLayout contactDetails = new StackLayout();
        StackLayout mapWrapper = new StackLayout();
        Image imgContact = new Image();
        //Image imgMapDefault = new Image();
        Label lblContactName = new Label();
        Label lblContactEmail = new Label();
        Label lblContactAddress = new Label();
        Label lblContactPhone = new Label();
        Label lblCompany = new Label();
        Label lblContactCompany = new Label();
        Map mapContactLocation;
        Pin pinContactLocation;
        Geo.Position myPosition;
        double distance;

        public ContactInfo(Model.Contact contactInfo)
        {
            imgContact.Source = Device.OnPlatform(null, ImageSource.FromFile("no_pic.png"), null);
            //imgMapDefault.Source = Device.OnPlatform(null, ImageSource.FromFile("map_default.png"), null);
            //imgMapDefault.Margin = new Thickness(0, 10, 0, 0);

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

            loading.IsVisible = true;
            loading.IsRunning = true;

            pinContactLocation = new Pin()
            {
                Type = PinType.Place,
                Position = new Position(
                    contactInfo.Address.Geo.Latitude,
                    contactInfo.Address.Geo.Longitude),
                Label = contactInfo.Name
            };

            mapContactLocation =
                new Map(
                    MapSpan.FromCenterAndRadius(
                        pinContactLocation.Position,
                        Distance.FromMiles(2.5)))
                {
                    IsShowingUser = true,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HeightRequest = 240,
                    WidthRequest = 310
                };

            mapWrapper.Padding = new Thickness(0, 10, 0, 0);
            mapWrapper.Children.Add(mapContactLocation);
            mapWrapper.IsVisible = false;

            contactDetails.Padding = new Thickness(0, 5, 0, 0);
            contactDetails.Children.Add(lblContactAddress);
            contactDetails.Children.Add(lblContactPhone);
            contactDetails.Children.Add(lblCompany);
            contactDetails.Children.Add(lblContactCompany);
            contactDetails.Children.Add(loading);
            contactDetails.Children.Add(mapWrapper);

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

        protected async override void OnAppearing()
        {
            if (mapContactLocation.Pins.Count <= 0)
            {
                await UpdatePinInfo();
            }

            base.OnAppearing();
        }

        private async Task UpdatePinInfo()
        {
            Geo.IGeolocator locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            locator.AllowsBackgroundUpdates = true;

            myPosition = await locator.GetPositionAsync(10000);

            CalculateDistance();

            pinContactLocation.Address = "You are " + distance.ToString("F2") + " mi. from your contact";
            mapContactLocation.Pins.Add(pinContactLocation);

            loading.IsVisible = false;
            loading.IsRunning = false;
            mapWrapper.IsVisible = true;
        }

        private void CalculateDistance()
        {
            double lon1 = myPosition.Longitude;
            double lat1 = myPosition.Latitude;
            double lon2 = pinContactLocation.Position.Longitude;
            double lat2 = pinContactLocation.Position.Latitude;
            double theta = lon1 - lon2;
            double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = rad2deg(dist);
            dist = dist * 60 * 1.1515;
            dist = dist * 0.8684;
            distance = dist;
        }

        private double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        private double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }
    }
}
