using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TimeSheet.Domain.Entities;

namespace TimeSheet.Infra.Data.Repositories
{
    public class ClienteRepository
    {
        private readonly string _procedureNameAdd = "prInsereCliente";
        private readonly string _procedureNameGetAll = "prBuscaTodosClientes";
        private readonly string _procedureNameUpdate = "prAtualizaCliente";
        private readonly string _procedureNameDelete = "prExcluiCliente";
        private readonly string _procedureNameGetById = "prBuscaClientePorID";

        private SqlConnection _con;

        private void Connection()
        {
            _con = new SqlConnection(ConfigurationManager.ConnectionStrings[Constantes.stringDeConexao].ToString());
        }

        public bool Add(Cliente cliente)
        {
            Connection();
            int id = 0;

            using (SqlCommand command = new SqlCommand(_procedureNameAdd, _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@nome", cliente.Nome);

                _con.Open();
                id = command.ExecuteNonQuery();
            }
            _con.Close();
            return id != 0;
        }

        public bool Update(Cliente cliente)
        {
            Connection();
            int id = 0;

            using (SqlCommand command = new SqlCommand(_procedureNameUpdate, _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", cliente.ClienteId);
                command.Parameters.AddWithValue("@nome", cliente.Nome);

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

        public IEnumerable<Cliente> GetAll()
        {
            Connection();
            List<Cliente> clientes = new List<Cliente>();

            using (SqlCommand command = new SqlCommand(_procedureNameGetAll, _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                _con.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Cliente cliente = new Cliente()
                    {
                        ClienteId = Convert.ToInt32(reader["Id"]),
                        Nome = Convert.ToString(reader["Nome"])
                    };
                    clientes.Add(cliente);
                }
                _con.Close();
                return clientes;
            }
        }

        public Cliente GetById(int id)
        {
            Connection();
            Cliente cliente = new Cliente();

            using (SqlCommand command = new SqlCommand(_procedureNameGetById, _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);

                _con.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    cliente = new Cliente()
                    {
                        ClienteId = Convert.ToInt32(reader["Id"]),
                        Nome = Convert.ToString(reader["Nome"])
                    };
                }
                _con.Close();
                return cliente;
            }
        }
    }
}
