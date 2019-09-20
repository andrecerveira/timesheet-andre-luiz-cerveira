CREATE PROCEDURE [dbo].[prAtualizaCampanha]
(
	@Id	 						INT,
	@nome						VARCHAR(50)=NOTNULL,
	@idProduto					INT=NOTNULL
)
AS
UPDATE Campanha
      SET
	Nome					=		@nome,
	idProduto				=		@idProduto
   WHERE Id = @Id
GO