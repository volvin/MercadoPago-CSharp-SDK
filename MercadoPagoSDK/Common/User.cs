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
    /// A representation of the user resource. 
    /// </summary>
    public class User
    {
        /// <summary>
        /// The user as a json.
        /// </summary>
        private JSONObject _json;

        /// <summary>
        /// Create a new user instance with empty values.
        /// </summary>
        public User()
        {
            string json = "{}";

            _json = JSONObject.CreateFromString(json);
        }

        /// <summary>
        /// Create a new user instance using a valid json.
        /// </summary>
        /// <param name="json">The json object used to
        /// fill the user data</param>
        public User(JSONObject json)
        {
            // todo: strong type validation
            _json = json;
        }

        /// <summary>
        /// Email field.
        /// </summary>
        public String Email
        {
            get
            {
                return _json.GetJSONStringAttribute("email");
            }
            set
            {
                _json.SetJSONStringAttribute("email", value);
            }
        }

        /// <summary>
        /// FirstName field.
        /// </summary>
        public String FirstName
        {
            get
            {
                return _json.GetJSONStringAttribute("first_name");
            }
            set
            {
                _json.SetJSONStringAttribute("first_name", value);
            }
        }

        /// <summary>
        /// Id field.
        /// </summary>
        public Int32? Id
        {
            get
            {
                return _json.GetJSONInt32Attribute("id");
            }
        }

        /// <summary>
        /// LastName field.
        /// </summary>
        public String LastName
        {
            get
            {
                return _json.GetJSONStringAttribute("last_name");
            }
            set
            {
                _json.SetJSONStringAttribute("last_name", value);
            }
        }

        /// <summary>
        /// Nickname field.
        /// </summary>
        public String Nickname
        {
            get
            {
                return _json.GetJSONStringAttribute("nickname");
            }
            set
            {
                _json.SetJSONStringAttribute("nickname", value);
            }
        }

        /// <summary>
        /// Phone field.
        /// </summary>
        public Phone Phone
        {
            get
            {
                return new Phone(_json.GetJSONCustomClassAttribute("phone"));
            }
            set
            {
                _json.SetJSONCustomClassAttribute("phone", value.ToJSON());
            }
        }

        /// <summary>
        /// Returns the user as a json object.
        /// </summary>
        public JSONObject ToJSON()
        {
            return _json;
        }
    }
}
