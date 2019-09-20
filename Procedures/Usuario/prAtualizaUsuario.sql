CREATE PROCEDURE [dbo].[prAtualizaUsuario]
(
	@Id	 						INT,
	@nome						VARCHAR(50)=NOTNULL,
	@idDepartamento				INT=NOTNULL
)
AS
UPDATE Usuario
      SET
	Nome					=		@nome,
	idDepartamento			=		@idDepartamento
   WHERE Id = @Id
GO