using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WCFTLSHost;

namespace WCFTLSClient
{
    class Program
    {

        static void Main(string[] args)
        {
            var testService = new TestService.HelloWorldServiceClient();

            testService.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindBySubjectName, "client1");

            testService.Open();

            Console.WriteLine(testService.SayHello("World"));

            Console.Read();

        }
    }
}
