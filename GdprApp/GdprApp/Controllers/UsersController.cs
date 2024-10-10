using GdprApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GdprApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMongoCollection<User> _users;

        public UsersController(MongoDbContext context)
        {
            _users = context.Users;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            if (!user.Consent)
            {
                return BadRequest("User consent is required.");
            }

            try
            {
                user.Id = ObjectId.GenerateNewId().ToString();
                user.CreatedDate = DateTime.UtcNow;

               
                await _users.InsertOneAsync(user);

                var response = new
                {
                    user.Id,
                    user.FirstName,
                    user.LastName,
                    user.Email,
                    user.PhoneNumber, 
                    user.Address,      
                    CreatedDate = user.CreatedDate.ToString("dd/MM/yy"), 
                    user.Consent,
                    DateOfBirth = user.DateOfBirth.ToString("dd/MM/yyyy")
                };

                return CreatedAtAction(nameof(GetUser), new { id = user.Id }, response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while creating user: {ex.Message}");
                return StatusCode(500, "An error occurred while creating the user. Please try again later.");
            }
        }





        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _users.Find(u => u.Id == id).FirstOrDefaultAsync();
            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            
            var users = await _users.Find(_ => true).ToListAsync();

          
            var response = users.Select(user => new
            {
                user.Id,
                user.FirstName,
                user.LastName,
                user.Email,
                user.PhoneNumber, 
                user.Address,     
                CreatedDate = user.CreatedDate.ToString("dd/MM/yy"),
                DateOfBirth = user.DateOfBirth.ToString("dd/MM/yyyy"),
                user.Consent
            });

            return Ok(response);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, User user)
        {
            var existingUser = await _users.Find(u => u.Id == id).FirstOrDefaultAsync();
            if (existingUser == null)
            {
                return NotFound(); 
            }
            user.CreatedDate = existingUser.CreatedDate;
            await _users.ReplaceOneAsync(u => u.Id == id, user);
            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _users.DeleteOneAsync(u => u.Id == id);
            if (result.DeletedCount == 0)
            {
                return NotFound(); 
            }
            return NoContent();
        }

    }
}
