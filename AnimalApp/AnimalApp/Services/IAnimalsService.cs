using AnimalApp.Models;
using AnimalApp.Models.DTOs;

namespace AnimalApp.Services;

public interface IAnimalsService
{
    IEnumerable<Animal> GetAnimals(string orderBy);
    int AddAnimal(AddAnimal addAnimal);
    Animal? GetAnimal(int idAnimal);
    int UpdateAnimal(Animal animal);
    int DeleteAnimal(int idAnimal);
}