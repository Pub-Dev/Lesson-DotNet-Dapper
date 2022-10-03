using Lesson_DotNet_Dapper;

var connectionString = "Server=localhost,1433;Database=pub-dev;User Id=sa;Password=Pass@word";

void ADO()
{
    var adoExemplo = new ADOExemplo(connectionString!);

    // Inserindo registro usando ADO.NET
    adoExemplo.InserirUsuario("Joao", "Lima", "jl@pubdev.com");

    // Listando registros usando ADO.NET
    var usuarios = adoExemplo.ListarUsuarios();

    foreach (var usuario in usuarios)
    {
        Console.WriteLine(usuario);
    }

    // Obtendo usuario usando ADO.NE
    var primeiroUsuario = adoExemplo.ObterUsuario(1);

    Console.WriteLine(primeiroUsuario);

    // Atualizando email usuario usando ADO.NE
    adoExemplo.AtualizarEmailUsuario(1, "seinscreva@pubdev.com");

    var usuarioAtualizado = adoExemplo.ObterUsuario(1);

    Console.WriteLine(usuarioAtualizado);
}

void Dapper()
{
    var dapperExemplo = new DapperExemplo(connectionString!);

    // Inserindo registro usando Dapper
    dapperExemplo.InserirUsuario("Joao", "Dapper", "jl@pubdev.com");

    // Listando registros usando Dapper
    var usuarios = dapperExemplo.ListarUsuarios();

    foreach (var usuario in usuarios)
    {
        Console.WriteLine(usuario);
    }

    // Obtendo usuario usando ADO.NE
    var primeiroUsuario = dapperExemplo.ObterUsuario(1);

    Console.WriteLine(primeiroUsuario);

    // Atualizando email usuario usando Dapper
    dapperExemplo.AtualizarEmailUsuario(1, "deixe-seu-comentario-@pubdev.com");

    var usuarioAtualizado = dapperExemplo.ObterUsuario(1);

    Console.WriteLine(usuarioAtualizado);
}

ADO();

Dapper();