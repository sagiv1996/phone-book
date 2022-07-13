using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace phoneBook.Models
{
    public class Group :itemInBook
    {
        public Group()
        {
            Items = new List<itemInBook>();
        }
        [Required (ErrorMessage = "שדה זה חובה")]
        public string Name { get; set; }
        public virtual ICollection<itemInBook> Items { get; set; }
        public override string Description { get { return Name; } }
        
        public void addItem(itemInBook item)
        {
            Items.Add(item);
            item.Parent = this;
        }

        
    }
}
