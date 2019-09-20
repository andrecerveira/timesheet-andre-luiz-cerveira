using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TimeSheet.Domain.Entities;

namespace TimeSheet.Infra.Data.Repositories
{
    public class ProdutoRepository
    {
        private readonly string _procedureNameAdd = "prInsereProduto";
        private readonly string _procedureNameGetAll = "prBuscaTodosProdutos";
        private readonly string _procedureNameUpdate = "prAtualizaProduto";
        private readonly string _procedureNameDelete = "prExcluiProduto";
        private readonly string _procedureNameGetById = "prBuscaProdutoPorID";

        private SqlConnection _con;

        private void Connection()
        {
            _con = new SqlConnection(ConfigurationManager.ConnectionStrings[Constantes.stringDeConexao].ToString());
        }

        public bool Add(Produto produto)
        {
            Connection();
            int id = 0;

            using (SqlCommand command = new SqlCommand(_procedureNameAdd, _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@nome", produto.Nome);
                command.Parameters.AddWithValue("@idCliente", produto.ClienteId);

                _con.Open();
                id = command.ExecuteNonQuery();
            }
            _con.Close();
            return id != 0;
        }

        public bool Update(Produto produto)
        {
            Connection();
            int id = 0;

            using (SqlCommand command = new SqlCommand(_procedureNameUpdate, _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", produto.ProdutoId);
                command.Parameters.AddWithValue("@nome", produto.Nome);
                command.Parameters.AddWithValue("@idCliente", produto.ClienteId);

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

        public IEnumerable<Produto> GetAll()
        {
            Connection();
            List<Produto> produtos = new List<Produto>();

            using (SqlCommand command = new SqlCommand(_procedureNameGetAll, _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                _con.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Produto produto = new Produto()
                    {
                        ProdutoId = Convert.ToInt32(reader["Id"]),
                        Nome = Convert.ToString(reader["Nome"]),
                        ClienteId = Convert.ToInt32(reader["ID Cliente"])
                    };
                    produto.ClienteDoProduto = new ClienteRepository().GetById(produto.ClienteId);
                    produtos.Add(produto);
                }
                _con.Close();
                return produtos;
            }
        }

        public Produto GetById(int id)
        {
            Connection();
            Produto produto = new Produto();

            using (SqlCommand command = new SqlCommand(_procedureNameGetById, _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);

                _con.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    produto = new Produto()
                    {
                        ProdutoId = Convert.ToInt32(reader["Id"]),
                        Nome = Convert.ToString(reader["Nome"]),
                        ClienteId = Convert.ToInt32(reader["ID Cliente"])
                    };
                }
                _con.Close();
                return produto;
            }
        }
    }
}
