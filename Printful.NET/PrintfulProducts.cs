using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Printful.NET
{
    /// <summary>
    /// Products are intended to be able to be enumerated, but apparently this functionality is currently broken.
    /// </summary>
    public class PrintfulProducts : PrintfulRequester
    {
        public PrintfulProducts(Printful printful) : base(printful)
        {
        }

        /// <summary>
        /// Return all products from the api
        /// </summary>
        /// <returns></returns>
        public string GetAllProducts()
        {
            string url = Printful.ApiUrl+"products";
            PrintfulRequestResult result = SendRequest(url, null, "GET");
            if (result.Success)
            {
                return result.RawBody;
            }
            return null;
        }

        /// <summary>
        /// Get information about a specific product
        /// </summary>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public string GetProduct(string type, string data)
        {
            string url = Printful.ApiUrl + "products";
            PrintfulRequestResult result = SendRequest(url, data, "POST");
            if (result != null && result.Success)
            {
                return result.RawBody;
            }
            return null;
        }
    }
}
