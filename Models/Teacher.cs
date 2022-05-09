using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TrainingManagementApi.Models;

public class Teacher
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)] public string? Id { get; set; }

    public string name { get; set; } = null!;

    public string password { get; set; } = null!;

    public string teacherId { get; set; } = null!;
}