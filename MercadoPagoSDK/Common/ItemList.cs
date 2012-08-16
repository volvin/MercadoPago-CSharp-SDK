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
    /// A representation of the item list resource. 
    /// </summary>
    public class ItemList : List<Item>
    {
        // todo: complete hole interface

        /// <summary>
        /// Create a new item list instance.
        /// </summary>
        public ItemList()
        {
            string json = "[]";
            _json = JSONObject.CreateFromString(json);
        }

        /// <summary>
        /// Create a new item list instance using a valid json.
        /// </summary>
        /// <param name="json">The json object used to
        /// fill the item list data</param>
        public ItemList(JSONObject json)
        {
            _json = json;
        }

        /// <summary>
        /// Add method override. 
        /// </summary>        
        public void Add(Item item)
        {
            _json.Array.Add(item.ToJSON());
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
        public Item this[int index]
        {
            get
            {
                return new Item(_json.Array[index]);
            }
            set
            {
                _json.Array[index] = value.ToJSON();
            }
        }

        /// <summary>
        /// Returns the item list as a json object.
        /// </summary>
        public JSONObject ToJSON()
        {
            return _json;
        }

        #region "Private Members"

        /// <summary>
        /// The item list as a json.
        /// </summary>
        private JSONObject _json;

        #endregion
    }
}
