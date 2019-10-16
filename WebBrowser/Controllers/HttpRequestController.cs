using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace WebBrowser.Controllers
{
    class HttpRequestController
    {
        private static readonly HttpClient client = new HttpClient();

        public HttpRequestController() {

        }

        public async Task<string> sendGetAsync(string address)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(address);
                switch (response.StatusCode)
                {
                    case System.Net.HttpStatusCode.NotFound:
                        throw new Exceptions.PageNotFoundException(String.Format("Error: page '{0}' not found", address));

                    case System.Net.HttpStatusCode.InternalServerError:
                        throw new Exceptions.ServerErrorException(String.Format("Error: acces to page '{0}' led to internal server error", address));

                    case System.Net.HttpStatusCode.BadRequest:
                        throw new Exceptions.BadRequestException(String.Format("Error: page '{0}' returned a Bad Request HTTP Error code", address));

                    case System.Net.HttpStatusCode.Forbidden:
                        throw new Exceptions.ForbiddenPageException(String.Format("Error: acces to page '{0}' forbidden", address));

                    case System.Net.HttpStatusCode.OK:
                    case System.Net.HttpStatusCode.Found:
                        string responseBody = await response.Content.ReadAsStringAsync();
                        return responseBody;

                    default:
                        throw new Exceptions.UnsupportedErrorException(String.Format("Unsupported error triggered when loading '{0}'", address));

                }

            } catch (HttpRequestException e)
            {
                throw new Exceptions.UnsupportedErrorException(e.Message);
            }
        }

    }
}
