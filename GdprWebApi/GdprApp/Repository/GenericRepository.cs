using GDPR_POC.Repository.IRepository;
using MongoDB.Driver;

namespace GDPR_POC.Repository
{
    // This class implements the IGenericRepository<T> interface for MongoDB operations.
    // It is a generic repository that provides basic CRUD operations for any type T where T is a class.
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        // A private field to hold the MongoDB collection for the type T.
        private readonly IMongoCollection<T> _collection;

        // Constructor to initialize the MongoDB collection using the database and collection name.
        public GenericRepository(IMongoDatabase database, string collectionName)
        {
            // Assigns the collection of type T from the specified database.
            _collection = database.GetCollection<T>(collectionName);
        }

        // Asynchronously retrieves all documents of type T from the MongoDB collection.
        public async Task<List<T>> GetAllAsync()
        {
            // Find all documents (filtering by true means no filtering) and return the list.
            return await _collection.Find(_ => true).ToListAsync();
        }

        // Asynchronously retrieves a document by its ID.
        public async Task<T> GetByIdAsync(string id)
        {
            // Finds the document with the specified ID in the MongoDB collection.
            return await _collection.Find(Builders<T>.Filter.Eq("Id", id)).FirstOrDefaultAsync();
        }

        // Asynchronously inserts a new document of type T into the MongoDB collection.
        public async Task CreateAsync(T entity)
        {
            // Inserts the entity into the collection.
            await _collection.InsertOneAsync(entity);
        }

        // Asynchronously deletes a document from the collection by its ID.
        public async Task DeleteAsync(string id)
        {
            // Deletes the document with the specified ID from the collection.
            await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("Id", id));
        }

        // Asynchronously updates a document by its ID with the provided update definition.
        public async Task UpdateAsync(string id, UpdateDefinition<T> updateDefinition)
        {
            // Updates the document with the specified ID using the provided update definition.
            await _collection.UpdateOneAsync(Builders<T>.Filter.Eq("Id", id), updateDefinition);
        }
    }

}


