using ContactAppModels;
using Microsoft.EntityFrameworkCore;

namespace ContactApp.API.Models
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _appDbContext;

        public ContactRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Contact> AddContact(Contact contact)
        { 
            var result = await _appDbContext.Contacts.AddAsync(contact);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Contact> DeleteContact(int id)
        {
            var result = await _appDbContext.Contacts.FirstOrDefaultAsync(e => e.Id == id);
            if (result != null)
            {
                _appDbContext.Contacts.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Contact> GetContact(int id)
        {
            return await _appDbContext.Contacts
            .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Contact> GetContactbyEmail(string email)
        {
            return await _appDbContext.Contacts
            .FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
           return await _appDbContext.Contacts.ToListAsync();
        }

        public async Task<Contact> UpdateContact(Contact contact)
        {
            var result = await _appDbContext.Contacts
                .FirstOrDefaultAsync(e => e.Id == contact.Id);

            if (result != null)
            {
                result.FirstName = contact.FirstName;
                result.LastName = contact.LastName;
                result.Email = contact.Email;
                result.DateOfBirth = contact.DateOfBirth;
                result.Phonenumber = contact.Phonenumber;
                result.Gender = contact.Gender;
                result.Address = contact.Address;
                result.Occupation = contact.Occupation;
                result.PhotoPath = contact.PhotoPath;

                await _appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Contact>> Search(string name)
        {
            IQueryable<Contact> query = _appDbContext.Contacts;
            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(e => e.FirstName.Contains(name)
                || e.LastName.Contains(name));
            }

            return await query.ToListAsync();
        }

        //public IEnumerable<Contact> Paginate(List<Contact> contact, int perpage, int page)
        //{
        //    page = page < 1 ? 1 : page; perpage = page < 1 ? 5 : perpage;
            
        //    if (contact.Count > 0)
        //    { 
        //      var paginated = contact.Skip(page - 1).Take(perpage).ToList();
        //        return paginated; 
        //    } 
        //    return new List<Contact>();
        //}
    }
}
