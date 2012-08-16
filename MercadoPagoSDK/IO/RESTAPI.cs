/*
 * Copyright 2010 Facebook, Inc.
 * Copyright 2011 MercadoLibre, Inc.
 * 
 * General purpose REST API based on FacebookAPI class.
 * -User defined API Base URL 
 * -HTTP or JSON content types supported.
 * -MercadoLibre API access token included in full path url.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"); you may
 * not use this file except in compliance with the License. You may obtain
 * a copy of the License at
 * 
 *  http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations
 * under the License.
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Web;
using System.Web.Script.Serialization;

namespace MercadoPagoSDK
{
    public enum ContentType
    {
        HTTP,
        JSON
    }

    enum HttpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    /// <summary>
    /// Generic REST API util. 
    /// </summary>
    public class RESTAPI
    {
        /// <summary>
        /// The access token used to authenticate API calls.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Create a new instance of the API
        /// </summary>
        /// <param name="baseURL">The domain of the API URL
        /// </param>
        public RESTAPI(Uri baseURL)
        {
            _baseURL = baseURL;
        }

        /// <summary>
        /// Create a new instance of the API, using the given token to
        /// authenticate.
        /// </summary>
        /// <param name="baseURL">The domain of the API URL
        /// </param>
        /// <param name="token">The access token used for
        /// authentication</param>
        public RESTAPI(Uri baseURL, string token)
        {
            _baseURL = baseURL;
            AccessToken = token;
        }

        /// <summary>
        /// Makes a MercadoLibre API DELETE request.
        /// </summary>
        /// <param name="relativePath">The path for the call,
        /// e.g. /username</param>
        public JSONObject Delete(string relativePath)
        {
            return Call(relativePath, HttpVerb.DELETE, null, null);
        }

        /// <summary>
        /// Makes a MercadoLibre API GET request.
        /// </summary>
        /// <param name="relativePath">The path for the call,
        /// e.g. /username</param>
        public JSONObject Get(string relativePath)
        {
            return Call(relativePath, HttpVerb.GET, null, null);
        }

        /// <summary>
        /// Makes a MercadoLibre API GET request.
        /// </summary>
        /// <param name="relativePath">The path for the call,
        /// e.g. /username</param>
        /// <param name="args">A Key/Value list of strings that
        /// will get passed as query arguments.</param>
        public JSONObject Get(string relativePath, List<KeyValuePair<string, string>> args)
        {
            return Call(relativePath, HttpVerb.GET, args, null, ContentType.HTTP);
        }

        /// <summary>
        /// Makes a MercadoLibre API POST request.
        /// </summary>
        /// <param name="relativePath">The path for the call,
        /// e.g. /username</param>
        /// <param name="json">A json object that
        /// will get passed as the request body.</param>
        /// <param name="contentType">The data format of the json to be written 
        /// in the request body.</param>
        public JSONObject Post(string relativePath, JSONObject json, ContentType contentType = ContentType.JSON)
        {
            return Call(relativePath, HttpVerb.POST, null, json, contentType);
        }

        /// <summary>
        /// Makes a MercadoLibre API PUT request.
        /// </summary>
        /// <param name="relativePath">The path for the call,
        /// e.g. /username</param>
        /// <param name="json">A json object that
        /// will get passed as the request body.</param>
        /// <param name="contentType">The data format of the json to be written 
        /// in the request body.</param>
        public JSONObject Put(string relativePath, JSONObject json, ContentType contentType = ContentType.JSON)
        {
            return Call(relativePath, HttpVerb.PUT, null, json, contentType);
        }

        #region "Private Members"

        /// <summary>
        /// The base URL used to complete relative path.
        /// </summary>
        private Uri _baseURL;

        /// <summary>
        /// Makes a MercadoLibre API Call.
        /// </summary>
        private JSONObject Call(string relativePath, HttpVerb httpVerb, List<KeyValuePair<string, string>> args, JSONObject body, ContentType contentType = ContentType.JSON)
        {
            Uri url = new Uri(_baseURL, relativePath);
            
            JSONObject obj = JSONObject.CreateFromString(MakeRequest(url, httpVerb, args, body, contentType));

            return obj;
        }

        /// <summary>
        /// Encode a key/value list of arguments as a HTTP query string.
        /// </summary>
        private string EncodeArgs(List<KeyValuePair<string, string>> args)
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, string> kvp in args)
            {
                sb.Append(HttpUtility.UrlEncode(kvp.Key));
                sb.Append("=");
                string str = kvp.Value.ToString();
                if (str.Substring(0, 1) == "\"")
                {
                    str = str.Substring(1, str.Length - 2); // rip "
                }
                sb.Append(HttpUtility.UrlEncode(str));
                sb.Append("&");
            }
            sb.Remove(sb.Length - 1, 1); // Remove trailing &            
            return sb.ToString();
        }

        /// <summary>
        /// Encode a json body as a json string or a http string.
        /// </summary>
        private string EncodeBody(JSONObject body, ContentType contentType = ContentType.JSON)
        {
            StringBuilder sb = new StringBuilder();
            if (contentType == ContentType.JSON)
            {
                sb.Append(body.ToString());
            }
            else
            {
                foreach (KeyValuePair<string, JSONObject> kvp in body.Dictionary)
                {
                    sb.Append(HttpUtility.UrlEncode(kvp.Key));
                    sb.Append("=");
                    string str = kvp.Value.ToString();
                    if (str.Substring(0, 1) == "\"")
                    {
                        str = str.Substring(1, str.Length - 2); // rip "
                    }
                    sb.Append(HttpUtility.UrlEncode(str));
                    sb.Append("&");
                }
                sb.Remove(sb.Length - 1, 1); // Remove trailing &            
            }
            return sb.ToString();
        }

        /// <summary>
        /// Make an HTTP request, with the given query args
        /// </summary>
        private string MakeRequest(Uri url, HttpVerb httpVerb, List<KeyValuePair<string, string>> args, JSONObject body, ContentType contentType = ContentType.JSON)
        {
            // Prepare HTTP url
            url = PrepareUrl(url, AccessToken, args);

            // Set request
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = httpVerb.ToString();

            if ((httpVerb == HttpVerb.POST) || (httpVerb == HttpVerb.PUT))
            {
                // Prepare HTTP body
                string postData = EncodeBody(body, contentType);
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] postDataBytes = encoding.GetBytes(postData);

                // Set content type & length
                if (contentType == ContentType.JSON)
                {
                    request.ContentType = "application/json";
                }
                else
                {
                    request.ContentType = "application/x-www-form-urlencoded";
                }
                request.ContentLength = postDataBytes.Length;

                // Call API
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(postDataBytes, 0, postDataBytes.Length);
                requestStream.Close();
            }

            try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    // Read response data
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string responseBody = reader.ReadToEnd();

                    // Understand REST response
                    if (SuccessfulCall(response.StatusCode))
                    {
                        // Ok
                        return responseBody;
                    }
                    else
                    {
                        // Problem
                        try
                        {
                            // Try throwing a well-formed api error
                            JSONObject errorBody = JSONObject.CreateFromString(responseBody);
                            throw new RESTAPIException(errorBody.Dictionary["error"].Dictionary["type"].String, errorBody.Dictionary["error"].Dictionary["message"].String);
                        }
                        catch (RESTAPIException restEx)
                        {
                            throw restEx;  // this is a well-formed error message
                        }
                        catch
                        {
                            throw new RESTAPIException(response.StatusCode.ToString(), responseBody);  // this is not a well-formed message
                        }
                    }
                }
            }
            catch (WebException e)
            {
                throw new RESTAPIException("Server Error", e.Message);
            }
        }

        /// <summary>
        /// Prepares API url including access token and extra parameters.
        /// </summary>
        private Uri PrepareUrl(Uri url, string accessToken, List<KeyValuePair<string, string>> args)
        {
            if ((!string.IsNullOrEmpty(accessToken)) && (args != null && args.Count > 0))
            {
                // url + token + params
                url = new Uri(url.ToString() + "?access_token=" + accessToken + "&" + EncodeArgs(args));
            }
            else if ((!string.IsNullOrEmpty(accessToken)) && (args == null || args.Count == 0))
            {
                // just url + token
                url = new Uri(url.ToString() + "?access_token=" + accessToken);
            }
            else if ((string.IsNullOrEmpty(accessToken)) && (args != null && args.Count > 0))
            {
                // just url + params
                url = new Uri(url.ToString() + "?" + EncodeArgs(args));            
            }
            else
            {
                // just url
            }
            return url;
        }

        /// <summary>
        /// Defines wether or not an API call was successful.
        /// </summary>
        private bool SuccessfulCall(HttpStatusCode status)
        { 
            switch (status)
            {
                case HttpStatusCode.Accepted: case HttpStatusCode.Continue: case HttpStatusCode.Created: case HttpStatusCode.NoContent: 
                case HttpStatusCode.NonAuthoritativeInformation: case HttpStatusCode.OK: case HttpStatusCode.PartialContent:
                case HttpStatusCode.ResetContent: case HttpStatusCode.SwitchingProtocols:
                    return true;
                default:
                    return false;
            }
        }

        #endregion
    }
}
