using System;
using System.Data.SqlClient;

namespace TexasTsa.Services.TsaYourWay.Core.Storage
{
    public class SqlClient
    {
        public string ConnectionString { get; set; }

        public SqlClient()
        {
            this.ConnectionString = new SqlConnectionStringBuilder
            {
                DataSource = Environment.GetEnvironmentVariable(ServiceConfiguration.Source),
                UserID = Environment.GetEnvironmentVariable(ServiceConfiguration.UserId),
                Password = Environment.GetEnvironmentVariable(ServiceConfiguration.Password),
                InitialCatalog = Environment.GetEnvironmentVariable(ServiceConfiguration.InitialCatalog)
            }.ToString();
        }
    }
}
