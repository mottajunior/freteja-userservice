using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserService.Domain.IRepositories;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost("{email}/{senha}")]
        public async Task<ActionResult> Login(string email, string senha)
        {
            var user = await _usuarioRepository.Login(email, senha);
            if (user != null)
                return Ok("Login realizado com sucesso");
            else
                return NotFound("Login ou senha inválido");
        }
    }
}