using System;

using Xunit;
using FluentAssertions;

using CaliCare.Resources.Adapters.Repositories;
using CaliCare.Resources.Domain;
using CaliCare.Resources.Common;

namespace CaliCare.Resources.Adapters.Tests.Repositories
{
   public class MachineRepositoryTests
   {
      private readonly MachineRepository _machineRepository;
      private readonly Machine[] _machines;

      public MachineRepositoryTests()
      {
         _machineRepository = new MachineRepository();

         var simpleCharacterization = new MachineCharacterization(MachineCapability.Simple);
         var advancedCharacterization = new MachineCharacterization(MachineCapability.Advanced);

         _machines = new Machine[] 
         {
            Machine.Create("Elekta", Guid.NewGuid(), advancedCharacterization),
            Machine.Create("Varian", Guid.NewGuid(), advancedCharacterization),
            Machine.Create("MM50", Guid.NewGuid(), simpleCharacterization)
         };
      }

      [Fact]
      public void Store_should_save_machine_to_json_file()
      {
         // Act
         _machineRepository.Store(_machines);
         var stored = _machineRepository.FindAll();

         // Assert
         stored.Count.Should().Be(3);
      }

      [Fact]
      public void FindAll_should_return_machines_of_specified_capability_when_capability_filter_applied()
      {
         // Act
         _machineRepository.Store(_machines);
         var simpleStored = _machineRepository.FindAll(MachineCapability.Simple);
         var advancedStored = _machineRepository.FindAll(MachineCapability.Advanced);

         // Assert
         simpleStored.Count.Should().Be(1);
         advancedStored.Count.Should().Be(2);
      }
   }
}
