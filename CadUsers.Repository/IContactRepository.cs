using CadUsers.Entities.Models;

namespace CadUsers.Repository
{
    public interface IContactRepository
    {
        Task<Contact> GetContactByIdAsync(int id);
        Task<IEnumerable<Contact>> GetContactsByUserIdAsync(int userId);
        Task AddContactAsync(Contact contact);
        Task UpdateContactAsync(Contact contact);
        Task DeleteContactAsync(int id);
    }
}