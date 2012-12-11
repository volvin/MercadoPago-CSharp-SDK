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
using MercadoPagoSDK.Helpers;

namespace MercadoPagoSDK
{
    /// <summary>
    /// A helper for Payments operations. 
    /// </summary>
    public class PaymentsHelper : BaseHelper
    {
        /// <summary>
        /// Proactively cancels a collection. 
        /// </summary>
        public void CancelCollection(Int32 collectionId)
        {
            // Create a collection status change
            Collection collection = new Collection();
            collection.Id = collectionId;
            collection.Status = "cancelled";
            
            // Execute update
            UpdateCollection(collection);
        }

        /// <summary>
        /// Gets a collection notification. 
        /// </summary>
        public CollectionNotification GetCollectionNotification(Int32 collectionNotificationId)
        {
            JSONObject json = _api.Get(SettingsHelper.CollectionsNotificationsUri + "/" + collectionNotificationId.ToString());
            CollectionNotification notification = new CollectionNotification(json);

            return notification;
        }

        /// <summary>
        /// Searches the api for collections. 
        /// </summary>
        public SearchPage<Collection> SearchCollections(List<KeyValuePair<string, string>> args)
        {
            JSONObject json = _api.Get(SettingsHelper.CollectionsSearchUri, args);
            SearchPage<Collection> searchPage = SearchPage<Collection>.CreateInstance(json);

            return searchPage;
        }

        /// <summary>
        /// Updates a collection. 
        /// </summary>
        public Collection UpdateCollection(Collection collection)
        {
            JSONObject json = _api.Put(SettingsHelper.CollectionsUri + "/" + collection.Id.ToString(), collection.ToJSON(), ContentType.JSON);
            Collection updatedCollection = new Collection(json);

            return updatedCollection;
        }
    }
}
