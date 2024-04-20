using AnimalApp.Models;
using AnimalApp.Models.DTOs;

namespace AnimalApp.Services;

public interface IAnimalsService
{
    IEnumerable<Animal> GetAnimals(string orderBy);
    int AddAnimal(AddAnimal addAnimal);
    
    int UpdateAnimal(int id, UpdateAnimal updateAnimal);
    
    int DeleteAnimal(int id);
}