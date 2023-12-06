using FiapStoreApi.Entity;
using FiapStoreApi.Interface;

namespace FiapStoreApi.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private IList<Usuario> _usuario = new List<Usuario>();

        public IList<Usuario> ListarUsuarios()
        {
            return _usuario;
        }

        public Usuario ListarUsuarioPorId(int id)
        {
            return _usuario.FirstOrDefault(u => u.Id == id);
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            _usuario.Add(usuario);
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            var usuarioAlterar = ListarUsuarioPorId(usuario.Id);
            if (usuarioAlterar != null)
            {
                usuarioAlterar.Nome = usuario.Nome;
            }
        }

        public void DeletarUsuario(int id)
        {
            var usuarioRemover = ListarUsuarioPorId(id);
            if (usuarioRemover != null)
            {
                _usuario.Remove(usuarioRemover);
            }
        }
    }
}
