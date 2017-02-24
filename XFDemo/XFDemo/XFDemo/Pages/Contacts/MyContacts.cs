using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using XFDemo.Model;
using XFDemo.Extensions;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace XFDemo.Pages.Contacts
{
    public class MyContacts : ContentPage
    {
        Label lblContactsMessage = new Label();
        ListView myContactsListView = new ListView();
        TextCell tclContact = new TextCell();

        public MyContacts()
        {
            Title = "XFDemo";

            lblContactsMessage.TextColor = Color.Black;

            myContactsListView.IsPullToRefreshEnabled = true;
            myContactsListView.Refreshing += myContactsListView_OnRefreshing;
            myContactsListView.ItemTapped += myContactsListView_OnItemTapped;
            myContactsListView.ItemSelected += myContactsListView_OnItemSelected;

            Content = myContactsListView;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            
            await LoadMyContactsAsync();     

            myContactsListView.Header = lblContactsMessage;
            myContactsListView.ItemTemplate = new DataTemplate(typeof(Views.ContactCell));            
        }

        protected void myContactsListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            ((ListView)sender).SelectedItem = null;
        }

        protected void myContactsListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            //TODO: Go to Contact Info.
            //await Navigation.PushAsync(Pages.Contacts.ContactInfo);
        }

        protected async void myContactsListView_OnRefreshing(object sender, EventArgs e)
        {
            await LoadMyContactsAsync();

            ((ListView)sender).EndRefresh();
        }

        private async Task LoadMyContactsAsync()
        {
            List<Contact> contacts = new List<Contact>();
            await contacts.LoadContactsAsync();

            if (contacts.Count > 0)
            {
                myContactsListView.ItemsSource = contacts;

                lblContactsMessage.Text = "My Contacts";
            }

            else
            {
                lblContactsMessage.Text = "No contacts to display.";
            }
        }
    }
}
