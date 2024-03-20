using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lez_13_DB_01_DAL.Utilities
{
    internal class Config
    {
        private static Config istanza;

        public static Config getIstanza()
        {
            if (istanza == null)
                istanza = new Config();

            return istanza;
        }

        private Config()
        {

        }


        public string? StringaConnessione { get; private set; }

        public string? GetConnectionString()
        {
            if (StringaConnessione == null)
            {
                ConfigurationBuilder builder = new ConfigurationBuilder();
                builder.SetBasePath(Directory.GetCurrentDirectory());
                builder.AddJsonFile("appSettings.json", false, true);

                IConfiguration configuration = builder.Build();

                StringaConnessione = configuration.GetConnectionString("ServerLocale");
            }
            return StringaConnessione;
        }
    }
}