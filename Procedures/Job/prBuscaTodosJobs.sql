CREATE PROCEDURE [dbo].[prBuscaTodosJobs]

AS

BEGIN
		SELECT
			ID AS 'ID', 
			Nome AS 'Nome', 
			idCampanha AS 'ID Campanha'
		FROM Job
		--ORDER BY ID
	END  
GO