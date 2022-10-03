namespace Lesson_DotNet_Dapper.Entities;

public class Usuario
{
    public int UsuarioID { get; set; }
    public string? Nome { get; set; }
    public string? Sobrenome { get; set; }
    public string? Email { get; set; }
    public DateTime DataCriacao { get; set; }

    public override string ToString()
    {
        return $@"
UsuarioID = {UsuarioID}
Nome = {Nome}
Sobrenome = {Sobrenome}
Email = {Email}
DataCriacao = {DataCriacao}";
    }
}
