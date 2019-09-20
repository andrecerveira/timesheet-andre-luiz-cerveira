CREATE PROCEDURE [dbo].[prExcluiUsuario]
(
	@Id		INT
)
AS
	DELETE FROM Usuario WHERE Id = @ID
GO