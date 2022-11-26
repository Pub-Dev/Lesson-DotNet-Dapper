using Lesson_DotNet_Dapper.Entities;
using System.Data.SqlClient;

namespace Lesson_DotNet_Dapper;

public class ADOExemplo
{
    private string _connectionString;

    public ADOExemplo(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IEnumerable<Usuario> ListarUsuarios()
    {
        using var connection = new SqlConnection(_connectionString);

        var queryCommand = @"
            SELECT
                UsuarioID,
                Nome,
                Sobrenome,
                Email,
                DataCriacao
            FROM dbo.tblUsuario";

        var command = new SqlCommand(queryCommand, connection);

        connection.Open();

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return new Usuario()
            {
                UsuarioID = Convert.ToInt32(reader["UsuarioID"]),
                Nome = Convert.ToString(reader["Nome"]) ?? "",
                Sobrenome = Convert.ToString(reader["Sobrenome"]),
                Email = Convert.ToString(reader["Email"]),
                DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
            };
        }

        reader.Close();

        connection.Close();
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

        var command = new SqlCommand(queryCommand, connection);

        command.Parameters.AddWithValue("@UsuarioID", usuarioID);

        SqlDataReader reader = command.ExecuteReader();

        var usuario = default(Usuario);

        if (reader.Read())
        {
            usuario = new Usuario()
            {
                UsuarioID = Convert.ToInt32(reader["UsuarioID"]),
                Nome = Convert.ToString(reader["Nome"]) ?? "",
                Sobrenome = Convert.ToString(reader["Sobrenome"]),
                Email = Convert.ToString(reader["Email"]),
                DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
            };
        }

        reader.Close();

        connection.Close();

        return usuario;
    }

    public void InserirUsuario(string nome, string sobrenome, string email)
    {
        var insertCommand = @"
            INSERT INTO dbo.tblUsuario(Nome, Sobrenome, Email)
            VALUES(@Nome, @Sobrenome, @Email)";

        using var connection = new SqlConnection(_connectionString);

        var command = new SqlCommand(insertCommand, connection);

        command.Parameters.AddWithValue("@Nome", nome);
        command.Parameters.AddWithValue("@Sobrenome", sobrenome);
        command.Parameters.AddWithValue("@Email", email);

        connection.Open();

        command.ExecuteNonQuery();

        connection.Close();
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

        var command = new SqlCommand(updateCommand, connection);

        command.Parameters.AddWithValue("@UsuarioID", usuarioID);
        command.Parameters.AddWithValue("@Email", email);

        connection.Open();

        command.ExecuteNonQuery();

        connection.Close();
    }
}
