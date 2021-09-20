using MiSistema.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSistema.Data
{
    public class ArtistDA : BaseConnection
    {
        public int Count()
        {
            var retorno = 0;
            var sql = "SELECT COUNT(1) FROM Artist NOLOCK";
            /* 1 - Creando una instancia de Db Connection */
            using (var dbConnection = this.GetConnection())
            {
                /* 2: Crear un objeto comman */
                IDbCommand cmd = new SqlCommand(sql);

                cmd.Connection = dbConnection;
                dbConnection.Open();
                retorno = (int)cmd.ExecuteScalar(); /* Abre conecion a la base de datos*/
            }

            return retorno;

        }

        public List<Artist> Gets()
        {
            var retorno = new List<Artist>();
            var sql = "SELECT ArtistId, Name FROM Artist NOLOCK";
            using (var dbConnection = this.GetConnection())
            {
                IDbCommand cmd = new SqlCommand(sql);
                cmd.Connection = dbConnection;
                dbConnection.Open();

                var reader = cmd.ExecuteReader();
                var indice = 0;
                while (reader.Read())
                {
                    var artist = new Artist();
                    indice = reader.GetOrdinal("ArtistId");
                    artist.ArtistID = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Name");
                    artist.Name = reader.GetString(indice);

                    retorno.Add(artist);
                }

            }
            return retorno;
        }
        public List<Artist> Gets(string filterByName)
        {
            var retorno = new List<Artist>();
            var sql = "usp_GetArtist";
            using (var dbConnection = this.GetConnection())
            {
                IDbCommand command = new SqlCommand(sql);
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = dbConnection;

                command.Parameters.Add(new SqlParameter("@name", filterByName));

                dbConnection.Open();

                var reader = command.ExecuteReader();
                var indice = 0;
                while (reader.Read())
                {
                    var artist = new Artist();
                    indice = reader.GetOrdinal("ArtistId");
                    artist.ArtistID = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Name");
                    artist.Name = reader.GetString(indice);

                    retorno.Add(artist);
                }

            }
            return retorno;
        }
        public Artist GetOne(int id)
        {
            var artist = new Artist();
            var sql = "usp_GetOne";
            using (var dbConnection = this.GetConnection())
            {
                IDbCommand command = new SqlCommand(sql);
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = dbConnection;

                command.Parameters.Add(new SqlParameter("@artistId", id));

                dbConnection.Open();

                var reader = command.ExecuteReader();
                var indice = 0;
                while (reader.Read())
                {
                    
                    indice = reader.GetOrdinal("ArtistId");
                    artist.ArtistID = reader.GetInt32(indice);
                    indice = reader.GetOrdinal("Name");
                    artist.Name = reader.GetString(indice);
                   
                }

            }
            return artist;
        }
        public int Insert(Artist artist)
        {
            var retorno = 0;
            var sql = "usp_InsertArtist";


            using (var dbConnection = this.GetConnection())
            {
                dbConnection.Open();

                var transaction = dbConnection.BeginTransaction();

                try
                {
                    IDbCommand command = new SqlCommand(sql);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Transaction = transaction;
                    command.Connection = dbConnection;
                    command.Parameters.Add(new SqlParameter("@name", artist.Name));


                    retorno = Convert.ToInt32(command.ExecuteScalar());

                    transaction.Commit();
                }
                catch (Exception ex)
                {

                    transaction.Rollback();
                }
            }
            return retorno;
        }
        public bool Update(Artist artist)
        {
            var retorno = false;
            var sql = "usp_UpdateArtist";

            using (var dbConnection = this.GetConnection())
            {
                IDbCommand command = new SqlCommand(sql);
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = dbConnection;
                command.Parameters.Add(new SqlParameter("@name", artist.Name));
                command.Parameters.Add(new SqlParameter("@artistId", artist.ArtistID));
                dbConnection.Open();

                retorno = command.ExecuteNonQuery() > 0;
            }
            return retorno;
        }

        public bool Delete(int artistId)
        {
            var retorno = false;
            var sql = "usp_DeleteArtist";

            using (var dbConnection = this.GetConnection())
            {
                IDbCommand command = new SqlCommand(sql);
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = dbConnection;
                command.Parameters.Add(new SqlParameter("@artistId", artistId));
                dbConnection.Open();

                retorno = command.ExecuteNonQuery() > 0;
            }
            return retorno;
        }
    }
}
