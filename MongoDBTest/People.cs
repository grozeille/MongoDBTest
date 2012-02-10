using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace MongoDBTest
{
    public class People
    {
        [BsonId(IdGenerator=typeof(CombGuidGenerator))]
        public Guid Id { get; set; }
        
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string String1 { get; set; }

        public string String2 { get; set; }

        public string String3 { get; set; }

        public string String4 { get; set; }

        public string String5 { get; set; }

        public string String6 { get; set; }

        public string String7 { get; set; }

        public string String8 { get; set; }

        public string String9 { get; set; }

        public string String10 { get; set; }

        public double Double1 { get; set; }

        public double Double2 { get; set; }

        public double Double3 { get; set; }

        public double Double4 { get; set; }

        public double Double5 { get; set; }

        public double Double6 { get; set; }

        public double Double7 { get; set; }

        public double Double8 { get; set; }

        public double Double9 { get; set; }

        public double Double10 { get; set; }
    }
}
