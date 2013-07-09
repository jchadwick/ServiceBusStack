using NServiceBus;
using WebServiceBus.App_Start;

[assembly: WebActivator.PreApplicationStartMethod(typeof(NServiceBusConfig), "Start")]

namespace WebServiceBus.App_Start
{
    public class NServiceBusConfig
    {
        public static IBus Bus { get; private set; }

        public static void Start()
        {
            Bus =
                Configure.With()
                    .DefineEndpointName("Website")
                    .DefiningMessagesAs(t => t.Namespace == "Contracts")
                    .Log4Net()
                    .DefaultBuilder()
                    .XmlSerializer()
                    .MsmqTransport()
                        .IsTransactional(true)
                        .PurgeOnStartup(true)
                    .UnicastBus()
                        .LoadMessageHandlers()
                        .ImpersonateSender(false)
                    .CreateBus()
                    .Start(() => Configure.Instance.ForInstallationOn<NServiceBus.Installation.Environments.Windows>().Install());
        }
    }
}
