using System.Diagnostics;
using CatalogoAPI.Context;
using CatalogoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace CatalogoAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly CatalogoApiContext _context;

    public ProductsController(CatalogoApiContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        var p = await _context.Products.ToListAsync();
        if (p is null)
        {
            return NotFound("Não foram encontrados produtos");
        }
        return p;
    }

    [HttpGet("id:int")]
    public async Task<ActionResult<Product>> Get(int id, [BindRequired] string name)
    {
        var productName = name;
        var prod = await _context.Products.FirstOrDefaultAsync((p) => p.Id == id);

        if (prod is null)
        {
            return NotFound("Não foi possível encontrar o produto");
        }
        return prod;
    }

    [HttpPost]
    public ActionResult<Product> CreateProduct(Product p)
    {
        if (p is null)
        {
            return BadRequest("Não foi possível criar o produto");
        }

        _context.Products.Add(p);
        _context.SaveChanges();

        return CreatedAtAction(nameof(CreateProduct), p);
    }

    [HttpPut(("{id:int}"))]
    public ActionResult EditProduct(int id, Product p)
    {
        if (id != p.Id)
        {
            return BadRequest();
        }

        _context.Entry(p).State = EntityState.Modified;
        _context.SaveChanges();
        return Ok(p);
    }

    [HttpDelete("{id:int:min(1)}")]
    public ActionResult Delete(int id)
    {
        var prod = _context.Products.FirstOrDefault(p => p.Id == id);

        if (prod is null)
        {
            return NotFound("Produto nao encontrado.");
        }
        _context.Products.Remove(prod);
        _context.SaveChanges();
        return Ok(prod);
    }
}
