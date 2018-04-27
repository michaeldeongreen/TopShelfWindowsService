using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using TopShelfWindowsService.Services;

namespace TopShelfWindowsService
{
    class Program
    {
        static void Main(string[] args)
        {
            var rc = HostFactory.Run(x =>                                   
            {
                x.Service<MyService>(s =>                                   
                {
                    s.ConstructUsing(name => new MyService());              
                    s.WhenStarted(tc => tc.Start());                        
                    s.WhenStopped(tc => tc.Stop());                         
                });
                x.RunAsLocalSystem();
                x.StartAutomatically();

                x.SetDescription("Sample Topshelf Host");                   
                x.SetDisplayName("TopshelfWindowsService");                                  
                x.SetServiceName("TopshelfWindowsService");                                 
            });                                                             

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());  
            Environment.ExitCode = exitCode;
        }
    }
}
