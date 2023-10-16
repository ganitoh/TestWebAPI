using TestWebAPI.Domain.Models;
using TestWebAPI.Persistance.Services;

namespace TestWebAPI.Persistance.Implementation
{
    public class UserRepository : IUserRepository
    {
        private ApplicationContext _context = null!;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddEntityAsync(User entity)
        {
            if (entity is  null)
                throw new ArgumentNullException(nameof(entity));

             _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntityASync(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            if (user is not null)
                _context.Remove(user);
            
            await _context.SaveChangesAsync();
        }

        public  IEnumerable<User> GetAllAsync() => _context.Users.ToList();

        public User? GetEntityAsync(string id) => _context.Users.FirstOrDefault(u => u.Id == id);

        public async Task UpdateAsync(User entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            var oldData = _context.Users.FirstOrDefault(u => u.Id == entity.Id);

            if (oldData is not null)
            {
                oldData.Login = entity.Login;
                oldData.Password = entity.Password;

                await _context.SaveChangesAsync();
            }
        }
    }
}
