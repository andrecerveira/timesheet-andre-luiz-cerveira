CREATE PROCEDURE [dbo].[prBuscaTodosClientes]

AS

BEGIN
		SELECT
			ID AS 'ID', 
			Nome AS 'Nome'
		FROM Cliente
		--ORDER BY ID
	END  
GO