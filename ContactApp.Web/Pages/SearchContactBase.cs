using ContactApp.Web.Services;
using ContactAppModels;
using Microsoft.AspNetCore.Components;

namespace ContactApp.Web.Pages
{
    public class SearchContactBase : ComponentBase
    {
        [Inject]
        public IContactService ContactService { get; set; }
        [Inject]
        protected NavigationManager navigationManager { get; set; }
        List<Contact> Contacts = new List<Contact>();
       
        [Parameter]
        public string Name { get; set; }

        protected async Task SearchContactByName()
        {
            Contacts = await ContactService.SearchContactByName(Name);

            navigationManager.NavigateTo("/SearchContact");
        }

        protected async Task HandleValidSubmit()
        {
            var result = await ContactService.SearchContactByName(Name);
            if (result != null && result.Any())
            {
                Contacts = result.ToList();
                Console.WriteLine($"Found {Contacts.Count} contacts");

                navigationManager.NavigateTo("/");
            }
        }


    }
}
