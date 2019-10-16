using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser.Models
{
    [Serializable()]
    public class FavoriteItem
    {
        public string Address { get; set; }

        public string Name { get; set; }

        public FavoriteItem(string address, string name)
        {
            this.Address = address;
            this.Name = name;
        }

        public override bool Equals(object obj)
        {
            if (typeof(FavoriteItem).IsInstanceOfType(obj))
            {
                FavoriteItem FavItemObj = (FavoriteItem)obj;
                if (this.Address == FavItemObj.Address && this.Name == FavItemObj.Name)
                {
                    return true;
                } else
                {
                    return false;
                }
            }
            return false;
        }

        public override string ToString()
        {
            return String.Format("{0}\t ({1})", this.Name, this.Address);
        }
    }
}
