using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebBrowser.Controllers
{
    public class NavigationController
    {

        private static HttpRequestController httpRequestController = new HttpRequestController();

        private static Stack<Models.Page> backwardPages = new Stack<Models.Page>();
        private static Stack<Models.Page> forwardPages = new Stack<Models.Page>();

        public NavigationController()
        {

        }

        public async Task<Models.Page> LoadPage(string address, Models.Page formerPage)
        {
            backwardPages.Push(formerPage);
            if (address != null && address != "")
            {

                try
                {
                    var responseBody = await httpRequestController.sendGetAsync(address);
                    return new Models.Page(address, responseBody);
                }
                catch (Exceptions.PageNotFoundException)
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

        public Models.Page BackwardPage(Models.Page currentPage)
        {
            if (backwardPages.Count != 0)
            {
                forwardPages.Push(currentPage);
                return backwardPages.Pop();
            } else
            {
                return currentPage;
            }
        }

        public Models.Page ForwardPage(Models.Page currentPage)
        {
            if (forwardPages.Count != 0)
            {
                backwardPages.Push(currentPage);
                return forwardPages.Pop();
            }
            else
            {
                return currentPage;
            }

        }

        public string GetPageTitle(Models.Page currentPage)
        {
            return Regex.Match(currentPage.Content, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value;
        }

    }
}
