
using ContactApp.Web.Services;
using ContactAppModels;
using Microsoft.AspNetCore.Components;

namespace ContactApp.Web.Pages
{
    public class EditContactBase : ComponentBase
    {
        [Inject]
        public IContactService ContactService { get; set; }

        public Contact Contact { get; set; } = new Contact();

        [Inject] 
        public NavigationManager NavigationManager { get; set; }

        

        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Contact = await ContactService.GetContact(int.Parse(Id));
            
        }
        
        protected async Task HandleValidSubmit() 
        {
            var result = await ContactService.UpdateContact(Contact); 
            if (result != null)
            {
                NavigationManager.NavigateTo("/");
            }

          
        }


    }
}
