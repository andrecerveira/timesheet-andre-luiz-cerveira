CREATE PROCEDURE [dbo].[prBuscaTodosProdutos]

AS

BEGIN
		SELECT
			ID AS 'ID', 
			Nome AS 'Nome', 
			idCliente AS 'ID Cliente'
		FROM Produto
		--ORDER BY ID
	END  
GO