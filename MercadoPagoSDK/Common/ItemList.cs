using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPagoSDK
{
    public class ItemList : List<Item>
    {
        private JSONObject _json;

        // todo: complete hole interface

        public ItemList()
        {
            string json = "[]";
            _json = JSONObject.CreateFromString(json);
        }

        public ItemList(JSONObject json)
        {
            _json = json;
        }

        public void Add(Item item)
        {
            _json.Array.Add(item.ToJSON());
        }

        public bool Remove(Item item)
        {
            return true;
        }

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

        public JSONObject ToJSON()
        {
            return _json;
        }
    }
}
