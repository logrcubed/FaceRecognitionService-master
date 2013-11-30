using System;
using System.ServiceModel;
using System.Net.Mail;
using System.ServiceModel.Description;

namespace FaceRecogService
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Watcher watch = new Watcher();
            string baseAddress = "http://138.91.36.91:8000/Service";
            WebHttpBinding wb = new WebHttpBinding();
            wb.MaxBufferSize = 4194304;
            wb.MaxReceivedMessageSize = 4194304;
            wb.MaxBufferPoolSize = 4194304;

            ServiceHost host = new ServiceHost(typeof(ImageUploadService), new Uri(baseAddress));
            host.AddServiceEndpoint(typeof(IImageUpload), wb, "").Behaviors.Add(new WebHttpBehavior());
            //host.AddServiceEndpoint(typeof(IImageUpload), new WebHttpBinding(), "").Behaviors.Add(new WebHttpBehavior());
            host.Open();
            Console.WriteLine("Host opened"); 
            Console.ReadKey(true);
        }          
    }
}
