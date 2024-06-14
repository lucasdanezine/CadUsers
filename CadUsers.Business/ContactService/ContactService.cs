using AutoMapper;
using CadUsers.Entities.DTOs;
using CadUsers.Entities.Models;
using CadUsers.Repository;


namespace CadUsers.Business.ContactService
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactService(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<ContactDto> GetContactByIdAsync(int id)
        {
            var contact = await _contactRepository.GetContactByIdAsync(id);
            return _mapper.Map<ContactDto>(contact);
        }

        public async Task<IEnumerable<ContactDto>> GetContactsByUserIdAsync(int userId)
        {
            var contacts = await _contactRepository.GetContactsByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<ContactDto>>(contacts);
        }

        public async Task AddContactAsync(ContactDto contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);
            await _contactRepository.AddContactAsync(contact);
        }

        public async Task UpdateContactAsync(ContactDto contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);
            await _contactRepository.UpdateContactAsync(contact);
        }

        public async Task DeleteContactAsync(int id)
        {
            await _contactRepository.DeleteContactAsync(id);
        }
    }
}
