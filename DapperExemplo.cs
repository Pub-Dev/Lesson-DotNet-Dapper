using Dapper;
using Lesson_DotNet_Dapper.Entities;
using System.Data.SqlClient;

namespace Lesson_DotNet_Dapper;

public class DapperExemplo
{
    private string _connectionString;

    public DapperExemplo(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IEnumerable<Usuario> ListarUsuarios()
    {
        var queryCommand = @"
            SELECT
                UsuarioID,
                Nome,
                Sobrenome,
                Email,
                DataCriacao
            FROM dbo.tblUsuario";

        using var connection = new SqlConnection(_connectionString);

        return connection.Query<Usuario>(queryCommand);
    }

    public Usuario? ObterUsuario(int usuarioID)
    {
        var queryCommand = @"
            SELECT
                UsuarioID,
                Nome,
                Sobrenome,
                Email,
                DataCriacao
            FROM dbo.tblUsuario
            WHERE
                UsuarioID = @UsuarioID";

        using var connection = new SqlConnection(_connectionString);

        return connection.QueryFirstOrDefault<Usuario>(
            queryCommand,
            new
            {
                UsuarioID = usuarioID
            });
    }

    public void InserirUsuario(string nome, string sobrenome, string email)
    {
        var insertCommand = @"
            INSERT INTO dbo.tblUsuario(Nome, Sobrenome, Email)
            VALUES(@Nome, @Sobrenome, @Email)";

        using var connection = new SqlConnection(_connectionString);

        connection.Execute(
            insertCommand,
            new
            {
                Nome = nome,
                Sobrenome = sobrenome,
                Email = email
            });
    }

    public void AtualizarEmailUsuario(int usuarioID, string email)
    {
        var updateCommand = @"
            UPDATE dbo.tblUsuario
            SET
                Email = @Email
            WHERE
                UsuarioID = @UsuarioID";

        using var connection = new SqlConnection(_connectionString);

        connection.Execute(
            updateCommand,
            new
            {
                UsuarioID = usuarioID,
                Email = email
            });
    }
}
