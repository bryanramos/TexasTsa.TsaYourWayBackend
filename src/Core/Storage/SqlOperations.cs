using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TexasTsa.Services.TsaYourWay.Core.Models;

namespace TexasTsa.Services.TsaYourWay.Core.Storage
{
    public static class SqlOperations
    {
        public static void CreateOrInsert(
            this SqlClient client,
            string sqlCommand,
            Dictionary<string, object> parameters)
        {
            if (String.IsNullOrEmpty(sqlCommand)) { throw new ArgumentNullException(nameof(sqlCommand)); }
            if (parameters == null) { throw new ArgumentNullException(nameof(parameters)); }

            SqlConnection connection = null;

            try
            {
                using (connection = new SqlConnection(client.ConnectionString))
                {
                    connection.Open();

                    var command = new SqlCommand(sqlCommand, connection);

                    command.Parameters.AddRange(DictionaryToParameters(parameters));
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public static void CreateCompetitiveEventsTable(
            this SqlClient client,
            string sqlCommand)
        {
            if (String.IsNullOrEmpty(sqlCommand)) { throw new ArgumentNullException(nameof(sqlCommand)); }

            SqlConnection connection = null;

            try
            {
                using (connection = new SqlConnection(client.ConnectionString))
                {
                    connection.Open();

                    var command = new SqlCommand(sqlCommand, connection);

                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public static void DeleteCompetitiveEvent(
            this SqlClient client,
            string sqlCommand,
            string id)
        {
            if (String.IsNullOrEmpty(sqlCommand)) { throw new ArgumentNullException(nameof(sqlCommand)); }
            if (String.IsNullOrEmpty(id)) { throw new ArgumentNullException(nameof(id)); }

            SqlConnection connection = null;

            try
            {
                using (connection = new SqlConnection(client.ConnectionString))
                {
                    connection.Open();

                    var command = new SqlCommand(sqlCommand, connection);
                    command.Parameters.AddWithValue(SqlConstants.IdParameterName, id);
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public static CompetitiveEvent GetCompetitiveEvent(
            this SqlClient client,
            string sqlCommand,
            string id)
        {
            if (String.IsNullOrEmpty(sqlCommand)) { throw new ArgumentNullException(nameof(sqlCommand)); }
            if (String.IsNullOrEmpty(id)) { throw new ArgumentNullException(nameof(id)); }

            SqlConnection connection = null;
            CompetitiveEvent competitiveEvent = null;

            try
            {
                using (connection = new SqlConnection(client.ConnectionString))
                {
                    connection.Open();

                    var command = new SqlCommand(sqlCommand, connection);
                    command.Parameters.AddWithValue(SqlConstants.IdParameterName, id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            competitiveEvent = ReaderToCompetitiveEvent(reader);
                        }
                    }
                }

                return competitiveEvent;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public static List<CompetitiveEvent> GetCompetitiveEvents(
            this SqlClient client,
            string sqlCommand)
        {
            if (String.IsNullOrEmpty(sqlCommand)) { throw new ArgumentNullException(nameof(sqlCommand)); }

            SqlConnection connection = null;
            List<CompetitiveEvent> competitiveEvents = new List<CompetitiveEvent>();

            try
            {
                using (connection = new SqlConnection(client.ConnectionString))
                {
                    connection.Open();

                    var command = new SqlCommand(sqlCommand, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var category = ReaderToCompetitiveEvent(reader);
                            competitiveEvents.Add(category);
                        }
                    }
                }

                return competitiveEvents;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public static SqlParameter[] DictionaryToParameters(Dictionary<string, object> parameters)
        {
            var collection = new List<SqlParameter>();
            foreach (var parameter in parameters)
            {
                collection.Add(new SqlParameter(parameter.Key, parameter.Value ?? DBNull.Value));
            }
            return collection.ToArray();
        }

        public static CompetitiveEvent ReaderToCompetitiveEvent(SqlDataReader reader)
        {
            if (reader == null) { throw new ArgumentNullException(nameof(reader)); }

            return new CompetitiveEvent
            {
                Id = reader["Id"].ToString(),
                CreatedTimestamp = (DateTime)reader["CreatedTimestamp"],
                Name = reader["Name"].ToString(),
                Description = reader["Description"].ToString(),
                Type = reader["Type"].ToString(),
                Challenge = reader["Challenge"].ToString(),
                MiddleSchool = Convert.ToBoolean(reader["MiddleSchool"].ToString()),
                HighSchool = Convert.ToBoolean(reader["HighSchool"].ToString()),
                Individual = Convert.ToBoolean(reader["Individual"].ToString()),
                Team = Convert.ToBoolean(reader["Team"].ToString()),
                SubmittableUri = reader["SubmittableUri"].ToString(),
                Contact = reader["Contact"].ToString(),
                Overview = reader["Overview"].ToString(),
                Details = reader["Details"].ToString(),
                Rules = reader["Rules"].ToString(),
                StemIntegration = reader["StemIntegration"].ToString(),
                RelatedCareers = reader["RelatedCareers"].ToString(),
                Rubric = reader["Rubric"].ToString(),
                Attachments = reader["Attachments"].ToString(),
                ShowAlert = Convert.ToBoolean(reader["ShowAlert"].ToString()),
                Alert = reader["Alert"].ToString(),
                Archive = Convert.ToBoolean(reader["Archive"].ToString()),
                Active = Convert.ToBoolean(reader["Active"].ToString()),
                ObjectID = reader["ObjectID"].ToString(),
                ModifiedTimestamp = (DateTime)reader["ModifiedTimestamp"],
                Version = Int32.Parse(reader["Version"].ToString()),
            };
        }

        public static CompetitiveEvent UpdateCompetitiveEvent(CompetitiveEvent currentEvent, CompetitiveEvent updatedEvent)
        {
            if (currentEvent == null) { throw new ArgumentNullException(nameof(currentEvent)); }
            if (updatedEvent == null) { throw new ArgumentNullException(nameof(updatedEvent)); }

            currentEvent.Active = updatedEvent.Active;

            if (updatedEvent.Attachments != null)
            {
                currentEvent.Attachments = updatedEvent.Attachments;
            }
            if (updatedEvent.Alert != null)
            {
                currentEvent.Alert = updatedEvent.Alert;
            }

            currentEvent.Archive = updatedEvent.Archive;

            if (updatedEvent.Challenge != null)
            {
                currentEvent.Challenge = updatedEvent.Challenge;
            }
            if (updatedEvent.Contact != null)
            {
                currentEvent.Contact = updatedEvent.Contact;
            }
            if (updatedEvent.Description != null)
            {
                currentEvent.Description = updatedEvent.Description;
            }
            if (updatedEvent.Details != null)
            {
                currentEvent.Details = updatedEvent.Details;
            }

            currentEvent.Individual = updatedEvent.Individual;
            currentEvent.HighSchool = updatedEvent.HighSchool;
            currentEvent.MiddleSchool = updatedEvent.MiddleSchool;
            currentEvent.ModifiedTimestamp = DateTime.Now;

            if (updatedEvent.Name != null)
            {
                currentEvent.Name = updatedEvent.Name;
            }
            if (updatedEvent.Overview != null)
            {
                currentEvent.Overview = updatedEvent.Overview;
            }
            if (updatedEvent.RelatedCareers != null)
            {
                currentEvent.RelatedCareers = updatedEvent.RelatedCareers;
            }
            if (updatedEvent.Rubric != null)
            {
                currentEvent.Rubric = updatedEvent.Rules;
            }
            if (updatedEvent.Rules != null)
            {
                currentEvent.Rules = updatedEvent.Rules;
            }

            currentEvent.ShowAlert = updatedEvent.ShowAlert;

            if (updatedEvent.StemIntegration != null)
            {
                currentEvent.StemIntegration = updatedEvent.StemIntegration;
            }
            if (updatedEvent.SubmittableUri != null)
            {
                currentEvent.SubmittableUri = updatedEvent.SubmittableUri;
            }

            currentEvent.Team = updatedEvent.Team;

            if (updatedEvent.Type != null)
            {
                currentEvent.Type = updatedEvent.Type;
            }

            currentEvent.Version += 1;

            return currentEvent;
        }
    }
}
