using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace MvcDB4O.Models
{
    //[Serializable]
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        //public IEnumerable<Product> Products { get; set; }

        //public static T DeepClone<T>(T obj)
        //{
        //    using (var ms = new MemoryStream())
        //    {
        //        var formatter = new BinaryFormatter();
        //        formatter.Serialize(ms, obj);
        //        ms.Position = 0;

        //        return (T)formatter.Deserialize(ms);
        //    }
        //}
    }
}