using AnimalApp.Models;
using AnimalApp.Models.DTOs;
using AnimalApp.Repositories;

namespace AnimalApp.Services;

public class AnimalsService : IAnimalsService
{
    private readonly IAnimalsRepository _animalsRepository;
    
    public AnimalsService(IAnimalsRepository animalsRepository)
    {
        _animalsRepository = animalsRepository;
    }
    
    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        orderBy = char.ToUpper(orderBy[0]) + orderBy.Substring(1);
        return _animalsRepository.GetAnimals().OrderBy(a => a.GetType().GetProperty(orderBy).GetValue(a)).ToList();
    }

    public int AddAnimal(AddAnimal addAnimal)
    {
        return _animalsRepository.AddAnimal(addAnimal);
    }

    public Animal? GetAnimal(int idStudent)
    {
        throw new NotImplementedException();
    }

    public int UpdateAnimal(Animal student)
    {
        throw new NotImplementedException();
    }

    public int DeleteAnimal(int idStudent)
    {
        throw new NotImplementedException();
    }
}