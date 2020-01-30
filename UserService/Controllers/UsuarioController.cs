using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserService.Domain.DTO;
using UserService.Domain.Entities;
using UserService.Service.Services;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService _usuarioService;
        public UsuarioController(UsuarioService clienteService)
        {
            _usuarioService = clienteService;
        }

        [HttpPost("cliente")]
        public async Task<ActionResult> SalvarCliente([FromBody] ClienteDTO cliente)
        {
            await _usuarioService.SalvarCliente(cliente);
            return Ok(cliente);
        }

        [HttpPost("motorista")]
        public async Task<ActionResult> SalvarMotorista([FromBody] MotoristaDTO motorista)
        {
            await _usuarioService.SalvarMotorista(motorista);
            return Ok(motorista);
        }

        [HttpGet("token/all/motoristas")]
        public async Task<ActionResult<List<String>>> GetAllTokens()
        {
            var tokens = await _usuarioService.obterTokenMotorista();
            return Ok(tokens);
        }
    }
}
