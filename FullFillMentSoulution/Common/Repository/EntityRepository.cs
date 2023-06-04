using Common.Model;
using DotNetCore.EntityFrameworkCore;
using DotNetCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Common.Repository
{
    public interface IEntityRepository<TEntity> : IQueryRepository<TEntity>, ICommandRepository<TEntity>
        where TEntity : Entity
    {
        Task<TEntity?> GetByCode(string code);
        Task<TEntity?> GetByName(string name);  
    }
    public interface ICommodityRepository<TEntity> : IEntityRepository<TEntity>
        where TEntity : Commodity
    {
           
    }
    public interface ICenterRepository<TEntity> : IEntityRepository<TEntity>
        where TEntity : Center
    {
        Task<TEntity?> GetByPhoneNumber(string phoneNumber);
        Task<TEntity?> GetByFaxNumber(string faxNumber);
        Task<TEntity?> GetByEmail(string email);
        Task<TEntity?> GetByAddress(string adress);
    }
    
    
    public class EntityRepository<TEntity> : EFRepository<TEntity>, IEntityRepository<TEntity> where TEntity : Entity
    {
        protected readonly DbContext _dbContext;
        public EntityRepository(DbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<TEntity?> GetByCode(string code)
        {
            return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Code != null && e.Code.Equals(code));
        }

        public async Task<TEntity?> GetByName(string name)
        {
            return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Name != null && e.Name.Equals(name));
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
    public class CommodityRepository<TEntity> : EntityRepository<TEntity>, ICommandRepository<TEntity> where TEntity : Commodity
    {
        public CommodityRepository(DbContext context) : base(context)
        {
        }
    }
    public class CenterRepository<TEntity> : EntityRepository<TEntity>, ICenterRepository<TEntity> where TEntity : Center
    {
        public CenterRepository(DbContext context) : base(context)
        {
        }

        public async Task<TEntity?> GetByAddress(string adress)
        {
            return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Address != null &&e.Address.Equals(adress));
        }

        public async Task<TEntity?> GetByEmail(string email)
        {
            return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Email != null && e.Email.Equals(email));
        }

        public async Task<TEntity?> GetByFaxNumber(string faxNumber)
        {
            return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(e => e.FaxNumber != null && e.FaxNumber.Equals(faxNumber));
        }

        public async Task<TEntity?> GetByPhoneNumber(string phoneNumber)
        {
            return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(e => e.PhoneNumber != null && e.PhoneNumber.Equals(phoneNumber));
        }
    }

}
