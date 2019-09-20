CREATE PROCEDURE [dbo].[prInsereUsuario]
(
	@nome						VARCHAR(50)=NOTNULL,
	@idDepartamento				INT=NOTNULL
)

AS

INSERT Usuario
( 
	Nome,
	idDepartamento
)

OUTPUT Inserted.Id

	VALUES 
( 
	@nome,
	@idDepartamento
)
GO