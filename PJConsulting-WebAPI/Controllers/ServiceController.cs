using Microsoft.AspNetCore.Mvc;
using PJConsulting_WebAPI.Data;

namespace PJConsulting_WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ServiceController : ControllerBase
{
    private static readonly List<Service> Services = [];

    [HttpGet]
    public ActionResult<IEnumerable<Service>> GetAll()
    {
        return Ok(Services);
    }

    [HttpGet("{id}")]
    public ActionResult<Service> GetById(int id)
    {
        var service = Services.FirstOrDefault(s => s.Id == id);
        if (service is null)
            return NotFound();

        return Ok(service);
    }

    [HttpPost]
    public ActionResult<Service> Create(Service service)
    {
        Services.Add(service);
        return CreatedAtAction(nameof(GetById), new { id = service.Id }, service);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, Service updated)
    {
        var existing = Services.FirstOrDefault(s => s.Id == id);
        if (existing is null)
            return NotFound();

        existing.Name = updated.Name;
        existing.Description = updated.Description;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var service = Services.FirstOrDefault(s => s.Id == id);
        if (service is null)
            return NotFound();

        Services.Remove(service);
        return NoContent();
    }
}
