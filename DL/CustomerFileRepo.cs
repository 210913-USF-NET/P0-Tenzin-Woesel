using System;
using System.Collections.Generic;
using Models;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace DL
{
    public class CustomerFileRepo : ICustomerRepo
    {
        private const string filePath = "../DL/Customers.json";

        private string jsonString;
        public Customer AddCustomer(Customer customer)
        {   
            //Get all customer from the file as Lists
            List<Customer> allCustomer = GetAllCustomers();
            allCustomer.Add(customer);

            jsonString = JsonSerializer.Serialize(allCustomer);
            File.WriteAllText(filePath, jsonString);
            return customer;
        }

        public void DeleteCustomer(string email)
        {
            throw new System.NotImplementedException();
        }

        public List<Customer> GetAllCustomers()
        {
            //read the file from the file path
            jsonString = File.ReadAllText(filePath);
            //translate the serialized string into List<Customer> object!
            return JsonSerializer.Deserialize<List<Customer>>(jsonString);
        }

        public void UpdateCustomer(Customer customer)
        {
            throw new System.NotImplementedException();
        }


        public Customer GetCustomer(string email)
        {
            throw new System.NotImplementedException();
        }
    }
}