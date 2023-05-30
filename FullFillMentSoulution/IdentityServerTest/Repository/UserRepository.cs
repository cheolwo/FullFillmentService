using DotNetCore.EntityFrameworkCore;
using IdentityServerTest.Data;
using IdentityServerTest.Models;
using System.Threading.Tasks;

namespace IdentityServerTest.Repository
{
    public class ApplicationUserRepository : EFRepository<ApplicationUser>, IUnitOfWork
    {
        public readonly UnitOfWork<ApplicationDbContext> _unitOfWork;
        public ApplicationUserRepository(ApplicationDbContext applicationDbContext, UnitOfWork<ApplicationDbContext> unitOfWork) :
                    base(applicationDbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<int> SaveChangesAsync()
        {
            return _unitOfWork.SaveChangesAsync();
        }
    }
}

