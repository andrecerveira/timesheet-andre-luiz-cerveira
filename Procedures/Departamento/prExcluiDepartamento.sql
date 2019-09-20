CREATE PROCEDURE [dbo].[prExcluiDepartamento]
(
	@Id		INT
)
AS
	DELETE FROM Departamento WHERE Id = @ID
GO