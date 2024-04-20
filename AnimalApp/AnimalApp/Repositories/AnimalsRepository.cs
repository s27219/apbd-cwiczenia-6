using AnimalApp.Models;
using AnimalApp.Models.DTOs;
using Microsoft.Data.SqlClient;

namespace AnimalApp.Repositories;

public class AnimalsRepository : IAnimalsRepository
{
    private readonly IConfiguration _configuration;
    public AnimalsRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public IEnumerable<Animal> GetAnimals()
    {
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();

        using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM Animal";

        var reader = command.ExecuteReader();

        List<Animal> animals = new List<Animal>();
        
        int idAnimalOrdinal = reader.GetOrdinal("IdAnimal");
        int nameOrdinal = reader.GetOrdinal("Name");
        int descriptionOrdinal = reader.GetOrdinal("Description");
        int categoryOrdinal = reader.GetOrdinal("Category");
        int areaOrdinal = reader.GetOrdinal("Area");
        
        
        while (reader.Read())
        {
            animals.Add(new Animal()
            {
                IdAnimal = reader.GetInt32(idAnimalOrdinal),
                Name = reader.GetString(nameOrdinal),
                Description = reader.GetString(descriptionOrdinal),
                Category = reader.GetString(categoryOrdinal),
                Area = reader.GetString(areaOrdinal)
            });
        }

        return animals;
    }

    public int AddAnimal(AddAnimal addAnimal)
    {
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();

        using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "INSERT INTO Animal VALUES(@animalName, @animalDescription, @animalCategory, @animalArea)";
        command.Parameters.AddWithValue("@animalName", addAnimal.Name);
        command.Parameters.AddWithValue("@animalDescription", addAnimal.Description);
        command.Parameters.AddWithValue("@animalCategory", addAnimal.Category);
        command.Parameters.AddWithValue("@animalArea", addAnimal.Area);
        
        var affectedCount = command.ExecuteNonQuery();
        return affectedCount;
    }
    
    public int UpdateAnimal(int id, UpdateAnimal updateAnimal)
    {
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();

        using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "UPDATE Animal SET Name=@animalName, Description=@animalDescription, Category=@animalCategory, Area=@animalArea WHERE IdAnimal = @animalId";
        command.Parameters.AddWithValue("@animalName", updateAnimal.Name);
        command.Parameters.AddWithValue("@animalDescription", updateAnimal.Description);
        command.Parameters.AddWithValue("@animalCategory", updateAnimal.Category);
        command.Parameters.AddWithValue("@animalArea", updateAnimal.Area);
        command.Parameters.AddWithValue("@animalId", id);
        
        var affectedCount = command.ExecuteNonQuery();
        return affectedCount;
    }
    
    public int DeleteAnimal(int id)
    {
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();

        using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "DELETE FROM Animal WHERE IdAnimal = @animalId";
        command.Parameters.AddWithValue("@animalId", id);
        
        var affectedCount = command.ExecuteNonQuery();
        return affectedCount;
    }
}