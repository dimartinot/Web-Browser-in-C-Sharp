using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Security;

namespace WebBrowser.Controllers
{
    /// <summary>
    /// Controller class responsible for the intelligence code linked to the HttpRequest management
    /// </summary>
    class HttpRequestController
    {
        /// <summary>
        /// The HttpClient attribute, setup as static and readonly to be sure to only have one instance generated per App
        /// </summary>
        private static readonly HttpClient client = new HttpClient();

        //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Ss13 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

        /// <summary>
        /// The class constructor, empty
        /// </summary>
        public HttpRequestController() {

        }

        /// <summary>
        /// Async method retrieving the string content of the HTML page to load
        /// </summary>
        /// <param name="address">Url of the Web Page to access passed as a string</param>
        /// <returns>A Task embedding the string content of the HTML page to load</returns>
        public async Task<string> SendGetAsync(string address)
        {
            if (address == null)
            {
                throw new Exceptions.InvalidValuedVariableException("Address to add cannot be null.");
            }
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
                        System.Console.WriteLine(String.Format("Error {0}: Unsupported error triggered when loading '{1}'", response.StatusCode, address));
                        throw new Exceptions.UnsupportedErrorException(String.Format("Error {0}: Unsupported error triggered when loading '{1}'", response.StatusCode, address));

                }

            } catch (HttpRequestException e)
            {
                System.Console.WriteLine(String.Format("Error {0}: Unsupported error triggered when loading '{1}'", e.InnerException.Message, address));
                throw new Exceptions.UnsupportedErrorException(e.Message);
            } catch (Exception e)
            {
                throw new Exceptions.PageNotFoundException(String.Format("Error: page '{0}' not found", address));
            }
        }

    }
}
