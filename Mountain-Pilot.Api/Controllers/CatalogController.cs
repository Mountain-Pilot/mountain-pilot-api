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