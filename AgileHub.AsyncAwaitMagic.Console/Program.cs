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
            DemoService service = new DemoService();

            var saveResult = service.SaveNewDemoTextSyncHack("someValue");

            if (saveResult)
                return;

            System.Console.WriteLine(saveResult);

            System.Console.ReadLine();
        }
    }
}
