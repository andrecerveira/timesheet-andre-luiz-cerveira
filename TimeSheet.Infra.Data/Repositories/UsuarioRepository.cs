using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TimeSheet.Domain.Entities;

namespace TimeSheet.Infra.Data.Repositories
{
    public class UsuarioRepository
    {
        private readonly string _procedureNameAdd = "prInsereUsuario";
        private readonly string _procedureNameGetAll = "prBuscaTodosUsuarios";
        private readonly string _procedureNameUpdate = "prAtualizaUsuario";
        private readonly string _procedureNameDelete = "prExcluiUsuario";
        private readonly string _procedureNameGetById = "prBuscaUsuarioPorID";

        private SqlConnection _con;

        private void Connection()
        {
            _con = new SqlConnection(ConfigurationManager.ConnectionStrings[Constantes.stringDeConexao].ToString());
        }

        public bool Add(Usuario usuario)
        {
            Connection();
            int id = 0;

            using (SqlCommand command = new SqlCommand(_procedureNameAdd, _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@nome", usuario.Nome);
                command.Parameters.AddWithValue("@idDepartamento", usuario.DepartamentoId);

                _con.Open();
                id = command.ExecuteNonQuery();
            }
            _con.Close();
            return id != 0;
        }

        public bool Update(Usuario usuario)
        {
            Connection();
            int id = 0;

            using (SqlCommand command = new SqlCommand(_procedureNameUpdate, _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", usuario.UsuarioId);
                command.Parameters.AddWithValue("@nome", usuario.Nome);
                command.Parameters.AddWithValue("@idDepartamento", usuario.DepartamentoId);

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

        public IEnumerable<Usuario> GetAll()
        {
            Connection();
            List<Usuario> usuarios = new List<Usuario>();

            using (SqlCommand command = new SqlCommand(_procedureNameGetAll, _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                _con.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Usuario usuario = new Usuario()
                    {
                        UsuarioId = Convert.ToInt32(reader["Id"]),
                        Nome = Convert.ToString(reader["Nome"]),
                        DepartamentoId = Convert.ToInt32(reader["ID Departamento"])
                    };
                    usuario.DepartamentoDoUsuario = new DepartamentoRepository().GetById(usuario.DepartamentoId);
                    usuarios.Add(usuario);
                }
                _con.Close();
                return usuarios;
            }
        }

        public Usuario GetById(int id)
        {
            Connection();
            Usuario usuario = new Usuario();

            using (SqlCommand command = new SqlCommand(_procedureNameGetById, _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);

                _con.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    usuario = new Usuario()
                    {
                        UsuarioId = Convert.ToInt32(reader["Id"]),
                        Nome = Convert.ToString(reader["Nome"]),
                        DepartamentoId = Convert.ToInt32(reader["ID Departamento"])
                    };
                }
                _con.Close();
                return usuario;
            }
        }
    }
}
