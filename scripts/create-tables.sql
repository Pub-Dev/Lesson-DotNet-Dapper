CREATE TABLE tblUsuario
(
	UsuarioID INT IDENTITY(1,1) NOT NULL,
	Nome NVARCHAR(200) NOT NULL,
	Sobrenome NVARCHAR(200) NOT NULL,
	Email NVARCHAR(200),
	DataCriacao DATETIME DEFAULT(GETDATE()),
	CONSTRAINT [PK_tblUsuario_UsuarioID] PRIMARY KEY(UsuarioID)
)

INSERT INTO tblUsuario(Nome, Sobrenome, Email)
VALUES
	('Mayara', 'Toku', NULL),
	('João', 'Silva', NULL),
	('Alef', 'Carlos', NULL)