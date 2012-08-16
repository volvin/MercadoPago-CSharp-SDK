/*
 * Copyright 2010 Facebook, Inc.
 * Copyright 2011 MercadoLibre, Inc.
 *
 * Changed to retrieve a well-formed json string running .ToString() method.
 * Allows to serialize scalar data at CreateFromString method.
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
using System.Web.Script.Serialization;

namespace MercadoPagoSDK
{
    /// <summary>
    /// Represents an object encoded in JSON. Can be either a dictionary 
    /// mapping strings to other objects, an array of objects, or a single 
    /// object, which represents a scalar.
    /// </summary>
    public class JSONObject
    {
        /// <summary>
        /// Creates a JSONObject by parsing a string.
        /// This is the only correct way to create a JSONObject.
        /// </summary>
        public static JSONObject CreateFromString(string s)
        {
            object o;
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                o = js.DeserializeObject(s);
                if (o == null)
                {
                    o = s;  // serialize as scalar data
                }
            }
            catch (ArgumentException)
            {
                o = s;  // serialize as scalar data
            }

            return Create(o);
        }

        /// <summary>
        /// Returns true if this JSONObject represents a dictionary.
        /// </summary>
        public bool IsDictionary
        {
            get
            {
                return _dictData != null;
            }
        }

        /// <summary>
        /// Returns true if this JSONObject represents an array.
        /// </summary>
        public bool IsArray
        {
            get
            {
                return _arrayData != null;
            }
        }

        /// <summary>
        /// Returns true if this JSONObject represents a string value. 
        /// </summary>
        public bool IsString
        {
            get
            {
                return _stringData != null;
            }
        }

        /// <summary>
        /// Returns true if this JSONObject represents an integer value.
        /// </summary>
        public bool IsInteger
        {
            get
            {
                if (_stringData == null || _stringData.Length == 0)
                {
                    return false;
                }
                else
                {
                    if ((_stringData[0].ToString() == "0") && (_stringData.Length > 1))
                    {
                        return false;  // numbers that begins with a zero are treated like strings
                    }
                    else
                    {
                        Int64 tmp;
                        return Int64.TryParse(_stringData, out tmp);
                    }
                }
            }
        }

        /// <summary>
        /// Returns true if this JSONOBject represents a boolean value.
        /// </summary>
        public bool IsBoolean
        {
            get
            {
                bool tmp;
                return bool.TryParse(_stringData, out tmp);
            }
        }

        /// <summary>
        /// Returns this JSONObject as a dictionary
        /// </summary>
        public Dictionary<string, JSONObject> Dictionary
        {
            get
            {
                return _dictData;   
            }
        }

        /// <summary>
        /// Returns this JSONObject as an array
        /// </summary>
        public List<JSONObject> Array
        {
            get
            {
                return _arrayData;
            }
        }

        /// <summary>
        /// Returns this JSONObject as a string
        /// </summary>
        public string String
        {
            get
            {
                return _stringData;
            }
        }

        /// <summary>
        /// Returns this JSONObject as an integer
        /// </summary>
        public Int64 Integer
        {
            get
            {
                return Convert.ToInt64(_stringData);
            }
        }

        /// <summary>
        /// Returns this JSONObject as a boolean
        /// </summary>
        public bool Boolean
        {
            get
            {
                return Convert.ToBoolean(_stringData);
            }
        }

        /// <summary>
        /// Prints the JSONObject as a formatted string, suitable for viewing.
        /// </summary>
        public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            RecursiveObjectToString(this, sb);
            return sb.ToString();
        }

        /// <summary>
        /// Returns a boolean attribute contained in this json object 
        /// </summary>
        public bool? GetJSONBooleanAttribute(string attribute)
        {
            try
            {
                string boolValue = this.Dictionary[attribute].String;
                if (boolValue != "null")
                {
                    return Convert.ToBoolean(boolValue);
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Returns a custom class attribute contained in this json object 
        /// </summary>
        public JSONObject GetJSONCustomClassAttribute(string attribute)
        {
            try
            {
                return this.Dictionary[attribute];
            }
            catch
            {
                return JSONObject.CreateFromString("{}");
            }
        }

        /// <summary>
        /// Returns a datetime attribute contained in this json object 
        /// </summary>
        public DateTime? GetJSONDateTimeAttribute(string attribute)
        {
            try
            {
                string dateTimeValue = this.Dictionary[attribute].String;
                if (dateTimeValue != "null")
                {
                    return Convert.ToDateTime(dateTimeValue);
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }        
        }

        /// <summary>
        /// Returns a float attribute contained in this json object 
        /// </summary>
        public float? GetJSONFloatAttribute(string attribute)
        {
            try
            {
                string floatValue = this.Dictionary[attribute].String;
                if (floatValue != "null")
                {
                    return Convert.ToSingle(floatValue);
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Returns an int16 attribute contained in this json object 
        /// </summary>
        public Int16? GetJSONInt16Attribute(string attribute)
        {
            try
            {
                string int16Value = this.Dictionary[attribute].String;
                if (int16Value != "null")
                {
                    return Convert.ToInt16(int16Value);
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Returns an int32 attribute contained in this json object 
        /// </summary>
        public Int32? GetJSONInt32Attribute(string attribute)
        {
            try
            {
                string int32Value = this.Dictionary[attribute].String;
                if (int32Value != "null")
                {
                    return Convert.ToInt32(int32Value);
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Returns a string attribute contained in this json object 
        /// </summary>
        public String GetJSONStringAttribute(string attribute)
        {
            try
            {
                string stringValue = this.Dictionary[attribute].String;
                if (stringValue != "null")
                {
                    return stringValue;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Sets a boolean attribute contained in this json object 
        /// </summary>
        public void SetJSONBooleanAttribute(string attribute, bool? value)
        {
            string newValue;

            if (value != null)
            {
                newValue = value.ToString(); 
            }
            else
            {
                newValue = "null";
            }
            try
            {
                this.Dictionary[attribute] = JSONObject.CreateFromString(newValue);
            }
            catch (KeyNotFoundException)
            {
                this.Dictionary.Add(attribute, JSONObject.CreateFromString(newValue));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Sets a custom class attribute contained in this json object 
        /// </summary>
        public void SetJSONCustomClassAttribute(string attribute, JSONObject value)
        {
            try
            {
                this.Dictionary[attribute] = value;
            }
            catch (KeyNotFoundException)
            {
                this.Dictionary.Add(attribute, value);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Returns a float attribute contained in this json object 
        /// </summary>
        public void SetJSONFloatAttribute(string attribute, float? value)
        {
            string newValue;

            if (value != null)
            {
                newValue = value.ToString();
            }
            else
            {
                newValue = "null";
            }
            try
            {
                this.Dictionary[attribute] = JSONObject.CreateFromString(newValue);
            }
            catch (KeyNotFoundException)
            {
                this.Dictionary.Add(attribute, JSONObject.CreateFromString(newValue));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Returns an int16 attribute contained in this json object 
        /// </summary>
        public void SetJSONInt16Attribute(string attribute, Int16? value)
        {
            string newValue;

            if (value != null)
            {
                newValue = value.ToString(); 
            }
            else
            {
                newValue = "null";
            }
            try
            {
                this.Dictionary[attribute] = JSONObject.CreateFromString(newValue);
            }
            catch (KeyNotFoundException)
            {
                this.Dictionary.Add(attribute, JSONObject.CreateFromString(newValue));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Returns an int32 attribute contained in this json object 
        /// </summary>
        public void SetJSONInt32Attribute(string attribute, Int32? value)
        {
            string newValue;

            if (value != null)
            {
                newValue = value.ToString(); 
            }
            else
            {
                newValue = "null";
            }
            try
            {
                this.Dictionary[attribute] = JSONObject.CreateFromString(newValue);
            }
            catch (KeyNotFoundException)
            {
                this.Dictionary.Add(attribute, JSONObject.CreateFromString(newValue));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Returns a datetime attribute contained in this json object 
        /// </summary>
        public void SetJSONDateTimeAttribute(string attribute, DateTime? value)
        {
            string newValue;

            if (value != null)
            {
                newValue = value.Value.ToString("yyyy-MM-ddThh:mm:ss.fffzzzz"); 
            }
            else
            {
                newValue = "null";
            }
            try
            {
                this.Dictionary[attribute] = JSONObject.CreateFromString(newValue);
            }
            catch (KeyNotFoundException)
            {
                this.Dictionary.Add(attribute, JSONObject.CreateFromString(newValue));
            }
            catch (Exception e)
            {
                throw e;
            }        
        }

        /// <summary>
        /// Returns a string attribute contained in this json object 
        /// </summary>
        public void SetJSONStringAttribute(string attribute, String value)
        {
            string newValue;

            if (value != null)
            {
                newValue = value.ToString(); 
            }
            else
            {
                newValue = "null";
            }
            try
            {
                this.Dictionary[attribute] = JSONObject.CreateFromString(newValue);
            }
            catch (KeyNotFoundException)
            {
                this.Dictionary.Add(attribute, JSONObject.CreateFromString(newValue));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected JSONObject()
        { }

        #region Private Members

        private string _stringData;
        private List<JSONObject> _arrayData;
        private Dictionary<string, JSONObject> _dictData;

        /// <summary>
        /// Recursively constructs this JSONObject 
        /// </summary>
        private static JSONObject Create(object o)
        {
            JSONObject obj = new JSONObject();
            if (o is object[])
            {
                object[] objArray = o as object[];
                obj._arrayData = new List<JSONObject>();
                for (int i = 0; i < objArray.Length; ++i)
                {
                    obj._arrayData.Add(Create(objArray[i]));
                }
            }
            else if (o is Dictionary<string, object>)
            {
                obj._dictData = new Dictionary<string, JSONObject>();
                Dictionary<string, object> dict = 
                    o as Dictionary<string, object>;
                foreach (string key in dict.Keys)
                {
                    obj._dictData[key] = Create(dict[key]);
                }
            }
            else if (o != null) // o is a scalar
            {
                obj._stringData = o.ToString();
            }

            return obj;
        }

        /// <summary>
        /// Recursively deconstructs this JSONObject to string
        /// </summary>
        private static void RecursiveDictionaryToString(JSONObject obj, StringBuilder sb)
        {
            foreach (KeyValuePair<string, JSONObject> kvp in obj.Dictionary)
            {
                sb.Append("\"" + kvp.Key + "\"");
                sb.Append(":");
                RecursiveObjectToString(kvp.Value, sb);
                sb.Append(",");
            }
        }
        private static void RecursiveObjectToString(JSONObject obj, StringBuilder sb)
        {
            if (obj.IsDictionary)
            {
                sb.Append("{");
                RecursiveDictionaryToString(obj, sb);
                if (sb[sb.Length - 1].ToString() == ",")
                {
                    sb.Remove(sb.Length - 1, 1);
                }
                sb.Append("}");
            }
            else if (obj.IsArray)
            {
                sb.Append("[");
                foreach (JSONObject o in obj.Array)
                {
                    RecursiveObjectToString(o, sb);
                    sb.Append(",");
                }
                if (sb[sb.Length - 1].ToString() == ",")
                {
                    sb.Remove(sb.Length - 1, 1);
                }
                sb.Append("]");
            }
            else // some sort of scalar value
            {
                if (obj.IsBoolean || obj.IsInteger)
                {
                    sb.Append(obj.String);
                }
                else if (obj.IsString)
                {
                    sb.Append("\"" + obj.String + "\"");
                }
                else
                {
                    sb.Append("null");                
                }
            }
        }

        #endregion
    }
}
