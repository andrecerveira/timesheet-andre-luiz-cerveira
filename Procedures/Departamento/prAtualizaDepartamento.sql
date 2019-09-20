CREATE PROCEDURE [dbo].[prAtualizaDepartamento]
(
	@Id	 						INT,
	@nome						VARCHAR(50)=NOTNULL
)
AS
UPDATE Departamento
      SET
	Nome					=		@nome
   WHERE Id = @Id
GO