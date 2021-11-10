using System;
using System.Reflection;
using System.Resources;

namespace Neusta.CompanyService.Abstraction.Exceptions
{
    public class CompanyNotFoundException : Exception
    {
        private static readonly ResourceManager ResourceManager = new ResourceManager(
            "Neusta.CompanyService.Abstraction.Ressources.ExceptionMessages",
            Assembly.GetExecutingAssembly());
        public CompanyNotFoundException() : base(ResourceManager.GetString("CompanyNotFound"))
        {

        }
    }
}