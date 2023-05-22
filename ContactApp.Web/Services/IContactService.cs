using ContactAppModels;

namespace ContactApp.Web.Services
{
    public interface IContactService
    {
       
        Task<IEnumerable<Contact>> GetAllContacts();
        Task<Contact> GetContact(int id);
        Task<HttpResponseMessage> UpdateContact(Contact updatedContact);
        Task<Contact> CreateContact(Contact newContact);
        Task DeleteContact(int id);
        Task<List<Contact>> SearchContactByName(string Name);
    }
}
