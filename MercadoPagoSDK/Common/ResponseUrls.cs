using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPagoSDK
{
    public class ResponseUrls
    {
        private JSONObject _json;

        public ResponseUrls()
        {
            string json = "{";
            json += "\"failure\":\"\",";
            json += "\"pending\":\"\",";
            json += "\"success\":\"\"";
            json += "}";
            _json = JSONObject.CreateFromString(json);
        }

        public ResponseUrls(JSONObject json)
        {
            _json = json;
        }

        // todo: como valido que no me asignen cualquier fruta

        public string Failure
        {
            get
            {
                return _json.Dictionary["failure"].String;
            }
            set
            {
                _json.Dictionary["failure"] = JSONObject.CreateFromString(value);
            }
        }

        public string Pending
        {
            get
            {
                return _json.Dictionary["pending"].String;
            }
            set
            {
                _json.Dictionary["pending"] = JSONObject.CreateFromString(value);
            }
        }

        public string Success
        {
            get
            {
                return _json.Dictionary["success"].String;
            }
            set
            {
                _json.Dictionary["success"] = JSONObject.CreateFromString(value);
            }
        }

        public JSONObject ToJSON()
        {
            return _json;
        }
    }
}
