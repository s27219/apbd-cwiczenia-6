using AnimalApp.Models;
using AnimalApp.Models.DTOs;

namespace AnimalApp.Repositories;

public interface IAnimalsRepository
{
    IEnumerable<Animal> GetAnimals();
    int AddAnimal(AddAnimal addAnimal);
    Animal GetAnimal(int idStudent);
    int UpdateAnimal(Animal student);
    int DeleteAnimal(int idStudent);
}