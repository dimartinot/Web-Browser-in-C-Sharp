using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser.Models
{
    /// <summary>
    /// Favorite model class embedding a list of <seealso cref="FavouriteItem"/>.
    /// </summary>
    [Serializable()]
    public class Favourites
    {
        public ArrayList FavouritesList { get; set; }

        public Favourites()
        {
            this.FavouritesList = new ArrayList();
        }

        public Favourites (ArrayList favouritesList)
        {
            this.FavouritesList = favouritesList;
        }

        /// <summary>
        /// Indexer methods to access a given <seealso cref="FavouriteItem"/> instance
        /// </summary>
        /// <param name="index">int index of the instance to access</param>
        /// <returns><seealso cref="FavouriteItem"/>: the instance to return</returns>
        public FavouriteItem this[int index]
        {
            get
            {
                return (FavouriteItem)this.FavouritesList[index];
            }
            set
            {
                this.FavouritesList[index] = value;
            }
        }
    }
}
