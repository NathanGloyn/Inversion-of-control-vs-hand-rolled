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
    public class EmployeeRepository : IEmployeeRepository
    {
        IDataAccess database;
        IMappingEngine mapper;

        public EmployeeRepository(IDataAccess dataAccess, IMappingEngine mappingEngine)
        {
            database = dataAccess;
            mapper = mappingEngine;
        }

        public IEnumerable<Employee> GetAll()
        {
            IEnumerable<Employee> employees;

            using (var reader = database.ExecuteReader(SqlStatements.Employee_SelectAll))
            {
                employees = mapper.DynamicMap<IDataReader, IEnumerable<Employee>>(reader);
            }

            return employees;
        }

        public Employee GetById(int Id)
        {
            Employee employee;

            using (var reader = database.ExecuteReader(SqlStatements.Employee_SelectById,
                                                database.ParameterFactory.Create("@EmployeeId", DbType.Int32, Id)))
            {
                reader.Read();
                IDataRecord record = (IDataRecord)reader;

                employee = mapper.DynamicMap<IDataRecord, Employee>(record);
            }

            return employee;
        }
    }
}