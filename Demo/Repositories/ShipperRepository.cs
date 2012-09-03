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
    public class ShipperRepository:IShipperRepository
    {
        private IDataAccess database;
        private IMappingEngine mapper;

        public ShipperRepository(IDataAccess dataAccess, IMappingEngine mappingEngine)
        {
            database = dataAccess;
            mapper = mappingEngine;
        }

        public Shipper GetById(int Id)
        {
            Shipper shipper;

            using (var reader = database.ExecuteReader(SqlStatements.Shippers_SelectById, database.ParameterFactory.Create("@ShipperId",DbType.Int32,Id)))
            {
                reader.Read();
                IDataRecord record = (IDataRecord)reader;

                shipper = mapper.DynamicMap<IDataRecord, Shipper>(record);
            }

            return shipper;
        }

        public IEnumerable<Shipper> GetAll()
        {
            using (var reader = database.ExecuteReader(SqlStatements.Shippers_SelectAll))
            {
                return mapper.DynamicMap<IDataReader, IEnumerable<Shipper>>(reader);
            }            
        }
    }
}