using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TimeSheet.Domain.Entities;

namespace TimeSheet.Infra.Data.Repositories
{
    public class CampanhaRepository
    {
        private readonly string _procedureNameAdd = "prInsereCampanha";
        private readonly string _procedureNameGetAll = "prBuscaTodasCampanhas";
        private readonly string _procedureNameUpdate = "prAtualizaCampanha";
        private readonly string _procedureNameDelete = "prExcluiCampanha";
        private readonly string _procedureNameGetById = "prBuscaCampanhaPorID";

        private SqlConnection _con;

        private void Connection()
        {
            _con = new SqlConnection(ConfigurationManager.ConnectionStrings[Constantes.stringDeConexao].ToString());
        }

        public bool Add(Campanha campanha)
        {
            Connection();
            int id = 0;

            using (SqlCommand command = new SqlCommand(_procedureNameAdd, _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@nome", campanha.Nome);
                command.Parameters.AddWithValue("@idProduto", campanha.ProdutoId);

                _con.Open();
                id = command.ExecuteNonQuery();
            }
            _con.Close();
            return id != 0;
        }

        public bool Update(Campanha campanha)
        {
            Connection();
            int id = 0;

            using (SqlCommand command = new SqlCommand(_procedureNameUpdate, _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", campanha.CampanhaId);
                command.Parameters.AddWithValue("@nome", campanha.Nome);
                command.Parameters.AddWithValue("@idProduto", campanha.ProdutoId);

                _con.Open();
                id = command.ExecuteNonQuery();
            }
            _con.Close();
            return id != 0;
        }

        public void Delete(int id)
        {
            Connection();

            using (SqlCommand command = new SqlCommand(_procedureNameDelete, _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);

                _con.Open();
                id = command.ExecuteNonQuery();
            }
            _con.Close();
        }

        public IEnumerable<Campanha> GetAll()
        {
            Connection();
            List<Campanha> campanhas = new List<Campanha>();

            using (SqlCommand command = new SqlCommand(_procedureNameGetAll, _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                _con.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Campanha campanha = new Campanha()
                    {
                        CampanhaId = Convert.ToInt32(reader["Id"]),
                        Nome = Convert.ToString(reader["Nome"]),
                        ProdutoId = Convert.ToInt32(reader["ID Produto"])
                    };
                    campanha.ProdutoDaCampanha = new ProdutoRepository().GetById(campanha.ProdutoId);
                    campanhas.Add(campanha);
                }
                _con.Close();
                return campanhas;
            }
        }

        public Campanha GetById(int id)
        {
            Connection();
            Campanha campanha = new Campanha();

            using (SqlCommand command = new SqlCommand(_procedureNameGetById, _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);

                _con.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    campanha = new Campanha()
                    {
                        CampanhaId = Convert.ToInt32(reader["Id"]),
                        Nome = Convert.ToString(reader["Nome"]),
                        ProdutoId = Convert.ToInt32(reader["ID Produto"])
                    };
                }
                _con.Close();
                return campanha;
            }
        }
    }
}
