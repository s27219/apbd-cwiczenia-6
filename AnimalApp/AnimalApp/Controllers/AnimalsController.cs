using System.Data;
using AnimalApp.Models;
using AnimalApp.Models.DTOs;
using AnimalApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AnimalApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnimalsController : ControllerBase
{
    private readonly IAnimalsService _animalsService;
    public AnimalsController(IAnimalsService animalsService)
    {
        _animalsService = animalsService;
    }
    
    [HttpGet]
    public IActionResult GetAnimals([FromQuery] string orderBy = "name")
    {
        var validColumns = new string[] { "name", "description", "category", "area" };
        if (!validColumns.Contains(orderBy))
            return BadRequest("Invalid orderBy parameter");

        var animals = _animalsService.GetAnimals(orderBy);
        
        return Ok(animals);
    }
    
    [HttpPost]
    public IActionResult AddAnimal([FromBody] AddAnimal addAnimal)
    {
        _animalsService.AddAnimal(addAnimal);
        
        //return Created("", null);
        return StatusCode(StatusCodes.Status201Created);
    }
    
}