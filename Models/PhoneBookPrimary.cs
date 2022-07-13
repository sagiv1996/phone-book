using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phoneBook.Models
{
    public class PhoneBookPrimary
    {

        private static PhoneBookPrimary Book;
        private Group root;
        private PhoneBookPrimary()
        {
            root = new Group() { Name = "ספר טלפונים" };
            Group friends = new Group() { Name = "חברים" };
            root.addItem(friends);
            Person uri = new Person() { firstName = "sagiv", lastName = "bonali" };
            friends.addItem(uri);
            friends.addItem(new Group() { Name = "צבא" });
        }
        public static PhoneBookPrimary Create()
        {
            if (Book == null)
                Book = new PhoneBookPrimary();
            return Book;
        }
        public Group Root { get { return root; } }
        public itemInBook getItemById(int id)
        {
            if (root.ID == id)
                return root;
            return getItemById(root, id);
        }

        public itemInBook getItemById(Group group, int id)
        {
            foreach (itemInBook item in group.Items)
            {
                if (item.ID == id)
                    return item;

                if (item is Group)
                {
                    itemInBook result = getItemById((Group)item, id);
                    if (result != null)
                        return result;
                }
            }
            return null;
        }
    }
}

