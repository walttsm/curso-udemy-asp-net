using System.Security.Principal;
using CatalogoAPI.Context;
using CatalogoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogoAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly CatalogoApiContext _context;
    private readonly IConfiguration _configuration;

    public CategoriesController(CatalogoApiContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    [HttpGet("LerConfig")]
    public string GetValues()
    {
        var value1 = _configuration["key1"];
        var value2 = _configuration["key2"];

        var section1 = _configuration["section1:key2"];

        return $"key1: {value1}, key2: {value2}, section1:key2: {section1}";
    }

    [HttpGet]
    public ActionResult<IEnumerable<Category>> ListCategories()
    {
        var c = _context.Categories.ToList();

        if (c is null)
        {
            return NotFound();
        }
        return c;
    }

    [HttpGet("Produtos")]
    public ActionResult<IEnumerable<Category>> ListCategoriesWithProducts()
    {
        return _context.Categories.Include(p => p.Products).ToList();
    }

    [HttpGet("{id:int:min(1)}")]
    public ActionResult<Category> getCategory(int id)
    {
        var cat = _context.Categories.FirstOrDefault(p => p.Id == id);

        if (cat == null)
        {
            return NotFound("Categoria não encontrada");
        }

        return cat;
    }

    [HttpPost]
    public ActionResult<Category> CreateCategory(Category c)
    {
        _context.Add(c);
        _context.SaveChanges();

        return CreatedAtAction(nameof(CreateCategory), c);
    }

    [HttpPut("{id:int}")]
    public ActionResult<Category> UpdateCategory(int id, Category c)
    {
        if (c.Id != id)
        {
            return BadRequest();
        }
        _context.Entry(c).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(c);
    }

    [HttpDelete("{id:int}")]
    public ActionResult DeleteCategory(int id)
    {
        var cats = _context.Categories.FirstOrDefault(p => p.Id == id);

        if (cats is null)
        {
            return NotFound("Produto nao encontrado.");
        }

        _context.Remove(cats);

        _context.SaveChanges();

        return Ok(cats);
    }
}
