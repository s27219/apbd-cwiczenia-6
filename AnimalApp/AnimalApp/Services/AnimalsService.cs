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
    
    public int UpdateAnimal(int id, UpdateAnimal updateAnimal)
    {
        return _animalsRepository.UpdateAnimal(id, updateAnimal);
    }
    
    public int DeleteAnimal(int id)
    {
        return _animalsRepository.DeleteAnimal(id);
    }
}