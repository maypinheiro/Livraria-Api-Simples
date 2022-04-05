using Livraria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrariaController : ControllerBase
    {
        private readonly ToDoContex _context;


        public LivrariaController(ToDoContex contex)
        {
            _context = contex;



            _context.TodoProducts.Add(new Produto { ID = "1", Nome = "Livro1", Preco = 21.88, Quantidade = 2, Categoria = "Romance", Imagem = "img1" });
            _context.TodoProducts.Add(new Produto { ID = "2", Nome = "Livro2", Preco = 30.00, Quantidade = 2, Categoria = "Romance", Imagem = "img2" });
            _context.TodoProducts.Add(new Produto { ID = "3", Nome = "Livro3", Preco = 21.88, Quantidade = 2, Categoria = "Romance", Imagem = "img1" });
            _context.TodoProducts.Add(new Produto { ID = "4", Nome = "Livro4", Preco = 21.88, Quantidade = 2, Categoria = "Romance", Imagem = "img1" });
            _context.TodoProducts.Add(new Produto { ID = "5", Nome = "Livro5", Preco = 21.88, Quantidade = 2, Categoria = "Romance", Imagem = "img1" });
            _context.TodoProducts.Add(new Produto { ID = "6", Nome = "Livro6", Preco = 21.88, Quantidade = 2, Categoria = "Romance", Imagem = "img1" });
            _context.TodoProducts.Add(new Produto { ID = "7", Nome = "Livro7", Preco = 21.88, Quantidade = 2, Categoria = "Romance", Imagem = "img1" });

            _context.SaveChanges();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            return await _context.TodoProducts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetItem(int id)
        {
            var item = await _context.TodoProducts.FindAsync(id.ToString());

            if (item == null)
            {
                return NotFound();
            }
            else
            {
                return item;
            }
        }

        [HttpPost]

        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
           _context.TodoProducts.Add(produto);
           await  _context.SaveChangesAsync();
           return CreatedAtAction(nameof(GetProdutos), new { id = produto.ID }, produto);
          
        }
       
        


    }
}
