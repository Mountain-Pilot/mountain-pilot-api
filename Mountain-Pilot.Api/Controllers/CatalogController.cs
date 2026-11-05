[HttpGet("{id:int}")]
public ActionResult<Item> GetItem(int id)
{
    var item = Catalog.Find(i => i.Id == id);
    if (item == null)
    {
        return NotFound();
    }
    return item;
}
[HttpPost]
public ActionResult<Item> PostItem(Item newItem)
{
    Catalog.Add(newItem);
    return CreatedAtAction(nameof(GetItem), new { id = newItem.Id }, newItem);
}
[HttpPost("{id:int}/ratings")]
public ActionResult<Item> PostRating(int id, Rating newRating)
{
    var item = Catalog.Find(i => i.Id == id);
    if (item == null)
    {
        return NotFound();
    }
    item.AddRating(newRating);
    return Ok(item);
}
[HttpPut("{id:int}")]
public ActionResult PutItem(int id, Item updatedItem)
{
    if (id != updatedItem.Id)
    {
        return BadRequest();
    }

    var index = Catalog.FindIndex(i => i.Id == id);
    if (index == -1)
    {
        return NotFound();
    }

    Catalog[index] = updatedItem;
    return NoContent();
}
[HttpDelete("{id:int}")]
public ActionResult DeleteItem(int id)
{
    var index = Catalog.FindIndex(i => i.Id == id);
    if (index == -1)
    {
        return NotFound();
    }

    Catalog.RemoveAt(index);
    return NoContent();
}