using AnimalApp.Models;
using AnimalApp.Models.DTOs;

namespace AnimalApp.Repositories;

public interface IAnimalsRepository
{
    IEnumerable<Animal> GetAnimals();
    int AddAnimal(AddAnimal addAnimal);
    int UpdateAnimal(int id, UpdateAnimal updateAnimal);
    int DeleteAnimal(int id);
}