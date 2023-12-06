using FiapStoreApi.Entity;
using FiapStoreApi.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FiapStoreApi.Controllers
{
    [ApiController]
    [Route("v1/usuario")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet("listar-usuarios")]
        public IActionResult ListarUsuarios()
        {
            return Ok(_usuarioRepository.ListarUsuarios());
        }

        [HttpGet("listar-usuarios-por-id/{id:int}")]
        public IActionResult ListarUsuariosPorId(int id)
        {
            return Ok(_usuarioRepository.ListarUsuarioPorId(id));
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar([FromBody] Usuario usuario)
        {
            _usuarioRepository.CadastrarUsuario(usuario);
            return Ok("Usuário criado com sucesso!");
        }

        [HttpPut("atualizar")]
        public IActionResult Atualizar([FromBody] Usuario usuario)
        {
            _usuarioRepository.AtualizarUsuario(usuario);
            return Ok("Usuário atualizado com sucesso!");
        }

        [HttpDelete("excluir/{id:int}")]
        public IActionResult Excluir(int id)
        {
            _usuarioRepository.DeletarUsuario(id);
            return Ok("Usuário deletado com sucesso!");
        }
    }
}
