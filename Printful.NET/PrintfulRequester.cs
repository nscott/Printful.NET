using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace Printful.NET
{
    public class PrintfulRequester
    {
        protected Printful _printful;
        public PrintfulRequester(Printful printful)
        {
            _printful = printful;
        }

        /// <summary>
        /// Send a request to Printful with already-parsed json. It automatically uses the assigned API key.
        /// </summary>
        /// <param name="url">API url to hit</param>
        /// <param name="jsonData">The data in question</param>
        /// <param name="verb">GET/POST/UPDATE/etc</param>
        /// <returns>true on success, false otherwise</returns>
        protected PrintfulRequestResult SendRequest(string url, string jsonData, string verb)
        {
            PrintfulRequestResult result = new PrintfulRequestResult();
            try
            {
                if (String.IsNullOrEmpty(_printful.ApiKey))
                {
                    throw new PrintfulException("No Printful API key set!");
                }
                if (String.IsNullOrEmpty(url))
                {
                    throw new PrintfulException("No URL was specified. This should never happen.");
                }

                if (_printful.VerboseLogging)
                {
                    _printful.WriteInfo(String.Format("Sending request to {0} via {1} with data: {2}", url, verb, jsonData));
                }

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.ContentType = "application/json";
                request.Method = verb;
                //5 second timeout
                request.Timeout = 5 * 1000;

                //The printful api doesn't do a full auth handshake and simply fails, so we have to do basic header auth ourselves
                //if that ever changes, here's a simple creds
                //request.Credentials = new NetworkCredential(null, _printful.ApiKey);

                string authInfo = _printful.ApiKey;
                authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                request.Headers["Authorization"] = "Basic "+authInfo;

                //write the body
                if (jsonData != null)
                {
                    request.ContentLength = jsonData.Length;
                    using (StreamWriter sw = new StreamWriter(request.GetRequestStream()))
                    {
                        sw.Write(jsonData);
                        sw.Flush();
                    }
                }

                //kick off the actual request
                using (HttpWebResponse wr = (HttpWebResponse)request.GetResponse())
                {
                    string responseBody = "";
                    using (StreamReader sr = new StreamReader(wr.GetResponseStream()))
                    {
                        responseBody = sr.ReadToEnd();
                        result.RawBody = responseBody;
                        if (_printful.VerboseLogging)
                        {
                            _printful.WriteInfo(String.Format("Request to {0} returned {1} ({2}): {3}", url, wr.StatusCode, (int)wr.StatusCode, responseBody));
                        }
                    }

                    wr.Close();
                }
                
                result.Success = true;
            }
            catch (Exception e)
            {
                _printful.LastErrorMessage = e.Message;
                result.Success = false;
                if (_printful.LetExceptionsBubble)
                {
                    throw;
                }
            }
            return result;
        }
    }
}
