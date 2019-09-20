CREATE PROCEDURE [dbo].[prExcluiCliente]
(
	@Id		INT
)
AS
	DELETE FROM Cliente WHERE Id = @ID
GO