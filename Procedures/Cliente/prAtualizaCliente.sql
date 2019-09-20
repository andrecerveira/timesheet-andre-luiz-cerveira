CREATE PROCEDURE [dbo].[prAtualizaCliente]
(
	@Id	 						INT,
	@nome						VARCHAR(50)=NOTNULL
)
AS
UPDATE Cliente
      SET
	Nome					=		@nome
   WHERE Id = @Id
GO