using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using AutoMapper;
using DataAccessLayer.Interfaces;
using Demo.Interfaces;
using Demo.Models;
using Demo.ViewModel;

namespace Demo.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        IDataAccess database;
        IMappingEngine mapper;

        public OrderRepository(IDataAccess dataAccess, IMappingEngine mappingEngine)
        {
            database = dataAccess;
            mapper = mappingEngine;
        }

        public IEnumerable<Order_ViewModel> GetAll()
        {
            IEnumerable<Order_ViewModel> orders;

            using (var reader = database.ExecuteReader(SqlStatements.Orders_SelectAll))
            {
                orders = mapper.DynamicMap<IDataReader, IEnumerable<Order_ViewModel>>(reader);
            }

            return orders;
        }

        public Order_ViewModel GetById(int Id)
        {
            Order_ViewModel order;

            using (var reader = database.ExecuteReader(SqlStatements.Orders_SelectById,
                                                database.ParameterFactory.Create("@OrderId", DbType.Int32, Id)))
            {
                reader.Read();
                IDataRecord record = (IDataRecord)reader;

                order = mapper.DynamicMap<IDataRecord, Order_ViewModel>(record);
            }

            return order;
        }

        public void Update(Order_EditViewModel toUpdate)
        {
            var order = mapper.DynamicMap<Order_EditViewModel, Order>(toUpdate);

            var parameter = database.ParameterFactory;

            database.ExecuteNonQuery(SqlStatements.Orders_UpdateById,
                                     parameter.Create("@ShipVia", DbType.Int32, order.ShipVia),
                                     parameter.Create("@CustomerId", DbType.StringFixedLength, order.CustomerId, 5),
                                     parameter.Create("@EmployeeId", DbType.Int32, order.EmployeeId),
                                     parameter.Create("@OrderDate", DbType.DateTime, order.OrderDate),
                                     parameter.Create("@RequiredDate", DbType.DateTime, order.RequiredDate),
                                     parameter.Create("@ShippedDate", DbType.DateTime, order.ShippedDate),
                                     parameter.Create("@Freight", DbType.Decimal, order.Freight),
                                     parameter.Create("@ShipName", DbType.String, order.ShipName, 40),
                                     parameter.Create("@ShipAddress", DbType.String, order.ShipAddress, 60),
                                     parameter.Create("@ShipCity", DbType.String, order.ShipCity, 15),
                                     parameter.Create("@ShipRegion", DbType.String, order.ShipRegion, 15),
                                     parameter.Create("@ShipPostalCode", DbType.String, order.ShipPostalCode, 10),
                                     parameter.Create("@ShipCountry", DbType.String, order.ShipCountry, 15),
                                     parameter.Create("@OrderId", DbType.Int32, order.OrderId));

        }

        public Order GetDomainObjectById(int Id)
        {
            Order order;

            using (var reader = database.ExecuteReader(SqlStatements.Order_DomainModelById,
                                                database.ParameterFactory.Create("@OrderId", DbType.Int32, Id)))
            {
                reader.Read();
                IDataRecord record = (IDataRecord)reader;

                order = mapper.DynamicMap<IDataRecord, Order>(record);
            }

            return order;
        }
    }
}