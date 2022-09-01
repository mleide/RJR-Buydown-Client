using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;
using CDI.RJR.Data;
using CDI.RJR.DataConnector;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RJR.BusinessRules;
using RJR.Client;
using Configuration = RJR.Client.Configuration;

namespace CDI.RJR.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
    
    static class DataSaver
    {
        static void Run(string[] args)
        {
            var settings = ConfigurationHelper.GetConfiguration(args);
            var data = DataDownloader.Run(args);

            Console.WriteLine("Applying business rules");
            var engine = BusinessRuleEngineHelper.GetEngine();
            engine.Mutate(data.Products.ToArray());
            engine.Mutate(data.Outlets.ToArray());
            engine.Mutate(data.DiscountRates.ToArray());

            Console.WriteLine("Saving to database");
            var dataClient = new DataClient(new Converter(), new BuydownSqlClient(settings.ConnectionString));
            dataClient.SaveLocations(data.Outlets);
            dataClient.SaveProducts(data.Products);
            dataClient.SaveDiscounts(data.DiscountRates);
            Console.WriteLine("Successfully saved to database");
        }
    }

    static class DataDownloader
    {
        public static BuydownResponse Run(string[] args)
        {
            var config = ConfigurationHelper.GetConfiguration(args).Configuration;
            var authenticator = new Authenticator(config.Id, config.Password, config);
            var client = new RJRClient(config, authenticator, new JsonResponseParser());
            var getDataTask = client.GetDataAsync(config.CycleCode);

            int cnt = 0;
            while (true)
            {
                if (getDataTask.IsCompletedSuccessfully)
                {
                    Console.Clear();
                    Console.WriteLine("Data successfully downloaded.");
                    return getDataTask.Result;
                }

                if (getDataTask.IsCanceled || getDataTask.IsFaulted || getDataTask.IsCanceled)
                {
                    Console.Clear();
                    Console.WriteLine("Error occurred while retrieving data.");
                    return null;
                }

                Console.Clear();
                Console.Write("Getting Data");
                for (int i = 0; i < cnt; i++)
                    Console.Write(".");
                ++cnt;
                if (cnt > 3)
                    cnt = 0;

                Thread.Sleep(200);
            }
        }
    }

    static class ConfigurationHelper
    {
        public static Settings GetConfiguration(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddCommandLine(args)
                .Build();

            return config.GetSection("Settings").Get<Settings>();
        }
    }

    static class BusinessRuleEngineHelper
    {
        public static Engine GetEngine()
        {
            var engine = new Engine();
            // register rules here
            engine.ThrowOnFailedValidation = false;
            return engine;
        }
    }
}
