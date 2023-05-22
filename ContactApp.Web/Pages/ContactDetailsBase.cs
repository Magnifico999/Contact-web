using ContactApp.Web.Services;
using ContactAppModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Runtime.CompilerServices;

namespace ContactApp.Web.Pages
{
    public class ContactDetailsBase : ComponentBase
    {
        public Contact  Contact { get; set; } = new Contact();
        protected string Coordinates { get; set; }

        protected string ButtonText { get; set; } = "Hide Footer";
        protected string CssClass { get; set; } = null;
        [Inject]
        public IContactService ContactService { get; set; }
        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Id = Id ?? "1";
           Contact = await ContactService.GetContact(int.Parse(Id));
        }

        protected void Button_Click()
        {
            if (ButtonText == "Hide Footer")
            {
                ButtonText = "Show Footer";
                CssClass = "HideFooter";
            }
            else
            {
                CssClass = null;
                ButtonText = "Hide Footer";
            }
        }

        /*protected void Mouse_Move(MouseEventArgs e)
        {
            Coordinates = $"X = {e.ClientX} Y = (e.ClientY)";
        }*/
    }
}
