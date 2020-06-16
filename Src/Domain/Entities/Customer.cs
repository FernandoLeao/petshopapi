using PestSchedule.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PestSchedule.Domain.Entities
{
    public class Customer : Entity
    {

        public Customer() 
        {
            Animals = new HashSet<Animal>();
        }

        public string Name { get; set; } 
        public string Cpf { get; set; }

        public HashSet<Animal> Animals { get; private set; }

    }
}
