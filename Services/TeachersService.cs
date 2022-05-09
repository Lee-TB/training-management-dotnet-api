using TrainingManagementApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace TrainingManagementApi.Services;

public class TeachersService
{
    private readonly IMongoCollection<Teacher> _teachersCollection;

    public TeachersService(
        IOptions<TrainingManagementDatabaseSettings> trainingManagementDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            trainingManagementDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            trainingManagementDatabaseSettings.Value.DatabaseName);

        _teachersCollection = mongoDatabase.GetCollection<Teacher>(
            trainingManagementDatabaseSettings.Value.TeachersCollectionName);
    }

    public async Task<List<Teacher>> GetAsync() =>
        await _teachersCollection.Find(_ => true).ToListAsync();

    public async Task<Teacher?> GetAsync(string id) =>
        await _teachersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Teacher newTeacher) =>
        await _teachersCollection.InsertOneAsync(newTeacher);

    public async Task UpdateAsync(string id, Teacher updatedTeacher) =>
        await _teachersCollection.ReplaceOneAsync(x => x.Id == id, updatedTeacher);

    public async Task RemoveAsync(string id) =>
        await _teachersCollection.DeleteOneAsync(x => x.Id == id);
}