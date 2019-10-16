using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser.Controllers
{
    public class NavigationController
    {

        private HttpRequestController httpRequestController = new HttpRequestController();

        private Stack<Models.Page> backwardPages = new Stack<Models.Page>();
        private Stack<Models.Page> forwardPages = new Stack<Models.Page>();

        public NavigationController()
        {

        }

        public async Task<Models.Page> loadPage(string address, Models.Page formerPage)
        {
            this.backwardPages.Push(formerPage);
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

        public Models.Page backwardPage(Models.Page currentPage)
        {
            if (this.backwardPages.Count != 0)
            {
                this.forwardPages.Push(currentPage);
                return this.backwardPages.Pop();
            } else
            {
                return currentPage;
            }
        }

        public Models.Page forwardPage(Models.Page currentPage)
        {
            if (this.forwardPages.Count != 0)
            {
                this.backwardPages.Push(currentPage);
                return this.forwardPages.Pop();
            }
            else
            {
                return currentPage;
            }

        }

    }
}
