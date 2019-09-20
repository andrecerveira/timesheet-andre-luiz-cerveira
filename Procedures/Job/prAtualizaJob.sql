CREATE PROCEDURE [dbo].[prAtualizaJob]
(
	@Id	 						INT,
	@nome						VARCHAR(50)=NOTNULL,
	@idCampanha					INT=NOTNULL
)
AS
UPDATE Job
      SET
	Nome					=		@nome,
	idCampanha				=		@idCampanha
   WHERE Id = @Id
GO