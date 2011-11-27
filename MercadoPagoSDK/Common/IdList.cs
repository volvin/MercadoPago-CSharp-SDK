using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPagoSDK
{
    public class IdList : List<string>
    {
        private JSONObject _json;

        // todo: complete hole interface

        public IdList()
        {
            string json = "[]";
            _json = JSONObject.CreateFromString(json);
        }

        public IdList(JSONObject json)
        {
            _json = json;
        }

        public void Add(string id)
        {
            _json.Array.Add(JSONObject.CreateFromString(id));
        }

        public bool Remove(Item item)
        {
            return true;
        }

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

        public JSONObject ToJSON()
        {
            return _json;
        }
    }
}
