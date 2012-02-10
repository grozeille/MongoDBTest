using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBTest
{
    public class SumPeopleDouble1
    {
        [BsonId]
        public string Id { get; set; }

        [BsonElement("value")]
        public SumPeopleDouble1Value Value { get; set; }        
    }
}
