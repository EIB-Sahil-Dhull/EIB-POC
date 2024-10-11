using GDPR_POC.Repository.IRepository;
using GdprApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GdprApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // This controller handles API requests related to User operations.
    // It uses dependency injection to interact with the IUserRepository for User CRUD operations.
    public class UsersController : ControllerBase
    {
        // A private field to hold the User repository interface.
        private readonly IUserRepository _userRepository;

        // Constructor that initializes the User repository through dependency injection.
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET /users
        // Retrieves all users from the repository and returns an Ok (200) response with the list of users.
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Fetches the list of all users asynchronously from the repository.
            var users = await _userRepository.GetUsersAsync();

            // Returns the list of users with a 200 OK status.
            return Ok(users);
        }

        // GET /users/{id}
        // Retrieves a specific user by ID from the repository and returns a 200 OK response if found, or a 404 Not Found if not.
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            // Fetches the user by ID asynchronously from the repository.
            var user = await _userRepository.GetUserByIdAsync(id);

            // Returns the user if found, or a 404 NotFound response if the user doesn't exist.
            return user != null ? Ok(user) : NotFound();
        }

        // POST /users
        // Creates a new user by generating a unique ID, then calling the repository to save the user.
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            // Generates a new unique ID for the user.
            user.Id = ObjectId.GenerateNewId().ToString();

            // Calls the repository to save the new user asynchronously.
            await _userRepository.CreateUserAsync(user);

            // Returns a 201 Created response with the location of the newly created user resource.
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        // DELETE /users/{id}
        // Deletes a user by their ID and returns a NoContent (204) response if successful.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            // Calls the repository to delete the user by ID asynchronously.
            await _userRepository.DeleteUserAsync(id);

            // Returns a 204 NoContent response after successful deletion.
            return NoContent();
        }
    }

}
