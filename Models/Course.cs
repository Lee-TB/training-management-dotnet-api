using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TrainingManagementApi.Models;

public class Course
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)] public string? Id { get; set; }

    public string name { get; set; } = null!;

    public string courseId { get; set; } = null!;
}