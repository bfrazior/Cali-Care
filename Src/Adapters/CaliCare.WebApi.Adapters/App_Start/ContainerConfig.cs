using CaliCare.Conditions.Domain;
using CaliCare.Patients.Domain;
using CaliCare.Registration.Domain;
using CaliCare.Resources.Domain;
using CaliCare.Scheduling.Domain;
using MediatR;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System;
using CaliCare.Resources.Ports.Repositories;
using CaliCare.Resources.Adapters.Repositories;
using CaliCare.Patients.Ports.Repositories;
using CaliCare.Patients.Adapters.Repositories;
using CaliCare.Registration.Ports.Services;
using CaliCare.Registration.Adapters.Services;
using MediatR.Pipeline;
using CaliCare.Conditions.Ports.Repositories;
using CaliCare.Conditions.Adapters.Repositories;

namespace CaliCare.WebApi.Adapters.App_Start
{
   public static class ContainerConfig
   {
      public static Container Register()
      {
         var container = new Container();
         container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

         ConditionRegistrations(container);
         PatientRegistrations(container);
         RegistrationRegistrations(container);
         ResourceRegistrations(container);

         MediatorRegistrations(container);

         container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
         container.Verify();

         return container;
      }

      private static void ConditionRegistrations(Container container)
      {
         container.Register<IConditionRepository, ConditionRepository>();
         container.Register<ITopographyRepository, TopographyRepository>();
      }

      private static void RegistrationRegistrations(Container container)
      {
         container.Register<IAdmitSchedulingService, AdmitSchedulingService>();
      }

      private static void PatientRegistrations(Container container)
      {
         container.Register<IPatientRepository, PatientRepository>();
      }

      private static void ResourceRegistrations(Container container)
      {
         container.Register<IDepartmentRepository, DepartmentRepository>();
         container.Register<IRoomRepository, RoomRepository>();
         container.Register<IMachineRepository, MachineRepository>();
         container.Register<IPhysicianRepository, PhysicianRepository>();
      }

      private static void MediatorRegistrations(Container container)
      {
         container.RegisterSingleton<IMediator, Mediator>();

         var assemblies = GetAssemblies().ToList();
         container.Register(typeof(IRequestHandler<,>), assemblies);
         container.Register(typeof(IRequestHandler<>), assemblies);

         container.RegisterCollection(typeof(IPipelineBehavior<,>), Enumerable.Empty<Type>());
         container.RegisterCollection(typeof(IRequestPreProcessor<>), Enumerable.Empty<Type>());
         container.RegisterCollection(typeof(IRequestPostProcessor<,>), Enumerable.Empty<Type>());

         container.RegisterSingleton(new SingleInstanceFactory(container.GetInstance));
         container.RegisterSingleton(new MultiInstanceFactory(container.GetAllInstances));
      }

      private static IEnumerable<Assembly> GetAssemblies()
      {
         yield return typeof(Conditions.Domain.PatientCondition).GetTypeInfo().Assembly;
         yield return typeof(Patient).GetTypeInfo().Assembly;
         yield return typeof(Admit).GetTypeInfo().Assembly;
         yield return typeof(Machine).GetTypeInfo().Assembly;
         yield return typeof(Appointment).GetTypeInfo().Assembly;
      }
   }
}