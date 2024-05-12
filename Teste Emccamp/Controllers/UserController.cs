using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

using Teste_Emccamp.Models;

namespace Teste_Emccamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _dbContext;

        public UserController(UserContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet("AllUsers")] // Rota para obter todos os usuários
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            ActionResult<IEnumerable<Usuario>> respostaInicial = Ok(new { mensagem = "Carregando..." });

            if (_dbContext.Usuarios == null)
            {
                return NotFound();
            }

            return await _dbContext.Usuarios.ToListAsync();

        }

        //paginacao
        [HttpGet("skip/{Skip:int}/take/{Take:int}")]
        public async Task<IActionResult> GetAsync(
    [FromServices] UserContext context,
    [FromRoute] int skip = 0,
    [FromRoute] int take = 2)
        {
            try
            {
                var total = await context.Usuarios.CountAsync();
                var totalPages = (int)Math.Ceiling((double)total / take);
                var currentPage = (int)Math.Floor((double)skip / take) + 1;

                var todos = await context
                    .Usuarios
                    .AsNoTracking()
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();

                return Ok(new
                {
                    total,
                    currentPage,
                    totalPages,
                    skip,
                    take,
                    data = todos
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao processar a solicitação.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            if (_dbContext.Usuarios == null)
            {
                return NotFound();
            }
            var usuario = await _dbContext.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return usuario;

        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _dbContext.Usuarios.Add(usuario);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.ID }, usuario);
        }

        //pesquisar

        [HttpGet("pesquisar")]
        public async Task<ActionResult<IEnumerable<Usuario>>> SearchUsuarios(string termo)
        {
            termo = termo.ToLower(); // Convertendo o termo de pesquisa para minúsculas

            var usuarios = await _dbContext.Usuarios
                                    .Where(u => u.Nome.ToLower().Contains(termo) ||
                                                u.Telefone.ToLower().Contains(termo) ||
                                                u.Email.ToLower().Contains(termo))
                                    .ToListAsync();

            return usuarios;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.ID)
            {
                return BadRequest();

            }
            _dbContext.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioAvailable(id))
                {
                    return NotFound();

                }
                else
                {
                    throw;
                }
            }

            return Ok();


        }

        private bool UsuarioAvailable(int id)
        {
            return (_dbContext.Usuarios?.Any(x => x.ID == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            if (_dbContext.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _dbContext.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _dbContext.Usuarios.Remove(usuario);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }

}
