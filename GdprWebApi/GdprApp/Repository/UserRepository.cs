
using GDPR_POC.Repository.IRepository;
using GdprApp.Models;
using MongoDB.Driver;

namespace GDPR_POC.Repository
{
    // This class implements the IUserRepository interface for managing User-related operations.
    // It leverages a generic repository for standard CRUD operations and creates a custom compound index on the User collection.
    public class UserRepository : IUserRepository
    {
        // A private field to hold the generic repository instance for User operations.
        private readonly IGenericRepository<User> _genericRepository;

        // A private field to hold the MongoDB collection specifically for User documents.
        private readonly IMongoCollection<User> _users;

        // Constructor that initializes the generic repository and MongoDB User collection.
        public UserRepository(IMongoDatabase database)
        {
            // Initializes the generic repository for the "Users" collection.
            _genericRepository = new GenericRepository<User>(database, "Users");

            // Retrieves the "Users" collection from the MongoDB database.
            _users = database.GetCollection<User>("Users");

            // Creates a compound index on the User collection for optimized querying.
            CreateCompoundIndex();
        }

        // Private method to create a compound index on the "Id" and "FirstName" fields of the User collection.
        private void CreateCompoundIndex()
        {
            // Defines the index keys by ascending order of "Id" and "FirstName" fields.
            var indexKeys = Builders<User>.IndexKeys.Ascending(user => user.Id).Ascending(user => user.FirstName);

            // Creates the compound index on the MongoDB User collection.
            _users.Indexes.CreateOne(new CreateIndexModel<User>(indexKeys));
        }

        // Asynchronously retrieves all User documents by utilizing the generic repository's GetAllAsync method.
        public Task<List<User>> GetUsersAsync() => _genericRepository.GetAllAsync();

        // Asynchronously retrieves a specific User document by its ID using the generic repository's GetByIdAsync method.
        public Task<User> GetUserByIdAsync(string id) => _genericRepository.GetByIdAsync(id);

        // Asynchronously creates a new User document in the collection via the generic repository's CreateAsync method.
        public Task CreateUserAsync(User user) => _genericRepository.CreateAsync(user);

        // Asynchronously deletes a User document by its ID using the generic repository's DeleteAsync method.
        public Task DeleteUserAsync(string id) => _genericRepository.DeleteAsync(id);

        // Placeholder method for updating a User document. Throws NotImplementedException since it's not yet implemented.
        public Task UpdateUserAsync(string id, User user)
        {
            throw new NotImplementedException();
        }
    }

}

