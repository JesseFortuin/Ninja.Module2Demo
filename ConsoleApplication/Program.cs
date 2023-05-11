using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NinjaDomain.Application;
using NinjaDomain.DataModel;
using System.Data.Entity;

class Program
{
    static void Main(string[] args)
    {
        //stops EF from doing database initialization process when working with given context
        Database.SetInitializer(new NullDatabaseInitializer<NinjaContext>());

        IHost host = Host.CreateDefaultBuilder()
            .ConfigureServices(services => 
            {
                services.AddSingleton<INinjaFacade, NinjaFacade>();
            })
            .Build();

        var ninja = host.Services.GetRequiredService<INinjaFacade>();

        ninja.InsertNinja();

        Console.ReadKey();
    }
}