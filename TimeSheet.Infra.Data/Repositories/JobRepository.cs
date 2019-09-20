using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TimeSheet.Domain.Entities;

namespace TimeSheet.Infra.Data.Repositories
{
    public class JobRepository
    {
        private readonly string _procedureNameAdd = "prInsereJob";
        private readonly string _procedureNameGetAll = "prBuscaTodosJobs";
        private readonly string _procedureNameUpdate = "prAtualizaJob";
        private readonly string _procedureNameDelete = "prExcluiJob";
        private readonly string _procedureNameGetById = "prBuscaJobPorID";

        private SqlConnection _con;

        private void Connection()
        {
            _con = new SqlConnection(ConfigurationManager.ConnectionStrings[Constantes.stringDeConexao].ToString());
        }

        public bool Add(Job job)
        {
            Connection();
            int id = 0;

            using (SqlCommand command = new SqlCommand(_procedureNameAdd, _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@nome", job.Nome);
                command.Parameters.AddWithValue("@idCampanha", job.CampanhaId);

                _con.Open();
                id = command.ExecuteNonQuery();
            }
            _con.Close();
            return id != 0;
        }

        public bool Update(Job job)
        {
            Connection();
            int id = 0;

            using (SqlCommand command = new SqlCommand(_procedureNameUpdate, _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", job.JobId);
                command.Parameters.AddWithValue("@nome", job.Nome);
                command.Parameters.AddWithValue("@idCampanha", job.CampanhaId);

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

        public IEnumerable<Job> GetAll()
        {
            Connection();
            List<Job> jobs = new List<Job>();

            using (SqlCommand command = new SqlCommand(_procedureNameGetAll, _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                _con.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Job job = new Job()
                    {
                        JobId = Convert.ToInt32(reader["Id"]),
                        Nome = Convert.ToString(reader["Nome"]),
                        CampanhaId = Convert.ToInt32(reader["ID Campanha"])
                    };
                    job.CampanhaDoJob  = new CampanhaRepository().GetById(job.CampanhaId);
                    jobs.Add(job);
                }
                _con.Close();
                return jobs;
            }
        }

        public Job GetById(int id)
        {
            Connection();
            Job job = new Job();

            using (SqlCommand command = new SqlCommand(_procedureNameGetById, _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);

                _con.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    job = new Job()
                    {
                        JobId = Convert.ToInt32(reader["Id"]),
                        Nome = Convert.ToString(reader["Nome"]),
                        CampanhaId = Convert.ToInt32(reader["ID Campanha"])
                    };
                }
                _con.Close();
                return job;
            }
        }
    }
}
