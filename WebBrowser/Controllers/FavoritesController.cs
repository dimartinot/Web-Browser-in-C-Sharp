using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBrowser.Models;

namespace WebBrowser.Controllers
{
    class FavoritesController
    {

        private Models.Favorites Favorites { get; set; }
        private const string FAVORITES_PATH = "favorites.xml";

        public FavoritesController()
        {
            this.LoadFavorites();
        }

        public void LoadFavorites()
        {
            if (File.Exists(FAVORITES_PATH))
            {
                Stream stream = File.Open(FAVORITES_PATH, FileMode.Open);
                SoapFormatter formatter = new SoapFormatter();
                try
                {
                    Favorites = (Models.Favorites)formatter.Deserialize(stream);
                }
                catch (Exception e)
                {
                    Favorites = new Models.Favorites();
                }
                stream.Close();
            }
            else
            {
                Stream stream = File.Open(FAVORITES_PATH, FileMode.Create);
                stream.Close();

                this.Favorites = new Models.Favorites();
            }
        }

        public void SaveFavorites()
        {
            Stream stream = File.Open(FAVORITES_PATH, FileMode.OpenOrCreate);
            SoapFormatter formatter = new SoapFormatter();

            formatter.Serialize(stream, this.Favorites);

            stream.Close();
        }

        public void AddToFavorites(string address, string name)
        {
            this.Favorites.FavoritesList.Add(new Models.FavoriteItem(address, name));
            this.SaveFavorites();
        }

        public int NumberOfFavorites()
        {
            return this.Favorites.FavoritesList.Count;
        }

        public ArrayList ListOfFavoriteItems()
        {
            return this.Favorites.FavoritesList;
        }

        public void UpdateFavorite(FavoriteItem favoriteItem, int index)
        {
            if (index >= 0 && index < this.Favorites.FavoritesList.Count)
            {
                this.Favorites[index] = favoriteItem;
                this.SaveFavorites();
            }
        }

        internal void DeleteFavorite(int objIndex)
        {
            if (objIndex >= 0 && objIndex < this.Favorites.FavoritesList.Count)
            {
                this.Favorites.FavoritesList.RemoveAt(objIndex);
                this.SaveFavorites();
            }
        }
    }
}
