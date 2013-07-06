using NServiceBus;
using WebServiceBus.App_Start;

[assembly: WebActivator.PreApplicationStartMethod(typeof(NServiceBusConfig), "Start")]

namespace WebServiceBus.App_Start
{
    public class NServiceBusConfig
    {
        public static void Start()
        {
            Configure.WithWeb()
    .DefaultBuilder()
    .ForMvc()
    .JsonSerializer()
    .Log4Net()
    .MsmqTransport()
    .IsTransactional(false)
    .PurgeOnStartup(true)
    .UnicastBus()
    .ImpersonateSender(false)
    .CreateBus()
    .Start(() => Configure.Instance.ForInstallationOn<NServiceBus.Installation.Environments.Windows>().Install());
        }
    }
}
