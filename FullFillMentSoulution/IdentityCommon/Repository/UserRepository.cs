using Common.ForCommand;
using DotNetCore.EntityFrameworkCore;
using IdentityCommon.Models.ForApplicationUser;
using Microsoft.AspNetCore.Identity;
using 계정Common.Models;

namespace IdentityServerTest.Repository
{
    public class ApplicationUserRepository : EFRepository<ApplicationUser>, IUnitOfWork
    {
        public readonly UnitOfWork<ApplicationDbContext> _unitOfWork;
        private readonly ApplicationDbContext _applicationDbContext;
        public ApplicationUserRepository(ApplicationDbContext applicationDbContext, UnitOfWork<ApplicationDbContext> unitOfWork) :
                    base(applicationDbContext)
        {
            _unitOfWork = unitOfWork;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _unitOfWork.SaveChangesAsync();
        }
        public async Task<ApplicationUser> GetUserByIdAsync(string userId)
        {
            return await _applicationDbContext.Users.FindAsync(userId);
        }

        public async Task<CommandOption?> GetCommandOptionByName(string userId, string nameofCommand)
        {
            var user = await _applicationDbContext.Users.FindAsync(userId);
            if(user == null)
            {
                throw new ArgumentNullException(userId + nameofCommand);
            }
            return user.commandOptions.FirstOrDefault(c => c.NameofCommand == nameofCommand);
        }
    }
    public class IdentityRoleRepository : EFRepository<IdentityRole>, IUnitOfWork
    {
        public readonly UnitOfWork<ApplicationDbContext> _unitOfWork;
        private readonly ApplicationDbContext _applicationDbContext;
        public IdentityRoleRepository(ApplicationDbContext applicationDbContext, UnitOfWork<ApplicationDbContext> unitOfWork) :
                    base(applicationDbContext)
        {
            _unitOfWork = unitOfWork;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _unitOfWork.SaveChangesAsync();
        }
    }
    public class IdentityUserTokenRepository : EFRepository<IdentityUserToken<string>>, IUnitOfWork
    {
        public readonly UnitOfWork<ApplicationDbContext> _unitOfWork;
        private readonly ApplicationDbContext _applicationDbContext;
        public IdentityUserTokenRepository(ApplicationDbContext applicationDbContext, UnitOfWork<ApplicationDbContext> unitOfWork) :
                    base(applicationDbContext)
        {
            _unitOfWork = unitOfWork;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _unitOfWork.SaveChangesAsync();
        }
    }
    public class IdentityUserClaimRepository : EFRepository<IdentityUserClaim<int>>, IUnitOfWork
    {
        public readonly UnitOfWork<ApplicationDbContext> _unitOfWork;
        private readonly ApplicationDbContext _applicationDbContext;
        public IdentityUserClaimRepository(ApplicationDbContext applicationDbContext, UnitOfWork<ApplicationDbContext> unitOfWork) :
                    base(applicationDbContext)
        {
            _unitOfWork = unitOfWork;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _unitOfWork.SaveChangesAsync();
        }
    }
    public class IdentityUserRoleRepository : EFRepository<IdentityUserRole<string>>, IUnitOfWork
    {
        public readonly UnitOfWork<ApplicationDbContext> _unitOfWork;
        private readonly ApplicationDbContext _applicationDbContext;
        public IdentityUserRoleRepository(ApplicationDbContext applicationDbContext, UnitOfWork<ApplicationDbContext> unitOfWork) :
                    base(applicationDbContext)
        {
            _unitOfWork = unitOfWork;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _unitOfWork.SaveChangesAsync();
        }
    }
    public class IdentityRoleClaimRepository : EFRepository<IdentityRoleClaim<int>>, IUnitOfWork
    {
        public readonly UnitOfWork<ApplicationDbContext> _unitOfWork;
        private readonly ApplicationDbContext _applicationDbContext;
        public IdentityRoleClaimRepository(ApplicationDbContext applicationDbContext, UnitOfWork<ApplicationDbContext> unitOfWork) :
                    base(applicationDbContext)
        {
            _unitOfWork = unitOfWork;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _unitOfWork.SaveChangesAsync();
        }
    }
    public class IdentityUserLoginRepository : EFRepository<IdentityUserLogin<string>>, IUnitOfWork
    {
        public readonly UnitOfWork<ApplicationDbContext> _unitOfWork;
        private readonly ApplicationDbContext _applicationDbContext;
        public IdentityUserLoginRepository(ApplicationDbContext applicationDbContext, UnitOfWork<ApplicationDbContext> unitOfWork) :
                    base(applicationDbContext)
        {
            _unitOfWork = unitOfWork;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _unitOfWork.SaveChangesAsync();
        }
    }
}

