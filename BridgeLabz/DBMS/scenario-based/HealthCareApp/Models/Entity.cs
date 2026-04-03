using System;

namespace HealthCareApp.Models
{
    public abstract class Entity
    {
        public int ID { get; set; }

        public abstract void Display();
    }
}
