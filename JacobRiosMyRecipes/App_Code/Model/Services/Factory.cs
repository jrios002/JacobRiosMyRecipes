using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;

namespace JacobRiosMyRecipes.Model.Services
{
    public class Factory
    {
        public Factory()
        {
            // Default contructor
        }

        // getService method to retrieve type of service desired
        public IService getService(string serviceName)
        {
            Type type;
            Object obj = null;

            // Try to create an instance of the service desired
            try
            {
                type = Type.GetType(getImplName(serviceName));
                obj = Activator.CreateInstance(type);
            }

            // Catch and throw exception if instance could not be created
            catch (Exception e)
            {
                Console.WriteLine("Exception occured: {0}", e);
                throw e;
            }

            return (IService)obj;
        }

        // Method to determine what service to instantiate by reading app.config file
        private string getImplName(string serviceName)
        {
            NameValueCollection settings = ConfigurationManager.AppSettings;
            return settings.Get(serviceName);
        }
    }
}