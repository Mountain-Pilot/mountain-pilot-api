using Microsoft.AspNetCore.Mvc;
using Mountain_Pilot.Domain.Catalog;
using Microsoft.AspNetCore.Authorization;
using Mountain_Pilot.Data;

namespace Mountain_Pilot.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CatalogController : ControllerBase
{
    private readonly StoreContext _db;
    public CatalogController(StoreContext db)
    {
        _db = db;
    }
    [HttpGet]
    public ActionResult<List<Item>> GetItems()
    {
        return Ok(_db.Items);
    }

    [HttpGet("{id:int}")]
    public ActionResult<Item> GetItem(int id)
    {
        var item = _db.Items.Find(id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }

    [HttpPost]
    public ActionResult<Item> PostItem(Item item)
    {
        _db.Items.Add(item);
        _db.SaveChanges();
        return Created($"/catalog/{item.Id}", item);
    }

    [HttpPost("{id:int}/ratings")]
    public ActionResult<Item> PostRating(int id, Rating newRating)
    {
        var item = _db.Items.Find(id);
        if (item == null)
        {
            return NotFound();
        }
        item.AddRating(newRating);
        _db.SaveChanges();
        return Ok(item);
    }

    [HttpPut("{id:int}")]
    public ActionResult PutItem(int id, Item updatedItem)
    {
        if (id != updatedItem.Id)
        {
            return BadRequest();
        }

        var item = _db.Items.Find(id);
        if (item == null)
        {
            return NotFound();
        }

        _db.Entry(item).CurrentValues.SetValues(updatedItem);
        _db.SaveChanges();
        return NoContent();
    }
   
   
    [Authorize("delete:catalog")]
    [HttpDelete("{id:int}")]
    public ActionResult DeleteItem(int id)
    {
        var item = _db.Items.Find(id);
        if (item == null)
        {
            return NotFound();
        }

        _db.Items.Remove(item);
        _db.SaveChanges();
        return NoContent();
    }
}
