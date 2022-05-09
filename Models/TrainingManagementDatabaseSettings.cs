namespace TrainingManagementApi.Models;

public class TrainingManagementDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string TeachersCollectionName { get; set; } = null!;

    public string CoursesCollectionName { get; set; } = null!;

    public string StudentsCollectionName { get; set; } = null!;
}