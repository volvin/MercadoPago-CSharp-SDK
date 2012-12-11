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
using System.Text;
using MercadoPagoSDK.Helpers;

namespace MercadoPagoSDK
{
    /// <summary>
    /// A helper for Users API operations. 
    /// </summary>
    public class UsersHelper : BaseHelper
    {
        /// <summary>
        /// Gets a user. 
        /// </summary>
		public User GetUser(Int32 userId)
		{
            JSONObject json = _api.Get(SettingsHelper.UsersUri + "/" + userId.ToString());
            User user = new User(json);

            return user;
        }
    }
}
