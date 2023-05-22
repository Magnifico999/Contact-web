using ContactAppModels;
using System.Net.Http;
using System.Xml.Linq;

namespace ContactApp.Web.Services
{
    public class ContactService : IContactService
    {
        private readonly HttpClient httpClient;

        public ContactService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }



        public async Task<Contact> CreateContact(Contact newContact)
        {
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("api/Contact/add", newContact);
            response.EnsureSuccessStatusCode();
            Contact createdContact = await response.Content.ReadFromJsonAsync<Contact>();
            return createdContact;
        }

        public async Task DeleteContact(int id)
        {
            await httpClient.DeleteAsync($"api/Contact/Delete/{id}");
        }
        public async Task<IEnumerable<Contact>> GetAllContacts()
        {
            return await httpClient.GetFromJsonAsync<Contact[]>($"api/Contact/Contacts");
        }

        public async Task<Contact> GetContact(int id)
        {
            return await httpClient.GetFromJsonAsync<Contact>($"api/Contact/Single/{id}");
        }

        async Task<HttpResponseMessage> IContactService.UpdateContact(Contact contact)
        {
            return await httpClient.PutAsJsonAsync("api/Contact/update", contact);

        }
        //public async Task<List<Contact>> SearchContactByName(string Name)
        //{
        //    return await httpClient.GetFromJsonAsync<List<Contact>>($"api/Contact/Search");
        //}


        public async Task<List<Contact>> SearchContactByName(string name)
        {
            HttpResponseMessage response = await httpClient.GetAsync($"api/Contact/search?");
            response.EnsureSuccessStatusCode();
            List<Contact> foundContacts = await response.Content.ReadFromJsonAsync<List<Contact>>();
            return foundContacts;
        }

    }
}
