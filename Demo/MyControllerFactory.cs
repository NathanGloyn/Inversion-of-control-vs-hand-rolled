using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DataAccessLayer.Core;
using Demo.Controllers;
using Demo.DomainLogic;
using Demo.Repositories;

namespace Demo
{
    public class MyControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            var factory = new ControllerAbstractFactory();

            return factory.Create(controllerType);
        }
    }
}