using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebBrowser.Controllers
{
    /// <summary>
    /// Controller class responsible for the intelligence code linked to the Navigation management
    /// </summary>
    public class NavigationController
    {

        /// <summary>
        /// Holds a static unique instance of the <seealso cref="Controllers.HttpRequestController"/> class
        /// </summary>
        private static HttpRequestController httpRequestController = new HttpRequestController();

        /// <summary>
        /// <seealso cref="Stack{Models.Page}"/> holding the pages that were visited before the current page
        /// </summary>
        private static Stack<Models.Page> backwardPages = new Stack<Models.Page>();
        /// <summary>
        /// <seealso cref="Stack{Models.Page}"/> holding the pages that were visited after the current page
        /// </summary>
        private static Stack<Models.Page> forwardPages = new Stack<Models.Page>();

        /// <summary>
        /// The class constructor, empty
        /// </summary>
        public NavigationController()
        {

        }

        /// <summary>
        /// Async method retrieving the string content of the HTML page to load and wrapping it in a class.
        /// </summary>
        /// <param name="address">String of the web page address to visit</param>
        /// <param name="formerPage"><seealso cref="Models.Page"/> instance of the former page</param>
        /// <returns><seealso cref="Task{Models.Page}"/>: loaded page returned in a Task. Can also return any error page depending on the HttpError exception thrown by the <seealso cref="HttpRequestController"/></returns>
        public async Task<Models.Page> LoadPage(string address, Models.Page formerPage)
        {

            if (formerPage != null)
            {
                backwardPages.Push(formerPage);
            }
            if (address != null && address != "")
            {

                try
                {
                    var responseBody = await httpRequestController.SendGetAsync(address);
                    return new Models.Page(address, responseBody);
                }
                catch (Exceptions.PageNotFoundException e)
                {
                    return new Models.NotFoundPage(address);
                }
                catch (Exceptions.ServerErrorException)
                {
                    return new Models.ServerErrorPage(address);
                }
                catch (Exceptions.BadRequestException)
                {
                    return new Models.BadRequestPage(address);
                }
                catch (Exceptions.ForbiddenPageException)
                {
                    return new Models.ForbiddenPage(address);
                }
                catch (Exceptions.UnsupportedErrorException)
                {
                    return new Models.UnsupportedErrorPage(address);
                }
                
            } else
            {
                Models.Page page = new Models.NotFoundPage(address);
                return page;
            }
        }

        /// <summary>
        /// Retrieve the <seealso cref="Models.Page"/> instance that was right before the current page
        /// </summary>
        /// <param name="currentPage">Current page to be added to the <seealso cref="Controllers.NavigationController.forwardPages"/> stack</param>
        /// <returns>The Page instance that came before the current page. If no page before, returns the currentPage</returns>
        public Models.Page BackwardPage(Models.Page currentPage)
        {
            if (currentPage == null)
            {
                throw new Exceptions.InvalidValuedVariableException("currentPage cannot be null.");
            }

            if (backwardPages.Count != 0)
            {
                forwardPages.Push(currentPage);
                Models.Page toReturn = backwardPages.Pop();
                if (toReturn == null)
                {
                    throw new Exceptions.InvalidValuedVariableException("Returned Page cannot be null.");
                }
                return toReturn;
            } else
            {
                return currentPage;
            }
        }

        /// <summary>
        /// Retrieve the <seealso cref="Models.Page"/> instance that was right after the current page
        /// </summary>
        /// <param name="currentPage">Current page to be added to the <seealso cref="Controllers.NavigationController.backwardPages"/> stack</param>
        /// <returns><seealso cref="Models.Page"/>: the Page instance that came after the current page. If no page after, returns the currentPage</returns>
        public Models.Page ForwardPage(Models.Page currentPage)
        {
            if (currentPage == null)
            {
                throw new Exceptions.InvalidValuedVariableException("currentPage cannot be null.");
            }
            if (forwardPages.Count != 0)
            {
                backwardPages.Push(currentPage);
                Models.Page toReturn = forwardPages.Pop();
                if (toReturn == null)
                {
                    throw new Exceptions.InvalidValuedVariableException("Returned Page cannot be null.");
                }
                return toReturn;
            }
            else
            {
                return currentPage;
            }

        }

        /// <summary>
        /// Returns the HTML page title as a string using the <seealso cref="Regex"/>class.
        /// </summary>
        /// <param name="currentPage">Current page from which we want to retrieve the title</param>
        /// <returns><seealso cref="string"/>: title of the HTML Page</returns>
        public string GetPageTitle(Models.Page currentPage)
        {
            if (currentPage == null)
            {
                throw new Exceptions.InvalidValuedVariableException("currentPage cannot be null.");
            }
            return Regex.Match(currentPage.Content, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value;
        }

    }
}
