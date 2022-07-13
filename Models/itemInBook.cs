using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phoneBook.Models
{
    public abstract class itemInBook
    {
        private static int nextId;
        public itemInBook()
        {
            ID = ++nextId;
        }
        public int ID { get; set; }
        public int PerentId { get; set; }
        public Group Parent { get; set; }
        public abstract string Description {get;}
        

    }
}
