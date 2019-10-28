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
    /// <summary>
    /// Controller class responsible for the intelligence code linked to the Favorites/Bookmarks management
    /// </summary>
    class FavoritesController
    {
        /// <summary>
        /// Holds the instance of <seealso cref="Models.Favourites"/>  which acts as a list of FavoriteItems
        /// </summary>
        private Models.Favourites Favorites { get; set; }
        /// <summary>
        /// Path to the .xml serialization of the "Favorites" instance
        /// </summary>
        private const string FAVORITES_PATH = "favorites.xml";

        /// <summary>
        /// The class constructor: loads the favorites from the .xml file
        /// </summary>
        public FavoritesController()
        {
            this.LoadFavorites();
        }

        /// <summary>
        /// Method that opens the .xml file and loads its content into the <seealso cref="Models.Favourites"/> class attribute.
        /// If the file does not exist, create it and initialize the <seealso cref="Models.Favourites"/> class attribute as an empty list of <seealso cref="Models.FavouriteItem"/>.
        /// </summary>
        public void LoadFavorites()
        {
            if (File.Exists(FAVORITES_PATH))
            {
                Stream stream = File.Open(FAVORITES_PATH, FileMode.Open);
                SoapFormatter formatter = new SoapFormatter();
                try
                {
                    Favorites = (Models.Favourites)formatter.Deserialize(stream);
                }
                catch (Exception e)
                {
                    Favorites = new Models.Favourites();
                }
                stream.Close();
            }
            else
            {
                Stream stream = File.Open(FAVORITES_PATH, FileMode.Create);
                stream.Close();

                this.Favorites = new Models.Favourites();
            }

            //Postcondition
            if (this.Favorites == null)
            {
                throw new Exceptions.InvalidValuedVariableException("LoadFavorites() PostCondition failed. Favorites variable is not initialized");
            }
        }

        /// <summary>
        /// Method that saves into the .xml file the <seealso cref="Models.Favourites"/> attribute
        /// </summary>
        public void SaveFavorites()
        {
            Stream stream = File.Open(FAVORITES_PATH, FileMode.OpenOrCreate);
            SoapFormatter formatter = new SoapFormatter();

            formatter.Serialize(stream, this.Favorites);

            stream.Close();
        }

        /// <summary>
        /// Methods that adds a given url and a given name as a <seealso cref="Models.FavouriteItem"/> in the <seealso cref="Models.Favourites"/> attribute of this class
        /// </summary>
        /// <param name="address">String acting as a webpage url</param>
        /// <param name="name">Name of this webpage</param>
        public void AddToFavorites(string address, string name)
        {
            if (address != null & name != null)
            {
                this.Favorites.FavouritesList.Add(new Models.FavouriteItem(address, name));
                this.SaveFavorites();
            } else
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Methods that returns the number of favorites by accessing the count attribute of the list of <seealso cref="Models.FavouriteItem"/> stored in the <seealso cref="Models.Favourites"/> class attribute.
        /// </summary>
        /// <returns><seealso cref="int"/>: Number of favorites</returns>
        public int NumberOfFavorites()
        {
            return this.Favorites.FavouritesList.Count;
        }

        /// <summary>
        /// Returns the list of favorites
        /// </summary>
        /// <returns><seealso cref="ArrayList"/>: List of <seealso cref="FavouriteItem"/></returns>
        public ArrayList ListOfFavoriteItems()
        {
            return this.Favorites.FavouritesList;
        }

        /// <summary>
        /// Change a favorite data of a given index with a given <seealso cref="Models.FavouriteItem"/> instance and save the new list to disk.
        /// </summary>
        /// <param name="favoriteItem">Instance of a <seealso cref="Models.FavouriteItem"/></param>
        /// <param name="index">Index to which the change should be applied</param>
        public void UpdateFavorite(FavouriteItem favoriteItem, int index)
        {
            if (favoriteItem == null)
            {
                throw new ArgumentNullException();
            }
            if (index >= 0 && index < this.Favorites.FavouritesList.Count)
            {
                this.Favorites[index] = favoriteItem;
                this.SaveFavorites();
            } else
            {
                throw new Exceptions.InvalidValuedVariableException("Index out of bounds");
            }
        }

        /// <summary>
        /// Delete a given favorite at a given index.
        /// </summary>
        /// <param name="objIndex">Index of the <seealso cref="Models.FavouriteItem"/> to delete</param>
        public void DeleteFavourite(int objIndex)
        {
            if (objIndex >= 0 && objIndex < this.Favorites.FavouritesList.Count)
            {
                this.Favorites.FavouritesList.RemoveAt(objIndex);
                this.SaveFavorites();
            }

            else
            {
                throw new Exceptions.InvalidValuedVariableException("Index out of bounds");
            }
        }
    }
}
