using Microsoft.EntityFrameworkCore.Infrastructure;
using PestSchedule.Domain.Common;
using System;
using System.Collections.Generic;

namespace PestSchedule.Domain.Entities
{
    public class Animal : Entity
    {
        public Animal()
        {
            Attendances = new HashSet<Attendance>();
            Schedules = new HashSet<Schedule>();
        }

        private ILazyLoader LazyLoader { get; set; }
        private Animal(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public int AnimalTypeId { get; set; }

        private AnimalType _animalType;
        public AnimalType AnimalType {
            get => LazyLoader.Load(this, ref _animalType);
            set => _animalType = value;
        }
        public bool IsOldAnimal { get { return Age > AnimalType.AgeConsideredOld; } }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public HashSet<Attendance> Attendances { get; private set; }
        public HashSet<Schedule> Schedules { get; private set; }

    }
}
