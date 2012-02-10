using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBTest
{
    public class SumPeopleDouble1Value
    {
        [BsonElement("count")]
        public int Count { get; set; }

        [BsonElement("double1")]
        public double Double1 { get; set; }
    }
}
