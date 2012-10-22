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

namespace MercadoPagoSDK
{
    /// <summary>
    /// A representation of the amount by transaction type list resource. 
    /// </summary>
    public class AmountByTTypeList
    {
        /// <summary>
        /// Create a new amount by transaction type list instance.
        /// </summary>
        public AmountByTTypeList()
        {
            string json = "[]";
            _json = JSONObject.CreateFromString(json);
        }

        /// <summary>
        /// Create a new amount by transaction type list instance using a valid json.
        /// </summary>
        /// <param name="json">The json object used to
        /// fill the amount by transaction type list data</param>
        public AmountByTTypeList(JSONObject json)
        {
            _json = json;
        }

        /// <summary>
        /// Add method. 
        /// </summary>        
        public void Add(AmountByTTypeItem item)
        {
            _json.Array.Add(item.ToJSON());
        }

        /// <summary>
        /// Count method. 
        /// </summary>
        public int Count
        {
            get
            {
                return _json.Array.Count;
            }
        }

        /// <summary>
        /// Remove method. 
        /// </summary>
        public bool Remove(AmountByTTypeItem item)
        {
            return true;
        }

        /// <summary>
        /// List item. 
        /// </summary>
        public AmountByTTypeItem this[int index]
        {
            get
            {
                return new AmountByTTypeItem(_json.Array[index]);
            }
            set
            {
                _json.Array[index] = value.ToJSON();
            }
        }

        /// <summary>
        /// Returns the amount by transaction type list as a json object.
        /// </summary>
        public JSONObject ToJSON()
        {
            return _json;
        }

        /// <summary>
        /// Returns the amount by transaction type list as a List_AmountByTTypeItem_ object.
        /// </summary>
        public List<AmountByTTypeItem> ToList()
        {
            List<AmountByTTypeItem> list = new List<AmountByTTypeItem>();

            for (int index = 0; index <= (_json.Array.Count - 1); index++)
            {
                list.Add(new AmountByTTypeItem(_json.Array[index]));
            }

            return list;
        }

        #region "Private Members"

        /// <summary>
        /// The amount by transaction type list as a json.
        /// </summary>
        private JSONObject _json;

        #endregion
    }
}
