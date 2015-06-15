using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Walmart.SDK.Configuration
{
    public static class APISettings
    {
        public static bool Sandbox
        {
            get
            {
                var value = ConfigurationManager.AppSettings["Marketplace.Walmart.Sandbox"];
                var sandbox = false;
                if (!Boolean.TryParse(value, out sandbox))
                {
                    throw new ConfigurationErrorsException("A chave 'Marketplace.Walmart.Sandbox' não está configurada no appSettings.");
                }
                return sandbox;
            }
        }

        public static string Username
        {
            get
            {
                var value = ConfigurationManager.AppSettings["Marketplace.Walmart.Username"];
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ConfigurationErrorsException("A chave 'Marketplace.Walmart.Username' não está configurada no appSettings.");
                }
                return value;
            }
        }

        public static string Password
        {
            get
            {
                var value = ConfigurationManager.AppSettings["Marketplace.Walmart.Password"];
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ConfigurationErrorsException("A chave 'Marketplace.Walmart.Password' não está configurada no appSettings.");
                }
                return value;
            }
        }

        public static string SellerId
        {
            get
            {
                var value = ConfigurationManager.AppSettings["Marketplace.Walmart.SellerId"];
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ConfigurationErrorsException("A chave 'Marketplace.Walmart.SellerId' não está configurada no appSettings.");
                }
                return value;
            }
        }
    }
}
