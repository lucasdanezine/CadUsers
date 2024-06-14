using CadUsers.Entities.DTOs;

namespace CadUsers.Business.ContactService
{
    public interface IContactService
    {
        Task<ContactDto> GetContactByIdAsync(int id);
        Task<IEnumerable<ContactDto>> GetContactsByUserIdAsync(int userId);
        Task AddContactAsync(ContactDto contactDto);
        Task UpdateContactAsync(ContactDto contactDto);
        Task DeleteContactAsync(int id);
    }
}