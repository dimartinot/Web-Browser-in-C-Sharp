using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser.Models
{
    /// <summary>
    /// FavoriteItem model class embedding a favorite address and names
    /// </summary>
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

        /// <summary>
        /// Overrides the Equals method to check for attribute equality
        /// </summary>
        /// <param name="obj">The object to which we want to compare the current instance</param>
        /// <returns><seealso cref="bool"/>: Boolean telling wether or not this instance equals the one passed as a parameter</returns>
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
