using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPagoSDK
{
    public class Item
    {
        private JSONObject _json;

        public Item()
        {
            string json = "{";
            json += "\"currency_id\":\"\",";
            json += "\"description\":\"\",";
            json += "\"id\":\"\",";
            json += "\"picture_url\":\"\",";
            json += "\"quantity\":0,";
            json += "\"title\":\"\",";
            json += "\"unit_price\":0";
            json += "}";
            _json = JSONObject.CreateFromString(json);
        }

        public Item(JSONObject json)
        {
            _json = json;
        }

        // todo: como valido que no me asignen cualquier fruta

        public string CurrencyId
        {
            get
            {
                return _json.Dictionary["currency_id"].String;
            }
            set
            {
                _json.Dictionary["currency_id"] = JSONObject.CreateFromString(value);
            }
        }

        public string Description
        {
            get
            {
                return _json.Dictionary["description"].String;
            }
            set
            {
                _json.Dictionary["description"] = JSONObject.CreateFromString(value);
            }
        }

        public string Id
        {
            get
            {
                return _json.Dictionary["id"].String;
            }
            set
            {
                _json.Dictionary["id"] = JSONObject.CreateFromString(value);
            }
        }

        public Int16 Quantity
        {
            get
            {
                return Convert.ToInt16(_json.Dictionary["quantity"].String);
            }
            set
            {
                _json.Dictionary["quantity"] = JSONObject.CreateFromString(value.ToString());
            }
        }

        public string PictureUrl
        {
            get
            {
                return _json.Dictionary["picture_url"].String;
            }
            set
            {
                _json.Dictionary["picture_url"] = JSONObject.CreateFromString(value);
            }
        }

        public string Title
        {
            get
            {
                return _json.Dictionary["title"].String;
            }
            set
            {
                _json.Dictionary["title"] = JSONObject.CreateFromString(value);
            }
        }

        public Int16 UnitPrice
        {
            get
            {
                return Convert.ToInt16(_json.Dictionary["unit_price"].String);
            }
            set
            {
                _json.Dictionary["unit_price"] = JSONObject.CreateFromString(value.ToString());
            }
        }

        public JSONObject ToJSON()
        {
            return _json;
        }
    }
}
