using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace salesapp_csharp.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            var customers = ReadCustomersFromJson();
            return Ok(customers);
        }

        private List<Customer> ReadCustomersFromJson()
        {
            var jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "customers.json");

            try
            {
                using (var streamReader = new StreamReader(jsonFilePath))
                {
                    var json = streamReader.ReadToEnd();

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    var customers = JsonSerializer.Deserialize<List<Customer>>(json, options);

                    return customers;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, e.g., log or return an error response
                Console.WriteLine($"Error reading customers from JSON: {ex.Message}");
                return new List<Customer>();
            }
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ProductPreference { get; set; }
        public DateTime LastPurchaseDate { get; set; }
        public int NumPurchasesLast30Days { get; set; }
        public double LifetimeTotal { get; set; }
    }
}
