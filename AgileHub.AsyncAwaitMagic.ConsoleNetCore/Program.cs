using AgileHub.AsyncAwaitMagic.Standard;
using System;

namespace AgileHub.AsyncAwaitMagic.ConsoleNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            DemoService service = new DemoService();

            var saveResult = service.SaveNewDemoTextSyncHack("someValue");

            if (saveResult)
                return;

            System.Console.WriteLine(saveResult);

            System.Console.ReadLine();
        }
    }
}
