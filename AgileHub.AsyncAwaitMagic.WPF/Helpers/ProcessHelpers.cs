using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileHub.AsyncAwaitMagic.WPF.Helpers
{
    public static class ProcessHelpers
    {
        public static Task RunProcessAsync(string processPath)
        {
            var process = new Process
            {
                EnableRaisingEvents = true,
                StartInfo = new ProcessStartInfo(processPath)
                {
                    RedirectStandardError = true,
                    UseShellExecute = false
                }
            };

            process.Exited += (sender, args) =>
            {
                process.Dispose();
            };

            process.Start();

            return Task.CompletedTask;
        }
    }
}
