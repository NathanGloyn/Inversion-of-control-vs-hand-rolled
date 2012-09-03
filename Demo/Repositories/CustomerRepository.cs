using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using AutoMapper;
using DataAccessLayer.Interfaces;
using Demo.Interfaces;
using Demo.Models;

namespace Demo.Repositories
{
    public class CustomerRepository:ICustomerRepository
    {
        private IDataAccess database;
        private IMappingEngine mapper;

        public CustomerRepository(IDataAccess dataAccess, IMappingEngine mappingEngine)
        {
            database = dataAccess;
            mapper = mappingEngine;
        }

        public IEnumerable<Customer> GetAll()
        {
            IEnumerable<Customer> customers;

            using (var reader = database.ExecuteReader(SqlStatements.Customer_SelectAll))
            {
                customers = mapper.DynamicMap<IDataReader, IEnumerable<Customer>>(reader);
            }

            return customers;
        }

        public Customer GetById(string Id)
        {
            Customer customer;

            using (var reader = database.ExecuteReader(SqlStatements.Employee_SelectById,
                                                database.ParameterFactory.Create("@CustomerId", DbType.String, Id)))
            {
                reader.Read();
                IDataRecord record = (IDataRecord)reader;

                customer = mapper.DynamicMap<IDataRecord, Customer>(record);
            }

            return customer;
        }
    }
}