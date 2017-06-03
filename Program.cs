using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using CarContract;

namespace CarHost
{
    class Program
    {
        [ImportMany(typeof(ICarContract), RequiredCreationPolicy = CreationPolicy.NonShared)]
        private IEnumerable<Lazy<ICarContract>> CarParts { get; set; }

        static void Main(string[] args)
        {
            new Program().Run();
        }
        void Run()
        {          
            var catalog = new DirectoryCatalog(".");
            var container = new CompositionContainer(catalog);

            container.ComposeParts(this);
            foreach (Lazy<ICarContract> car in CarParts)
                Console.WriteLine(car.Value.StartEngine("Sebastian"));

            Console.WriteLine("");
            Console.WriteLine("ReleaseExports.");
            container.ReleaseExports<ICarContract>(CarParts);
            Console.WriteLine("");

            container.ComposeParts(this);
            foreach (Lazy<ICarContract> car in CarParts)
                Console.WriteLine(car.Value.StartEngine("Sebastian"));

            Console.WriteLine("");
            Console.WriteLine("ReleaseExports.");
            foreach (Lazy<ICarContract> car in CarParts)
                container.ReleaseExport<ICarContract>(car);

            Console.WriteLine("");
            Console.WriteLine("Dispose Container.");
            container.Dispose();
        }
    }
}
