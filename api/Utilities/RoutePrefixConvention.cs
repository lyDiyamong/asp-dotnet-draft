using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace api.Utilities
{
    public class RoutePrefixConvention : IApplicationModelConvention
    {
        private readonly string _prefix;

        public RoutePrefixConvention(string prefix)
        {
            _prefix = prefix;
        }

        public void Apply(ApplicationModel application)
        {
            foreach (var controller in application.Controllers)
            {
                if (!controller.Selectors.Any(s => s.AttributeRouteModel != null))
                {
                    controller.Selectors.Add(new SelectorModel
                    {
                        AttributeRouteModel = new AttributeRouteModel(new Microsoft.AspNetCore.Mvc.RouteAttribute(_prefix))
                    });
                }
                else
                {
                    foreach (var selector in controller.Selectors)
                    {
                        if (selector.AttributeRouteModel != null)
                        {
                            selector.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(
                                new AttributeRouteModel(new Microsoft.AspNetCore.Mvc.RouteAttribute(_prefix)),
                                selector.AttributeRouteModel);
                        }
                    }
                }
            }
        }
    }
}