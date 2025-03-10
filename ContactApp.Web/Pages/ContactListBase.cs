﻿using ContactApp.Web.Services;
using ContactAppModels;
using Microsoft.AspNetCore.Components;

namespace ContactApp.Web.Pages
{
    public class ContactListBase : ComponentBase
    {
        [Inject]
        public IContactService ContactService { get; set; }
        public bool ShowFooter { get; set; } = true;
        public IEnumerable<Contact> Contacts { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Contacts = (await ContactService.GetAllContacts()).ToList();
            }
            catch (Exception ex)
            {
                // Handle the exception, show a message, etc.
                Console.WriteLine($"Error initializing contacts: {ex.Message}");
            }
        }



        public Contact Contact { get; set; }
        
        protected async Task GetContactList()
        {
            Contacts = (await ContactService.GetAllContacts()).ToList();
        }

        protected async Task ContactDeleted()
        {
            Contacts = (await ContactService.GetAllContacts()).ToList();
            
        }

        protected int SelectedContactsCount { get; set; } = 0;
        protected void ContactSelectionChanged(bool isSelected)
        {
            if (isSelected)
            {
                SelectedContactsCount++;
            } 
            else
            {
                SelectedContactsCount--;
            }
        }
      
    }
}