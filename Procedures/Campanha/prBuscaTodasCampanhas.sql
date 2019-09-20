CREATE PROCEDURE [dbo].[prBuscaTodasCampanhas]

AS

BEGIN
		SELECT
			ID AS 'ID', 
			Nome AS 'Nome', 
			idProduto AS 'ID Produto'
		FROM Campanha
		--ORDER BY ID
	END  
GO