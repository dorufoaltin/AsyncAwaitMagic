using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AgileHub.AsyncAwaitMagic.WPF.Helpers
{
    public static class SocketExtensions
    {
        public static Task<Socket> AcceptAsync(this Socket socket)
        {
            if (socket == null)
                throw new ArgumentNullException("socket");

            var tcs = new TaskCompletionSource<Socket>();

            socket.BeginAccept(asyncResult =>
            {
                try
                {
                    var s = asyncResult.AsyncState as Socket;
                    var client = s.EndAccept(asyncResult);

                    tcs.SetResult(client);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }

            }, socket);

            return tcs.Task;
        }
    }
}
