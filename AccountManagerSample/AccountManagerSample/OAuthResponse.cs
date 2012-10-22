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

namespace AccountManagerSample
{
    /// <summary>
    /// A representation of the OAuth response. 
    /// </summary>
    public class OAuthResponse
    {
        /// <summary>
        /// Create a new OAuth response instance.
        /// </summary>
        public OAuthResponse(string accessToken, DateTime expirationDate, Int32 userId)
        {
            _accessToken = accessToken;
            _expirationDate = expirationDate;
            _userId = userId;
        }

        /// <summary>
        /// AccessToken field.
        /// </summary>
        public string AccessToken
        {
            get
            {
                return _accessToken;
            }
        }

        /// <summary>
        /// ExpirationDate field.
        /// </summary>
        public DateTime ExpirationDate
        {
            get
            {
                return _expirationDate;
            }
        }

        /// <summary>
        /// UserId field.
        /// </summary>
        public Int32 UserId
        {
            get
            {
                return _userId;
            }
        }

        #region "Private Members"

        private string _accessToken;
        private DateTime _expirationDate;
        private Int32 _userId;

        #endregion
    }
}
