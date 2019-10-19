using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser.Models
{
    /// <summary>
    /// Favorite model class embedding a list of <seealso cref="FavoriteItem"/>.
    /// </summary>
    [Serializable()]
    public class Favorites
    {
        public ArrayList FavoritesList { get; set; }

        public Favorites()
        {
            this.FavoritesList = new ArrayList();
        }

        public Favorites (ArrayList favoritesList)
        {
            this.FavoritesList = favoritesList;
        }

        /// <summary>
        /// Indexer methods to access a given <seealso cref="FavoriteItem"/> instance
        /// </summary>
        /// <param name="index">int index of the instance to access</param>
        /// <returns><seealso cref="FavoriteItem"/>: the instance to return</returns>
        public FavoriteItem this[int index]
        {
            get
            {
                return (FavoriteItem)this.FavoritesList[index];
            }
            set
            {
                this.FavoritesList[index] = value;
            }
        }
    }
}
