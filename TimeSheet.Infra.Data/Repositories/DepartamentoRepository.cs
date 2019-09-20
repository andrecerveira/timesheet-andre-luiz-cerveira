using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TimeSheet.Domain.Entities;

namespace TimeSheet.Infra.Data.Repositories
{
    public class DepartamentoRepository
    {
        private readonly string _procedureNameAdd = "prInsereDepartamento";
        private readonly string _procedureNameGetAll = "prBuscaTodosDepartamentos";
        private readonly string _procedureNameUpdate = "prAtualizaDepartamento";
        private readonly string _procedureNameDelete = "prExcluiDepartamento";
        private readonly string _procedureNameGetById = "prBuscaDepartamentoPorID";

        private SqlConnection _con;

        private void Connection()
        {
            _con = new SqlConnection(ConfigurationManager.ConnectionStrings[Constantes.stringDeConexao].ToString());
        }

        public bool Add(Departamento departamento)
        {
            Connection();
            int id = 0;

            using (SqlCommand command = new SqlCommand(_procedureNameAdd, _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@nome", departamento.Nome);

                _con.Open();
                id = command.ExecuteNonQuery();
            }
            _con.Close();
            return id != 0;
        }

        public bool Update(Departamento departamento)
        {
            Connection();
            int id = 0;

            using (SqlCommand command = new SqlCommand(_procedureNameUpdate, _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", departamento.DepartamentoId);
                command.Parameters.AddWithValue("@nome", departamento.Nome);

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

        public IEnumerable<Departamento> GetAll()
        {
            Connection();
            List<Departamento> departamentos = new List<Departamento>();

            using (SqlCommand command = new SqlCommand(_procedureNameGetAll, _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                _con.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Departamento departamento = new Departamento()
                    {
                        DepartamentoId = Convert.ToInt32(reader["Id"]),
                        Nome = Convert.ToString(reader["Nome"]),
                    };
                    departamentos.Add(departamento);
                }
                _con.Close();
                return departamentos;
            }
        }

        public Departamento GetById(int id)
        {
            Connection();
            Departamento departamento = new Departamento();

            using (SqlCommand command = new SqlCommand(_procedureNameGetById, _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);

                _con.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    departamento = new Departamento()
                    {
                        DepartamentoId = Convert.ToInt32(reader["Id"]),
                        Nome = Convert.ToString(reader["Nome"])
                    };
                }
                _con.Close();
                return departamento;
            }
        }
    }
}
