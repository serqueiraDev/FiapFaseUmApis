using FiapStoreApi.Entity;

namespace FiapStoreApi.Interface
{
    public interface IUsuarioRepository
    {
        IList<Usuario> ListarUsuarios();
        Usuario ListarUsuarioPorId(int id);
        void CadastrarUsuario(Usuario usuario);
        void AtualizarUsuario(Usuario usuario);
        void DeletarUsuario(int id);
    }
}
