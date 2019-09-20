CREATE PROCEDURE [dbo].[prBuscaTodosDepartamentos]

AS

BEGIN
		SELECT
			ID AS 'ID', 
			Nome AS 'Nome'
		FROM Departamento
		--ORDER BY ID
	END  
GO