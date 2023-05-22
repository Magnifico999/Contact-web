using ContactApp.Web.Services;
using ContactAppModels;
using Microsoft.AspNetCore.Components;

namespace ContactApp.Web.Pages
{
    public class DisplayContactBase : ComponentBase 
    {
        [Parameter]
        public Contact Contact { get; set; }

        [Parameter]
        public bool ShowFooter { get; set; }

        [Parameter]
        public EventCallback<bool> OnContactSelection { get; set; }

        [Parameter]
        public EventCallback<int> OnContactDeleted { get; set; }

        [Inject] 
        public IContactService ContactService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected ContactsComponenet.ConfirmBase DeleteConfirmation { get; set; }

        protected void Delete_Click()
        {
            DeleteConfirmation.Show();
            NavigationManager.NavigateTo("/");
        }

        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await ContactService.DeleteContact(Contact.Id);
                await OnContactDeleted.InvokeAsync(Contact.Id);
                
            }
        }
       
        protected async Task CheckBoxChanged(ChangeEventArgs e)
        {
            await OnContactSelection.InvokeAsync((bool)e.Value);
            
        }
    }
}
