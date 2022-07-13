using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phoneBook.Models
{
    public class Person : itemInBook
    {
        public Person()
        {
            addresses = new List<string>();
        }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public virtual ICollection<String> addresses { get; set; }
        public override string Description { get { return firstName + " " + lastName; } }
       
    }
}
