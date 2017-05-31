/******************************************************
Simple MAPI.NET
*******************************************************/

using System;
using Win32Mapi;

namespace SimpleMAPICon
{
    class MainClass
    {
        [STAThread]
        static void Main(string[] args)
        {
            if ((args == null) || (args.Length < 3))
            {
                Console.WriteLine("SimpleMAPI Console SYNTAX :\n\tConsole-Demo recip@any.org subject text");
                return;
            }

            Mapi ma = new Mapi();
            if (!ma.Logon(IntPtr.Zero))
            {
                Console.WriteLine("MAPILogon failed! : " + ma.Error());
                return;
            }

            ma.AddRecipient(args[0], null, false);
            if (!ma.Send(args[1], args[2]))
            {
                Console.WriteLine("MAPISendMail failed! : " + ma.Error());
                return;
            }

            ma.Logoff();
            Console.WriteLine("SimpleMAPI Console: email sent successfully.");
        }
    }
}
