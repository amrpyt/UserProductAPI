using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;  // تأكد من إضافة هذه المكتبة
using UserProductAPI.Models;

namespace UserProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserProductDbContext _context;

        public UsersController(UserProductDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {

            // إزالة `userId` قبل الإضافة
            user.UserId = 0;

            _context.Users.Add(user);
            await _context.SaveChangesAsync(); // تأكد من إضافة SaveChangesAsync بعد تثبيت Entity Framework Core

            return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
        }
    }
}
