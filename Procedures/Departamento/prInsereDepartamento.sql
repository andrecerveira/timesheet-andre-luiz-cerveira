CREATE PROCEDURE [dbo].[prInsereDepartamento]
(
	@nome						VARCHAR(50)=NOTNULL
)

AS

INSERT Departamento
( 
	Nome
)

OUTPUT Inserted.Id

	VALUES 
( 
	@nome
)
GO