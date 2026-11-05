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