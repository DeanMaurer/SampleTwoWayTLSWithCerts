using System;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace WCFTLSHost
{
    [ServiceContract]
    public interface IHelloWorldService
    {
        [OperationContract]
        string SayHello(string name);
    }

    public class HelloWorldService : IHelloWorldService
    {
        public string SayHello(string name)
        {
            return string.Format("Hello, {0}!", name);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var baseAddress = new Uri("https://localhost:44355");

            using (var host = new ServiceHost(typeof(HelloWorldService), baseAddress))
            {
                var binding = new WSHttpBinding(SecurityMode.TransportWithMessageCredential);
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;
                binding.Security.Message.ClientCredentialType = MessageCredentialType.Certificate;
                
                host.Credentials.ServiceCertificate.SetCertificate(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindBySubjectName, "localhost");
                host.Credentials.ClientCertificate.Authentication.RevocationMode = X509RevocationMode.NoCheck;
                host.Credentials.ClientCertificate.Authentication.TrustedStoreLocation = StoreLocation.LocalMachine;
                host.Credentials.ClientCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.ChainTrust;
                
                var endpoint = typeof(IHelloWorldService);
                host.AddServiceEndpoint(endpoint, binding, baseAddress);

                var metaBehavior = new ServiceMetadataBehavior();
                metaBehavior.HttpGetEnabled = true;
                metaBehavior.HttpGetUrl = new Uri("http://localhost:9000/mex");
                metaBehavior.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                host.Description.Behaviors.Add(metaBehavior);
                
                host.Open();
                
                Console.WriteLine("Service is ready. Hit enter to stop service.");
                Console.ReadLine();

                host.Close();
            }
        }
    }
}
