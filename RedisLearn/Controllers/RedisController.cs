using Microsoft.AspNetCore.Mvc;
using Redis.OM;
using Redis.OM.Searching;
using RedisLearn.Models;

namespace RedisLearn.Controllers;
[ApiController]
[Route("[controller]")]
public class RedisController(RedisConnectionProvider provider) : ControllerBase
{
    private readonly RedisCollection<Person> _people = (RedisCollection<Person>)provider.RedisCollection<Person>();

    [HttpPost("createPerson")]
    public async Task<Person> AddPerson([FromBody] Person person)
    {
        await _people.InsertAsync(person);
        return person;
    }
    
    [HttpGet("GetAllPeople")]
    public async Task<IActionResult> Index()
    {
        try
        {
            return Ok(await _people.ToListAsync());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}