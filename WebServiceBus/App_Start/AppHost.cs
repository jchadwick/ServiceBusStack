using System.Data.Entity;
using DataAccess;
using Domain;
using Funq;
using NServiceBus;
using ServiceStack.WebHost.Endpoints;

[assembly: WebActivator.PreApplicationStartMethod(typeof(WebServiceBus.App_Start.AppHost), "Start")]

namespace WebServiceBus.App_Start
{
	public class AppHost : AppHostBase
	{		
		public AppHost() //Tell ServiceStack the name and where to find your web services
            : base("Services", typeof(AppHost).Assembly) { }

		public override void Configure(Funq.Container container)
		{
			//Set JSON web services to return idiomatic JSON camelCase properties
			ServiceStack.Text.JsConfig.EmitCamelCaseNames = true;
            container.DefaultReuse = ReuseScope.Request;
            container.Register<IBus>(NServiceBusConfig.Bus);
            container.RegisterAutoWiredAs<MasterContext, DbContext>();
		    container.RegisterAutoWiredAs<BankAccountRepository, IBankAccountRepository>();

		    /*
		       var referencedTypes = BuildManager.GetReferencedAssemblies().OfType<Assembly>().Where(x => x.FullName.Contains("JK")).SelectMany(x => x.GetTypes());
            var implementations = referencedTypes.Where(x => !x.IsAbstract && !x.IsInterface);
            
            var interfacesWithOneImplementation = 
                implementations.SelectMany(x => x.GetInterfaces())
                    .GroupBy(x => x)
                    .Where(x => x.Count() == 1)
                    .SelectMany(x => x)
                    .ToArray();

            var singleImplementations =
                from impl in implementations
                from iface in interfacesWithOneImplementation
                where impl.GetInterfaces().Contains(iface)
                select new { Type = impl, Interface = iface };

            var registerMethod = container.GetType().GetMethod("RegisterAutoWiredAs");

            foreach (var impl in singleImplementations)
            {
                var method = registerMethod.MakeGenericMethod(new[] { impl.Type, impl.Interface });
                method.Invoke(container, new object[0]);
            }
		    */
		}

		/* Uncomment to enable ServiceStack Authentication and CustomUserSession
		private void ConfigureAuth(Funq.Container container)
		{
			var appSettings = new AppSettings();

			//Default route: /auth/{provider}
			Plugins.Add(new AuthFeature(() => new CustomUserSession(),
				new IAuthProvider[] {
					new CredentialsAuthProvider(appSettings), 
					new FacebookAuthProvider(appSettings), 
					new TwitterAuthProvider(appSettings), 
					new BasicAuthProvider(appSettings), 
				})); 

			//Default route: /register
			Plugins.Add(new RegistrationFeature()); 

			//Requires ConnectionString configured in Web.Config
			var connectionString = ConfigurationManager.ConnectionStrings["AppDb"].ConnectionString;
			container.Register<IDbConnectionFactory>(c =>
				new OrmLiteConnectionFactory(connectionString, SqlServerDialect.Provider));

			container.Register<IUserAuthRepository>(c =>
				new OrmLiteAuthRepository(c.Resolve<IDbConnectionFactory>()));

			var authRepo = (OrmLiteAuthRepository)container.Resolve<IUserAuthRepository>();
			authRepo.CreateMissingTables();
		}
		*/

		public static void Start()
		{
			new AppHost().Init();
		}
	}
}
