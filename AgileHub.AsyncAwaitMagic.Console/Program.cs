using AgileHub.AsyncAwaitMagic.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileHub.AsyncAwaitMagic.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            RestClient restClient = new RestClient();

            var result = restClient.Get("http://asyncawaitmagic.azurewebsites.net/api/demo").Result;

            System.Console.WriteLine(result.StatusCode);

            System.Console.ReadLine();
        }
    }
}
