using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser.Tests
{
    public class UnitTest
    {

        private static void WriteLinePassed(string line)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(line);
            Console.ResetColor();
        }

        private static void WriteLineNotPassed(string line)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(line);
            Console.ResetColor();
        }

        public static void TestFavoritesController()
        {
            Controllers.FavoritesController FavoritesController = new Controllers.FavoritesController();

            Console.WriteLine(String.Format("\n[{0}] ---- TEST FAVORITES CONTROLLER ----", DateTime.Now));


            //
            // Testing AddToFavorites Method
            //
            Console.WriteLine(String.Format("[{0}] Testing AddToFavorites Method...", DateTime.Now));


            try
            {
                Console.WriteLine(String.Format("[{0}] No exception expected..", DateTime.Now));
                FavoritesController.AddToFavorites("", "");
                WriteLinePassed(String.Format("[{0}] Test passed..", DateTime.Now));
            }
            catch (ArgumentNullException e)
            {
                WriteLineNotPassed(String.Format("[{0}] Test not passed...", DateTime.Now));
            }

            try
            {
                Console.WriteLine(String.Format("[{0}] ArgumentNullException for both arguments null expected..", DateTime.Now));
                FavoritesController.AddToFavorites(null, null);
                WriteLineNotPassed(String.Format("[{0}] Test not passed..", DateTime.Now));
            }
            catch (ArgumentNullException e)
            {
                WriteLinePassed(String.Format("[{0}] Test passed...", DateTime.Now));
            }

            try
            {
                Console.WriteLine(String.Format("[{0}] ArgumentNullException for first null argument expected..", DateTime.Now));
                FavoritesController.AddToFavorites(null, "");
                WriteLineNotPassed(String.Format("[{0}] Test not passed..", DateTime.Now));
            }
            catch (ArgumentNullException e)
            {
                WriteLinePassed(String.Format("[{0}] Test passed...", DateTime.Now));
            }

            try
            {
                Console.WriteLine(String.Format("[{0}] ArgumentNullException for second null argument expected..", DateTime.Now));
                FavoritesController.AddToFavorites("", null);
                WriteLineNotPassed(String.Format("[{0}] Test not passed..", DateTime.Now));
            }
            catch (ArgumentNullException e)
            {
                WriteLinePassed(String.Format("[{0}] Test passed...", DateTime.Now));
            }

            //
            // Testing UpdateFavorite Method
            //
            Console.WriteLine(String.Format("[{0}] Testing UpdateFavorite Method...", DateTime.Now));

            try
            {
                Console.WriteLine(String.Format("[{0}] Updating with ('a','b')..", DateTime.Now));
                FavoritesController.UpdateFavorite(new Models.FavouriteItem("a", "b"), 0);
                Models.FavouriteItem modified = (Models.FavouriteItem)(FavoritesController.ListOfFavoriteItems()[0]);
                if (modified.Address == "a" & modified.Name == "b")
                    WriteLinePassed(String.Format("[{0}] Test passed..", DateTime.Now));
                else
                    WriteLineNotPassed(String.Format("[{0}] Test not passed...", DateTime.Now));
            }
            catch (ArgumentNullException e)
            {
                WriteLineNotPassed(String.Format("[{0}] Test not passed...", DateTime.Now));
            }

            try
            {
                Console.WriteLine(String.Format("[{0}] Updating with out of bound index..", DateTime.Now));
                FavoritesController.UpdateFavorite(new Models.FavouriteItem("a", "b"), -1);
                WriteLineNotPassed(String.Format("[{0}] Test not passed...", DateTime.Now));
            }
            catch (Exceptions.InvalidValuedVariableException e)
            {
                WriteLinePassed(String.Format("[{0}] Test passed...", DateTime.Now));
            }

            try
            {
                Console.WriteLine(String.Format("[{0}] Updating with null favourite item..", DateTime.Now));
                FavoritesController.UpdateFavorite(null, 0);
                WriteLineNotPassed(String.Format("[{0}] Test not passed...", DateTime.Now));
            }
            catch (ArgumentNullException e)
            {
                WriteLinePassed(String.Format("[{0}] Test passed...", DateTime.Now));
            }

            //
            // Testing DeleteFavourite Method
            //
            Console.WriteLine(String.Format("[{0}] Testing DeleteFavourite Method...", DateTime.Now));

            try
            {
                Console.WriteLine(String.Format("[{0}] Deleting first item..", DateTime.Now));
                FavoritesController.DeleteFavourite(0);
                WriteLinePassed(String.Format("[{0}] Test passed...", DateTime.Now));
            }
            catch (Exception e)
            {
                WriteLineNotPassed(String.Format("[{0}] Test not passed...", DateTime.Now));
            }

            try
            {
                Console.WriteLine(String.Format("[{0}] Deleting out of bound (-1) item..", DateTime.Now));
                FavoritesController.DeleteFavourite(-1);
                WriteLineNotPassed(String.Format("[{0}] Test not passed...", DateTime.Now));
            }
            catch (Exceptions.InvalidValuedVariableException e)
            {
                WriteLinePassed(String.Format("[{0}] Test passed...", DateTime.Now));
            }

            try
            {
                Console.WriteLine(String.Format("[{0}] Deleting out of bound (size+1) item..", DateTime.Now));
                FavoritesController.DeleteFavourite(FavoritesController.NumberOfFavorites() + 1);
                WriteLineNotPassed(String.Format("[{0}] Test not passed...", DateTime.Now));
            }
            catch (Exception e)
            {
                WriteLinePassed(String.Format("[{0}] Test passed...", DateTime.Now));
            }
        }

        public static void TestHistoryController()
        {

            Controllers.HistoryController HistoryController = new Controllers.HistoryController();
            HistoryController.EmptyHistory();
            HistoryController.AddAddress("http://test1.com", false);
            HistoryController.AddAddress("http://test2.com", false);
            HistoryController.AddAddress("http://www.amazon.co.uk", false);

            Console.WriteLine(String.Format("\n[{0}] ---- TEST HISTORY CONTROLLER ----", DateTime.Now));


            //
            // Testing SortHistory Method
            //
            Console.WriteLine(String.Format("[{0}] Testing SortHistory Method...", DateTime.Now));


            try
            {
                Console.WriteLine(String.Format("[{0}] Sorting with 'test', 2 results expected..", DateTime.Now));
                Models.History History = HistoryController.SortHistory("test");
                if (History.HistoryOfAddresses.Count == 2)
                    WriteLinePassed(String.Format("[{0}] Test passed..", DateTime.Now));
                else
                    WriteLineNotPassed(String.Format("[{0}] Test not passed...", DateTime.Now));
            }
            catch (Exception e)
            {
                WriteLineNotPassed(String.Format("[{0}] Test not passed...", DateTime.Now));
            }

            try
            {
                Console.WriteLine(String.Format("[{0}] Sorting with null, exception expected..", DateTime.Now));
                Models.History History = HistoryController.SortHistory(null);
                WriteLineNotPassed(String.Format("[{0}] Test not passed...", DateTime.Now));
            }
            catch (Exceptions.InvalidValuedVariableException e)
            {
                WriteLinePassed(String.Format("[{0}] Test passed..", DateTime.Now));
            }

            //
            // Testing AddAddress Method
            //
            Console.WriteLine(String.Format("[{0}] Testing AddAddress Method...", DateTime.Now));

            try
            {
                Console.WriteLine(String.Format("[{0}] Adding null..", DateTime.Now));
                HistoryController.AddAddress(null);
                WriteLineNotPassed(String.Format("[{0}] Test not passed...", DateTime.Now));
            }
            catch (Exceptions.InvalidValuedVariableException e)
            {
                WriteLinePassed(String.Format("[{0}] Test passed..", DateTime.Now));
            }

            //
            // Testing GetAddressAt Method
            //
            Console.WriteLine(String.Format("[{0}] Testing GetAddressAt Method...", DateTime.Now));

            try
            {
                Console.WriteLine(String.Format("[{0}] Getting first element..", DateTime.Now));
                HistoryController.GetAddressAt(0);
                WriteLinePassed(String.Format("[{0}] Test passed...", DateTime.Now));
            }
            catch (Exception e)
            {
                WriteLineNotPassed(String.Format("[{0}] Test not passed..", DateTime.Now));
            }

            try
            {
                Console.WriteLine(String.Format("[{0}] Getting out of bounds (-1) element..", DateTime.Now));
                HistoryController.GetAddressAt(-1);
                WriteLineNotPassed(String.Format("[{0}] Test not passed...", DateTime.Now));
            }
            catch (IndexOutOfRangeException e)
            {
                WriteLinePassed(String.Format("[{0}] Test passed..", DateTime.Now));
            }

        }

        public static void TestHomePageController()
        {

            Controllers.HomePageController HomePageController = new Controllers.HomePageController();

            Console.WriteLine(String.Format("\n[{0}] ---- TEST HOMEPAGE CONTROLLER ----", DateTime.Now));


            //
            // Testing ChangeHomePage Method
            //
            Console.WriteLine(String.Format("[{0}] Testing ChangeHomePage Method...", DateTime.Now));

            try
            {
                Console.WriteLine(String.Format("[{0}] Changing homepage to null value..", DateTime.Now));
                HomePageController.ChangeHomePage(null);
                WriteLineNotPassed(String.Format("[{0}] Test not passed...", DateTime.Now));
            }
            catch (Exceptions.InvalidValuedVariableException e)
            {
                WriteLinePassed(String.Format("[{0}] Test passed..", DateTime.Now));
            }
        }

        public static async Task TestNavigationControllerAsync()
        {

            Controllers.NavigationController NavigationController = new Controllers.NavigationController();

            Console.WriteLine(String.Format("\n[{0}] ---- TEST NAVIGATION CONTROLLER ----", DateTime.Now));


            //
            // Testing LoadPage Method
            //
            Console.WriteLine(String.Format("[{0}] Testing LoadPage Method...", DateTime.Now));

            try
            {
                Console.WriteLine(String.Format("[{0}] 404 Error expected..", DateTime.Now));
                Models.Page page = await NavigationController.LoadPage("https://httpstat.us/404", null);
                if (page is Models.NotFoundPage)
                    WriteLinePassed(String.Format("[{0}] Test passed..", DateTime.Now));
                else
                    WriteLineNotPassed(String.Format("[{0}] Test not passed...", DateTime.Now));
            }
            catch (Exception e)
            {
                WriteLineNotPassed(String.Format("[{0}] Test not passed...", DateTime.Now));
            }

            try
            {
                Console.WriteLine(String.Format("[{0}] 400 Error expected..", DateTime.Now));
                Models.Page page = await NavigationController.LoadPage("https://httpstat.us/400", null);
                if (page is Models.BadRequestPage)
                    WriteLinePassed(String.Format("[{0}] Test passed..", DateTime.Now));
                else
                    WriteLineNotPassed(String.Format("[{0}] Test not passed...", DateTime.Now));
            }
            catch (Exception e)
            {
                WriteLineNotPassed(String.Format("[{0}] Test not passed...", DateTime.Now));
            }

            try
            {
                Console.WriteLine(String.Format("[{0}] 403 Error expected..", DateTime.Now));
                Models.Page page = await NavigationController.LoadPage("https://httpstat.us/403", null);
                if (page is Models.ForbiddenPage)
                    WriteLinePassed(String.Format("[{0}] Test passed..", DateTime.Now));
                else
                    WriteLineNotPassed(String.Format("[{0}] Test not passed...", DateTime.Now));
            }
            catch (Exception e)
            {
                WriteLineNotPassed(String.Format("[{0}] Test not passed...", DateTime.Now));
            }

            try
            {
                Console.WriteLine(String.Format("[{0}] 500 Error expected..", DateTime.Now));
                Models.Page page = await NavigationController.LoadPage("https://httpstat.us/500", null);
                if (page is Models.ServerErrorPage)
                    WriteLinePassed(String.Format("[{0}] Test passed..", DateTime.Now));
                else
                    WriteLineNotPassed(String.Format("[{0}] Test not passed...", DateTime.Now));
            }
            catch (Exception e)
            {
                WriteLineNotPassed(String.Format("[{0}] Test not passed...", DateTime.Now));
            }

            try
            {
                Console.WriteLine(String.Format("[{0}] No Error expected..", DateTime.Now));
                Models.Page page = await NavigationController.LoadPage("https://httpstat.us/200", null);
                if (
                    page is Models.ServerErrorPage == false && 
                    page is Models.UnsupportedErrorPage == false &&
                    page is Models.ForbiddenPage == false &&
                    page is Models.BadRequestPage == false &&
                    page is Models.NotFoundPage == false)
                    WriteLinePassed(String.Format("[{0}] Test passed..", DateTime.Now));
                else
                    WriteLineNotPassed(String.Format("[{0}] Test not passed...", DateTime.Now));
            }
            catch (Exception e)
            {
                WriteLineNotPassed(String.Format("[{0}] Test not passed...", DateTime.Now));
            }

            //
            // Testing BackwardPage Method
            //
            Console.WriteLine(String.Format("[{0}] Testing BackwardPage Method...", DateTime.Now));

            try
            {
                Console.WriteLine(String.Format("[{0}] Exception expected..", DateTime.Now));
                Models.Page page = NavigationController.BackwardPage(null);
                WriteLineNotPassed(String.Format("[{0}] Test not passed...", DateTime.Now));
            }
            catch (Exceptions.InvalidValuedVariableException e)
            {
                WriteLinePassed(String.Format("[{0}] Test passed..", DateTime.Now));
            }

            //
            // Testing ForwardPage Method
            //
            Console.WriteLine(String.Format("[{0}] Testing ForwardPage Method...", DateTime.Now));

            try
            {
                Console.WriteLine(String.Format("[{0}] Exception expected..", DateTime.Now));
                Models.Page page = NavigationController.ForwardPage(null);
                WriteLineNotPassed(String.Format("[{0}] Test not passed...", DateTime.Now));
            }
            catch (Exceptions.InvalidValuedVariableException e)
            {
                WriteLinePassed(String.Format("[{0}] Test passed..", DateTime.Now));
            }

            //
            // Testing GetPageTitle Method
            //
            Console.WriteLine(String.Format("[{0}] Testing GetPageTitle Method...", DateTime.Now));

            try
            {
                Console.WriteLine(String.Format("[{0}] Exception expected..", DateTime.Now));
                NavigationController.GetPageTitle(null);
                WriteLineNotPassed(String.Format("[{0}] Test not passed...", DateTime.Now));
            }
            catch (Exceptions.InvalidValuedVariableException e)
            {
                WriteLinePassed(String.Format("[{0}] Test passed..", DateTime.Now));
            }
        }
    }
}
