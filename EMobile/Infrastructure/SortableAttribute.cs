using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMobile.Infrastructure
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SortableAttribute : Attribute
    {
        public bool Default { get; set; }
    }
}
