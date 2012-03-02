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
    /// A representation of the id list resource. 
    /// </summary>
    public class IdList : List<string>
    {
        /// <summary>
        /// The id list as a json.
        /// </summary>
        private JSONObject _json;

        // todo: complete hole interface

        /// <summary>
        /// Create a new id list instance.
        /// </summary>
        public IdList()
        {
            string json = "[]";
            _json = JSONObject.CreateFromString(json);
        }

        /// <summary>
        /// Create a new id list instance using a valid json.
        /// </summary>
        /// <param name="json">The json object used to
        /// fill the id list data</param>
        public IdList(JSONObject json)
        {
            _json = json;
        }

        /// <summary>
        /// Add method override. 
        /// </summary>
        public void Add(string id)
        {
            _json.Array.Add(JSONObject.CreateFromString(id));
        }

        /// <summary>
        /// Count method override. 
        /// </summary>
        public int Count
        {
            get
            {
                return _json.Array.Count;
            }
        }

        /// <summary>
        /// Remove method override. 
        /// </summary>
        public bool Remove(Item item)
        {
            return true;
        }

        /// <summary>
        /// List item override. 
        /// </summary>
        public string this[int index]
        {
            get
            {
                return _json.Array[index].ToString();
            }
            set
            {
                _json.Array[index] = JSONObject.CreateFromString(value);
            }
        }

        /// <summary>
        /// Returns the id list as a json object.
        /// </summary>
        public JSONObject ToJSON()
        {
            return _json;
        }
    }
}
