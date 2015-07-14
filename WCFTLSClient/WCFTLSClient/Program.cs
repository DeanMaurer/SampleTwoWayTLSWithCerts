using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;

namespace WCFTLSClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var testService = new TestService.HelloWorldServiceClient();
            testService.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindBySubjectName, "client1");

            testService.Open();

            Console.WriteLine(testService.SayHello("World"));
            Console.Read();

            testService.Close();
        }
    }
}
