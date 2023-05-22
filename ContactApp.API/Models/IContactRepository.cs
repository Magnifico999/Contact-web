using ContactAppModels;
using System.Threading.Tasks;

namespace ContactApp.API.Models
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetContacts();
        Task<Contact> GetContact(int id);
        Task<Contact> GetContactbyEmail(string email);
        Task<Contact> AddContact(Contact contact);
        Task<Contact> UpdateContact(Contact contact);
        Task<Contact> DeleteContact(int id);
        Task<IEnumerable<Contact>> Search(string name);
        //IEnumerable<Contact> Paginate(List<Contact> contact, int perpage, int page);


    }
}
