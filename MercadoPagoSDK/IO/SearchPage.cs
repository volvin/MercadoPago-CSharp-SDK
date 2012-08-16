/*
 * Copyright 2011 MercadoLibre, Inc.
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
using System.Linq;
using System.Text;

namespace MercadoPagoSDK
{
    /// <summary>
    /// A representation of the search page resource. 
    /// </summary>
    public class SearchPage<T>
    {
        /// <summary>
        /// Create a new credential instance using a valid json.
        /// </summary>
        /// <param name="json">The json object used to
        /// fill the credential data</param>
        public static SearchPage<T> CreateInstance(JSONObject json)
        {
            // todo: strong type validation
            SearchPage<T> instance = new SearchPage<T>();
            instance._json = json;
            return instance;
        }

        /// <summary>
        /// Limit field.
        /// </summary>
        public Int32? Limit
        {
            get
            {
                return _json.Dictionary["paging"].GetJSONInt32Attribute("limit");
            }
        }

        /// <summary>
        /// Offset field.
        /// </summary>
        public Int32? Offset
        {
            get
            {
                return _json.Dictionary["paging"].GetJSONInt32Attribute("offset");
            }
        }

        /// <summary>
        /// Results field.
        /// </summary>
        public List<T> Results
        {
            get 
            {
                List<T> objList = new List<T>();
                foreach (JSONObject result in _json.Dictionary["results"].Array)
                {
                    object[] args = new object[1];
                    string ss = typeof(T).FullName;
                    if (ss == "MercadoPagoSDK.Collection")
                    {
                        args[0] = result.Dictionary["collection"];  // this is a hack for the collections api
                    }
                    else
                    {
                        args[0] = result;
                    }
                    T obj = CreateObject(args);
                    objList.Add(obj);
                }

                return objList;
            }
        }

        /// <summary>
        /// Total field.
        /// </summary>
        public Int32? Total
        {
            get 
            {
                return _json.Dictionary["paging"].GetJSONInt32Attribute("total");
            }
        }

        /// <summary>
        /// Returns the credential as a json object.
        /// </summary>
        public JSONObject ToJSON()
        {
            return _json;
        }

        #region Private Members

        /// <summary>
        /// The search page as a json.
        /// </summary>
        private JSONObject _json;

        /// <summary>
        /// Creates an instance of the T class with parameterized constructor.
        /// </summary>
        private T CreateObject(params object[] args)
        {
            return (T)Activator.CreateInstance(typeof(T), args);
        }

        #endregion
    }
}
