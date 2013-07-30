using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Net;

namespace Printful.NET
{
    public class Printful
    {
        /// <summary>
        /// Current API version for Printful
        /// </summary>
        public static string Version = "1.0";

        /// <summary>
        /// The current API url for Printful.
        /// </summary>
        public static string ApiUrl = "https://api.theprintful.com/v1/";

        /// <summary>
        /// ApiKey is simply your Printful API key
        /// </summary>
        public string ApiKey { get; set; }


        private string _lastErrorMessage;
        /// <summary>
        /// This holds the last error message we received
        /// </summary>
        public string LastErrorMessage
        {
            get
            {
                return _lastErrorMessage;
            }

            set
            {
                _lastErrorMessage = value;
                WriteInfo(value);
            }
        }

        /// <summary>
        /// If verbose logging is set to true, more general info and error information will be put into Information
        /// </summary>
        public bool VerboseLogging { get; set; }

        /// <summary>
        /// This simply holds any extra logging information.
        /// </summary>
        public string Information
        {
            get
            {
                if (InformationBuilder == null)
                {
                    return null;
                }
                else
                {
                    return InformationBuilder.ToString();
                }
            }
        }

        /// <summary>
        /// If this is set to true, exceptions will bubble out of this API if you wish to catch them. Otherwise they will be swallowed.
        /// </summary>
        public bool LetExceptionsBubble { get; set; }

        /// <summary>
        /// Printful Orders. Methods contained here give full CRUD for Orders
        /// </summary>
        public PrintfulOrders Orders { get; private set; }

        /// <summary>
        /// Products will let you list & obtain more information on specific products
        /// </summary>
        public PrintfulProducts Products { get; private set; }

        /// <summary>
        /// This lets us build the information string more efficiently
        /// </summary>
        private StringBuilder InformationBuilder { get; set; }

        /// <summary>
        /// At most, the information string can be 32k
        /// </summary>
        private static int MaxInformationBuilderSize = 1024 * 32;

        /// <summary>
        /// Create a new printful API. This just sets some defaults about the API in general.
        /// By default, it sets the request number to 1 and verbose errors to false.
        /// </summary>
        public Printful(string apiKey)
        {
            ApiKey = apiKey;
            LetExceptionsBubble = false;
            InformationBuilder = new StringBuilder(1024);

            Orders = new PrintfulOrders(this);
            Products = new PrintfulProducts(this);
        }

        public void WriteInfo(string msg)
        {
            if (InformationBuilder == null)
            {
                InformationBuilder = new StringBuilder();
            }

            if (msg != null)
            {
                InformationBuilder.AppendLine("[" + DateTime.UtcNow.ToString() + "] " + msg);
            }

            if (InformationBuilder.Length > Printful.MaxInformationBuilderSize)
            {
                //remove the oldest 1k chunks
                if (InformationBuilder.Length > 1024)
                {
                    InformationBuilder.Remove(0, 1024);
                }
            }
        }
    }
}
