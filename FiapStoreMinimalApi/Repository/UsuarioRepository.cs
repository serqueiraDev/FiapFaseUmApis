using FiapStoreMinimalAPI.Entity;
using FiapStoreMinimalAPI.Interface;

namespace FiapStoreMinimalAPI.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private IList<Usuario> _usuarios = new List<Usuario>();

        public IList<Usuario> ListarUsuarios()
        {
            return _usuarios;
        }

        public Usuario ListarUsuarioPorId(int id)
        {
            return _usuarios.FirstOrDefault(u=>u.Id == id);
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            _usuarios.Add(usuario);
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            var usuarioAlterado = ListarUsuarioPorId(usuario.Id);
            if (usuarioAlterado != null) 
            { 
                usuario.Nome = usuarioAlterado.Nome;
            }
        }

        public void DeletarUsuario(int id)
        {
            var usuarioRemovido = ListarUsuarioPorId(id);
            if (usuarioRemovido != null)
            {
                _usuarios.Remove(usuarioRemovido);
            }
        }
    }
}
