CREATE PROCEDURE [dbo].[prExcluiJob]
(
	@Id		INT
)
AS
	DELETE FROM Job WHERE Id = @ID
GO