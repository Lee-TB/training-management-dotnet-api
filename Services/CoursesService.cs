using TrainingManagementApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace TrainingManagementApi.Services;

public class CoursesService
{
    private readonly IMongoCollection<Course> _coursesCollection;

    public CoursesService(
        IOptions<TrainingManagementDatabaseSettings> trainingManagementDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            trainingManagementDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            trainingManagementDatabaseSettings.Value.DatabaseName);

        _coursesCollection = mongoDatabase.GetCollection<Course>(
            trainingManagementDatabaseSettings.Value.CoursesCollectionName);
    }

    public async Task<List<Course>> GetAsync() =>
        await _coursesCollection.Find(_ => true).ToListAsync();

    public async Task<Course?> GetAsync(string id) =>
        await _coursesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Course newCourse) =>
        await _coursesCollection.InsertOneAsync(newCourse);

    public async Task UpdateAsync(string id, Course updatedCourse) =>
        await _coursesCollection.ReplaceOneAsync(x => x.Id == id, updatedCourse);

    public async Task RemoveAsync(string id) =>
        await _coursesCollection.DeleteOneAsync(x => x.Id == id);
}