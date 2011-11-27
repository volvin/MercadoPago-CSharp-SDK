/*
 * Copyright 2010 Facebook, Inc.
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
    /// Wrapper around the Facebook Graph API. 
    /// </summary>
    public class RESTAPI
    {
        /// <summary>
        /// The access token used to authenticate API calls.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Create a new instance of the API, using the given token to
        /// authenticate.
        /// </summary>
        /// <param name="token">The access token used for
        /// authentication</param>
        public RESTAPI(Uri baseURL)
        {
            _baseURL = baseURL;
        }

        /// <summary>
        /// Create a new instance of the API, using the given token to
        /// authenticate.
        /// </summary>
        /// <param name="token">The access token used for
        /// authentication</param>
        public RESTAPI(Uri baseURL, string token)
        {
            _baseURL = baseURL;
            AccessToken = token;
        }

        /// <summary>
        /// Makes a Facebook Graph API GET request.
        /// </summary>
        /// <param name="relativePath">The path for the call,
        /// e.g. /username</param>
        public JSONObject Get(string relativePath)
        {
            return Call(relativePath, HttpVerb.GET, null);
        }

        /// <summary>
        /// Makes a Facebook Graph API GET request.
        /// </summary>
        /// <param name="relativePath">The path for the call,
        /// e.g. /username</param>
        /// <param name="args">A dictionary of key/value pairs that
        /// will get passed as query arguments.</param>
        public JSONObject Get(string relativePath, JSONObject json)
        {
            return Call(relativePath, HttpVerb.GET, json);
        }

        /// <summary>
        /// Makes a Facebook Graph API DELETE request.
        /// </summary>
        /// <param name="relativePath">The path for the call,
        /// e.g. /username</param>
        public JSONObject Delete(string relativePath)
        {
            return Call(relativePath, HttpVerb.DELETE, null);
        }

        /// <summary>
        /// Makes a Facebook Graph API POST request.
        /// </summary>
        /// <param name="relativePath">The path for the call,
        /// e.g. /username</param>
        /// <param name="args">A dictionary of key/value pairs that
        /// will get passed as query arguments. These determine
        /// what will get set in the graph API.</param>
        public JSONObject Post(string relativePath, JSONObject json, ContentType contentType = ContentType.JSON)
        {
            return Call(relativePath, HttpVerb.POST, json, contentType);
        }

        /// <summary>
        /// The base URL used to complete relative path.
        /// </summary>
        private Uri _baseURL;

        /// <summary>
        /// Makes a Facebook Graph API Call.
        /// </summary>
        /// <param name="relativePath">The path for the call, 
        /// e.g. /username</param>
        /// <param name="httpVerb">The HTTP verb to use, e.g.
        /// GET, POST, DELETE</param>
        /// <param name="args">A dictionary of key/value pairs that
        /// will get passed as query arguments.</param>
        private JSONObject Call(string relativePath, HttpVerb httpVerb, JSONObject json, ContentType contentType = ContentType.JSON)
        {
            Uri url = new Uri(_baseURL, relativePath);
            
            JSONObject obj = JSONObject.CreateFromString(MakeRequest(url, httpVerb, json, contentType));

            if (obj.IsDictionary && obj.Dictionary.ContainsKey("error"))
            {
                throw new RESTAPIException(obj.Dictionary["error"].Dictionary["type"].String, obj.Dictionary["error"].Dictionary["message"].String);
            }
            return obj;
        }

        /// <summary>
        /// Make an HTTP request, with the given query args
        /// </summary>
        /// <param name="url">The URL of the request</param>
        /// <param name="verb">The HTTP verb to use</param>
        /// <param name="args">Dictionary of key/value pairs that represents
        /// the key/value pairs for the request</param>
        private string MakeRequest(Uri url, HttpVerb httpVerb, JSONObject json, ContentType contentType = ContentType.JSON)
        {
            // Prepare HTTP url
            url = PrepareUrl(url, httpVerb, json, AccessToken, contentType);

            // Set request
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = httpVerb.ToString();

            // Prepare HTTP body
            if (httpVerb == HttpVerb.POST)
            {
                string postData = EncodeArgs(httpVerb, json, contentType);

                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] postDataBytes = encoding.GetBytes(postData);

                if (contentType == ContentType.JSON)
                {
                    request.ContentType = "application/json";
                }
                else
                {
                    request.ContentType = "application/x-www-form-urlencoded";
                }
                request.ContentLength = postDataBytes.Length;

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(postDataBytes, 0, postDataBytes.Length);
                requestStream.Close();
            }

            try
            {
                using (HttpWebResponse response 
                        = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader 
                        = new StreamReader(response.GetResponseStream());

                    return reader.ReadToEnd();
                }
            }
            catch (WebException e)
            {
                throw new RESTAPIException("Server Error", e.Message);
            }
        }

        private Uri PrepareUrl(Uri url, HttpVerb httpVerb, JSONObject json, string accessToken, ContentType contentType = ContentType.JSON)
        {
            if ((httpVerb == HttpVerb.GET) && (!string.IsNullOrEmpty(accessToken)) && (json != null && json.Dictionary.Keys.Count > 0) && (!string.IsNullOrEmpty(accessToken)))
            {
                // url + token + params
                url = new Uri(url.ToString() + "?access_token=" + accessToken + "&" + EncodeArgs(httpVerb, json, contentType));
            }
            else if ((!string.IsNullOrEmpty(accessToken)) && (((httpVerb == HttpVerb.GET) && (json == null || json.Dictionary.Keys.Count == 0)) || ((httpVerb != HttpVerb.GET) && (json != null && json.Dictionary.Keys.Count > 0))))
            {
                // just url + token
                url = new Uri(url.ToString() + "?access_token=" + accessToken);
            }
            else if ((httpVerb == HttpVerb.GET) && (json != null && json.Dictionary.Keys.Count > 0))
            {
                // just url + params
                url = new Uri(url.ToString() + "?" + EncodeArgs(httpVerb, json, contentType));            
            }
            else
            {
                // just url
            }
            return url;
        }

        /// <summary>
        /// Encode a dictionary of key/value pairs as an HTTP query string.
        /// </summary>
        /// <param name="dict">The dictionary to encode</param>
        /// <param name="questionMark">Whether or not to start it
        /// with a question mark (for GET requests)</param>
        private string EncodeArgs(HttpVerb httpVerb, JSONObject json, ContentType contentType = ContentType.JSON)
        {
            StringBuilder sb = new StringBuilder();
            if (contentType == ContentType.JSON)
            {
                if (httpVerb == HttpVerb.GET)
                {
                    sb.Append("json=");
                }
                sb.Append(json.ToString());
            }
            else
            {
                foreach (KeyValuePair<string, JSONObject> kvp in json.Dictionary)
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
    }
}
