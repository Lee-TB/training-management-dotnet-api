using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TrainingManagementApi.Models;

public class Student
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)] public string? Id { get; set; }

    public string studentId { get; set; } = null!;

    public string name { get; set; } = null!;
    public string classId { get; set; } = null!;
    public string className { get; set; } = null!;
}