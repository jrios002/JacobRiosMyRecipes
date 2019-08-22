using JacobRiosMyRecipes.Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JacobRiosMyRecipes.Model.Business
{
    public class ManagerSuperType
    {
        private Factory factory = new Factory();

        // Method each manager will inherit to get service desired
        protected internal virtual IService getService(string name)
        {
            return factory.getService(name);
        }
    }
}