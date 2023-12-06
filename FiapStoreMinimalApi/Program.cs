using FiapStoreMinimalAPI.Entity;
using FiapStoreMinimalAPI.Interface;
using FiapStoreMinimalAPI.Repository;

#region -- Add services to the container. --
var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IUsuarioRepository, UsuarioRepository>();

var app = builder.Build();
#endregion

#region -- Configure the HTTP request pipeline. --

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#endregion

#region -- Endpoints --

app.MapGet("/listar-usuarios", (IUsuarioRepository usuarioRepository) =>
{
    return usuarioRepository.ListarUsuarios();
});

app.MapGet("/listar-usuario-por-id", (int id, IUsuarioRepository usuarioRepository) =>
{
    return usuarioRepository.ListarUsuarioPorId(id);
});

app.MapPost("/cadastrar", (Usuario usuario, IUsuarioRepository usuarioRepository) =>
{
    usuarioRepository.CadastrarUsuario(usuario);
});

app.MapPut("/atualizar", (Usuario usuario, IUsuarioRepository usuarioRepository) =>
{
    usuarioRepository.AtualizarUsuario(usuario);
});

app.MapDelete("/excluir/{id}", (int id, IUsuarioRepository usuarioRepository) =>
{
    usuarioRepository.DeletarUsuario(id);
});

app.Run();
#endregion