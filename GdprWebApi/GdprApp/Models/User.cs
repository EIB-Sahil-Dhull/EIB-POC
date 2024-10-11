using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GdprApp.Models
{
    public class User
    {
        [BsonId]
        public string Id { get; set; }

        [BsonElement("FirstName")]
        public string FirstName { get; set; }

        [BsonElement("LastName")]
        public string LastName { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("PhoneNumber")] 
        public string PhoneNumber { get; set; }

        [BsonElement("Address")] 
        public string Address { get; set; }

        [BsonElement("DateOfBirth")] 
        public DateTime DateOfBirth { get; set; }

        [BsonElement("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [BsonElement("Consent")]
        public bool Consent { get; set; }
    }

}
