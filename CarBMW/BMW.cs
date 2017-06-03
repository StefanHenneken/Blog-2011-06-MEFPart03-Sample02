using System;
using System.ComponentModel.Composition;
using CarContract;

namespace CarBMW
{
    [Export(typeof(ICarContract))]
    public class BMW : ICarContract, IDisposable
    {
        private BMW()
        {
            Console.WriteLine("BMW constructor.");
        }
        public string StartEngine(string name)
        {
            return String.Format("{0} starts the BMW.", name);
        }
        public void Dispose()
        {
            Console.WriteLine("Disposing BMW.");
        }
    }
}
