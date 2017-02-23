using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using XFDemo.Model;
using XFDemo.Extensions;
using Xamarin.Forms;

namespace XFDemo.Pages.Contacts
{
    public class MyContacts : ContentPage
    {
        Label lblContactsMessage = new Label();
        ListView myContactsListView = new ListView();
        TextCell tclContact = new TextCell();

        public MyContacts()
        {
            Content = myContactsListView;

            //Content = new StackLayout
            //{
            //    Children = {
            //        myContactsListView
            //    }
            //};
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            
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

            myContactsListView.Header = lblContactsMessage;
            myContactsListView.ItemTemplate = new DataTemplate(typeof(TextCell));
            myContactsListView.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");
            myContactsListView.ItemTemplate.SetBinding(TextCell.DetailProperty, "Email");
        }
    }
}
