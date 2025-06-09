using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Contracts.Repositories;
using ProjectManager.Domain.Entities;
using ProjectManager.Infrastructure.Persistence;

namespace ProjectManager.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ProjectManagerDbContext _dbContext;
        public UserRepository(ProjectManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit() => await _dbContext.SaveChangesAsync();

        public async Task<IEnumerable<User>> GetAllUsers()
            => await _dbContext.Users.ToListAsync();

        public async Task<User?> GetUserByEmail(string email)
            => await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}
