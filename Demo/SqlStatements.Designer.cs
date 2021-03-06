﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Demo {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class SqlStatements {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SqlStatements() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Demo.SqlStatements", typeof(SqlStatements).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT [CustomerID]
        ///      ,[CompanyName]
        ///      ,[ContactName]
        ///      ,[ContactTitle]
        ///      ,[Address]
        ///      ,[City]
        ///      ,[Region]
        ///      ,[PostalCode]
        ///      ,[Country]
        ///      ,[Phone]
        ///      ,[Fax]
        ///  FROM [Customers].
        /// </summary>
        internal static string Customer_SelectAll {
            get {
                return ResourceManager.GetString("Customer_SelectAll", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT [CustomerID]
        ///      ,[CompanyName]
        ///      ,[ContactName]
        ///      ,[ContactTitle]
        ///      ,[Address]
        ///      ,[City]
        ///      ,[Region]
        ///      ,[PostalCode]
        ///      ,[Country]
        ///      ,[Phone]
        ///      ,[Fax]
        ///  FROM [Customers]
        ///  WHERE CustomerId = @CustomerId.
        /// </summary>
        internal static string Customer_SelectById {
            get {
                return ResourceManager.GetString("Customer_SelectById", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT [EmployeeID]
        ///      ,[LastName]
        ///      ,[FirstName]
        ///      ,[Title]
        ///      ,[TitleOfCourtesy]
        ///      ,[BirthDate]
        ///      ,[HireDate]
        ///      ,[Address]
        ///      ,[City]
        ///      ,[Region]
        ///      ,[PostalCode]
        ///      ,[Country]
        ///      ,[HomePhone]
        ///      ,[Extension]
        ///      ,[ReportsTo]
        ///  FROM [Employees].
        /// </summary>
        internal static string Employee_SelectAll {
            get {
                return ResourceManager.GetString("Employee_SelectAll", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT [EmployeeID]
        ///      ,[LastName]
        ///      ,[FirstName]
        ///      ,[Title]
        ///      ,[TitleOfCourtesy]
        ///      ,[BirthDate]
        ///      ,[HireDate]
        ///      ,[Address]
        ///      ,[City]
        ///      ,[Region]
        ///      ,[PostalCode]
        ///      ,[Country]
        ///      ,[HomePhone]
        ///      ,[Extension]
        ///      ,[ReportsTo]
        ///  FROM [Employees]
        ///  WHERE EmployeeId = @EmployeeId.
        /// </summary>
        internal static string Employee_SelectById {
            get {
                return ResourceManager.GetString("Employee_SelectById", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT	OrderID
        ///		,CustomerId
        ///		,EmployeeId
        ///		,OrderDate
        ///		,RequiredDate
        ///		,ShippedDate
        ///		,ShipVia
        ///		,Freight
        ///		,ShipName
        ///		,ShipAddress
        ///		,ShipCity
        ///		,ShipRegion
        ///		,ShipPostalCode
        ///		,ShipCountry
        ///FROM	Orders
        ///WHERE	OrderId = @OrderId.
        /// </summary>
        internal static string Order_DomainModelById {
            get {
                return ResourceManager.GetString("Order_DomainModelById", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT o.OrderID
        ///      ,c.CompanyName AS Customer
        ///      ,e.FirstName
        ///      ,e.LastName
        ///      ,o.OrderDate
        ///      ,o.RequiredDate
        ///      ,o.ShippedDate
        ///      ,s.CompanyName AS ShipVia
        ///      ,o.Freight
        ///      ,o.ShipName
        ///      ,o.ShipAddress
        ///      ,o.ShipCity
        ///      ,o.ShipRegion
        ///      ,o.ShipPostalCode
        ///      ,o.ShipCountry
        ///  FROM [Orders] AS o
        ///  JOIN	Shippers AS s ON o.ShipVia = s.ShipperId
        ///  JOIN	Customers AS c ON o.CustomerId = c.CustomerId
        ///  JOIN	Employees AS e ON o.EmployeeId = e.EmployeeId.
        /// </summary>
        internal static string Orders_SelectAll {
            get {
                return ResourceManager.GetString("Orders_SelectAll", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT	o.OrderID
        ///		,c.CompanyName AS Customer
        ///		,e.FirstName
        ///		,e.LastName
        ///		,o.OrderDate
        ///		,o.RequiredDate
        ///		,o.ShippedDate
        ///		,s.CompanyName AS ShipVia
        ///		,o.Freight
        ///		,o.ShipName
        ///		,o.ShipAddress
        ///		,o.ShipCity
        ///		,o.ShipRegion
        ///		,o.ShipPostalCode
        ///		,o.ShipCountry
        ///FROM	Orders AS o
        ///JOIN	Shippers AS s ON o.ShipVia = s.ShipperId
        ///JOIN	Customers AS c ON o.CustomerId = c.CustomerId
        ///JOIN	Employees AS e ON o.EmployeeId = e.EmployeeId
        ///WHERE o.OrderId = @OrderId.
        /// </summary>
        internal static string Orders_SelectById {
            get {
                return ResourceManager.GetString("Orders_SelectById", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UPDATE	Orders 
        ///SET		ShipVia = @ShipVia, 
        ///		CustomerId = @CustomerId, 
        ///		EmployeeId = @EmployeeId,
        ///		OrderDate = @OrderDate,
        ///		RequiredDate = @RequiredDate,
        ///		ShippedDate = @ShippedDate,
        ///		Freight = @Freight,
        ///		ShipName = @ShipName,
        ///		ShipAddress = @ShipAddress,
        ///		ShipCity = @ShipCity,
        ///		ShipRegion = @ShipRegion,
        ///		ShipPostalCode = @ShipPostalCode,
        ///		ShipCountry = @ShipCountry 
        ///WHERE	OrderId = @OrderId.
        /// </summary>
        internal static string Orders_UpdateById {
            get {
                return ResourceManager.GetString("Orders_UpdateById", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT	ShipperId,
        ///		CompanyName,
        ///		Phone
        ///FROM	Shippers.
        /// </summary>
        internal static string Shippers_SelectAll {
            get {
                return ResourceManager.GetString("Shippers_SelectAll", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT	ShipperId,
        ///		CompanyName,
        ///		Phone
        ///FROM	Shippers
        ///WHERE	ShipperId = @ShipperId.
        /// </summary>
        internal static string Shippers_SelectById {
            get {
                return ResourceManager.GetString("Shippers_SelectById", resourceCulture);
            }
        }
    }
}
