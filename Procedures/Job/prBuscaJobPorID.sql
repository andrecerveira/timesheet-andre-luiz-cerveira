CREATE PROCEDURE [dbo].[prBuscaJobPorID]
(
	@Id 		INT
)

AS

	BEGIN
		      SELECT 
				ID AS 'ID', 
				Nome AS 'Nome', 
				idCampanha AS 'ID Campanha'
		      FROM Job
		     WHERE Id = @Id
	END
GO