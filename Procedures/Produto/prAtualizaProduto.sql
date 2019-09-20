CREATE PROCEDURE [dbo].[prAtualizaProduto]
(
	@Id	 						INT,
	@nome						VARCHAR(50)=NOTNULL,
	@idCliente					INT=NOTNULL
)
AS
UPDATE Produto
      SET
	Nome					=		@nome,
	idCliente				=		@idCliente
   WHERE Id = @Id
GO