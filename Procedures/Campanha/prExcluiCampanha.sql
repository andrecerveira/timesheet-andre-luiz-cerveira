CREATE PROCEDURE [dbo].[prExcluiCampanha]
(
	@Id		INT
)
AS
	DELETE FROM Campanha WHERE Id = @ID
GO