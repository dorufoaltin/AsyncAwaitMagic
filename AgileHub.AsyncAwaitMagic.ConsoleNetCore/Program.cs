using AgileHub.AsyncAwaitMagic.Standard;
using System;

namespace AgileHub.AsyncAwaitMagic.ConsoleNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            RestClient restClient = new RestClient();

            var result = restClient.Get("http://asyncawaitmagic.azurewebsites.net/api/demo").Result;

            System.Console.WriteLine(result.StatusCode.ToString());

            System.Console.ReadLine();
        }
    }
}
