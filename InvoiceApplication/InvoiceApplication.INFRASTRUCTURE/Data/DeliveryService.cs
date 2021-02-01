using InvoiceApplication.CORE.Entities;
using InvoiceApplication.CORE.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApplication.INFRASTRUCTURE.Data
{
    public class DeliveryService : ISQLDeliveryService
    {
        private readonly IConfiguration _configuration;

        public DeliveryService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<Factura>> GetAllInvoices()
        {
            var data = await Task.Run(() => GetInvoicesFromDb());
            return data;
        }

        private List<Factura> GetInvoicesFromDb()
        {
            List<Factura> result = new List<Factura>();
            string sqlQuery = "SELECT * FROM Facturi;";
            try
            {
                string conString = ConfigurationExtensions.GetConnectionString(_configuration, "Manual");

                using (SqlConnection connection = new SqlConnection(conString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Factura tempEntry = new Factura
                                {
                                    IdFactura = reader.GetInt32(0),
                                    IdLocatie = reader.GetInt32(1),
                                    NumarFactura = reader.GetString(2),
                                    DataFactura = reader.GetDateTime(3),
                                    NumeClient = reader.GetString(4)
                                };
                                result.Add(tempEntry);
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {

            }
            return result;
        }
    }
}
