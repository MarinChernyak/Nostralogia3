using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nostralogia3.Common
{
    public class RootJCollectionObject
    {

        public List<JsonCollection> items { get; set; }
    }
    public class JsonCollection
    {
        public List<SelectListItem> items { get; set; }
        public String Name { get; set; }
    }


    public class JsonPair
    {
        public Object Value { get; set; }
        public String Name { get; set; }

        public JsonPair(String name, object value)
        {
            Value = value;
            Name = name;
        }
    }
    public class RootJPairCollection
    {
        public RootJPairCollection()
        {
            _items = new List<JsonPair>();
        }
        protected List<JsonPair> _items;
        public List<JsonPair> items { get { return _items; } }
    }
}