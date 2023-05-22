using ContactApp.Web.Services;
using ContactAppModels;
using Microsoft.AspNetCore.Components;

namespace ContactApp.Web.Pages
{
    public class CreateContactBase : ComponentBase
    {
        [Inject]
        public IContactService ContactService { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        public Contact Contact { get; set; } = new Contact();


        protected async Task HandleValidSubmit()
        { 
            var UpdatedContact = await ContactService.CreateContact(Contact);
            
            if (UpdatedContact != null)
            { 
                NavigationManager.NavigateTo("/");
            }
        }

    }
}
