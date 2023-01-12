using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Settings
{
    public class MongoDbSettings
    {
        public string Database_Name { get; set; }
        public string Books_Collection_Name { get; set; }
        public string ConnectionString { get; set; }
    }
}