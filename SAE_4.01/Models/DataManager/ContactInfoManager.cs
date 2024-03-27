using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager
{
    public class ContactInfoManager : IDataRepository<ContactInfo>
    {
        readonly BMWDBContext _dbContext;

        public ContactInfoManager() { }

        public ContactInfoManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<ContactInfo>>> GetAllAsync()
        {
            return await _dbContext.ContactInfos.ToListAsync();
        }

        public async Task<ActionResult<ContactInfo>> GetByIdAsync(int id)
        {
            return await _dbContext.ContactInfos.FirstOrDefaultAsync(p => p.IdContact == id);
        }

        public async Task AddAsync(ContactInfo entity)
        {
            await _dbContext.ContactInfos.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(ContactInfo ctf, ContactInfo entity)
        {
            _dbContext.Entry(ctf).State = EntityState.Modified;
            ctf.IdContact = entity.IdContact;
            ctf.NomContact = entity.NomContact;
            ctf.PrenomContact = entity.PrenomContact;
            ctf.DateNaissanceContact = entity.DateNaissanceContact;
            ctf.EmailContact = entity.EmailContact;
            ctf.TelContact = entity.TelContact;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(ContactInfo ctf)
        {
            _dbContext.ContactInfos.Remove(ctf);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<IEnumerable<ContactInfo>>> IDataRepository<ContactInfo>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<ContactInfo>>> IDataRepository<ContactInfo>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<ContactInfo>>> IDataRepository<ContactInfo>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<ContactInfo>>> IDataRepository<ContactInfo>.GetByIdMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<ContactInfo>>> IDataRepository<ContactInfo>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<ContactInfo>>> IDataRepository<ContactInfo>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<ContactInfo>>> IDataRepository<ContactInfo>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<ContactInfo>>> IDataRepository<ContactInfo>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<ContactInfo>>> IDataRepository<ContactInfo>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<ContactInfo>>> IDataRepository<ContactInfo>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<ContactInfo>>> IDataRepository<ContactInfo>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<ContactInfo>>> IDataRepository<ContactInfo>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<ContactInfo>> IDataRepository<ContactInfo>.GetBy2CompositeKeysAsync(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<ContactInfo>> IDataRepository<ContactInfo>.GetBy3CompositeKeysAsync(int id1, int id2, int id3)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<ContactInfo>> IDataRepository<ContactInfo>.GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4)
        {
            throw new NotImplementedException();
        }
    }
}
