using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser.Models
{
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
