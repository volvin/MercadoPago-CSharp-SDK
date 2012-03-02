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
    /// A representation of the collection notification resource. 
    /// </summary>
    public class CollectionNotification
    {
        /// <summary>
        /// The collection within the notification.
        /// </summary>
        private Collection _collection;

        /// <summary>
        /// The collection notification as a json.
        /// </summary>
        private JSONObject _json;

        public CollectionNotification(JSONObject json)
        {
            // todo: strong type validation
            _json = json;

            // set collection values
            _collection = new Collection(_json.Dictionary["collection"]);
        }

        /// <summary>
        /// Collection field.
        /// </summary>
        public Collection Collection
        {
            get
            {
                return _collection;
            }
        }

        /// <summary>
        /// Returns the collection notification as a json object.
        /// </summary>
        public JSONObject ToJSON()
        {
            return _json;
        }
    }
}
