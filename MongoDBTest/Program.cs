using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using MongoDB.Driver.Builders;
using FluentMongo.Linq;
using System.IO;

namespace MongoDBTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "mongodb://localhost:27017";
            MongoServer server = MongoServer.Create(connectionString);

            //MongoCredentials credentials = new MongoCredentials("username", "password");
            //MongoDatabase salaries = server.GetDatabase("salaries", credentials);
            MongoDatabase salaries = server.GetDatabase("salaries");

            //server.RunAdminCommand("{enablesharding : \"salaries\" }");
            
            if (!salaries.CollectionExists("people"))
            {
                salaries.CreateCollection("people");
            }

            MongoCollection<People> collection = salaries.GetCollection<People>("people");

            collection.CreateIndex("Firstname", "Lastname");

            //server.RunAdminCommand("{ shardCollection : 'salaries.people', key : { _id : 1 } }");


            server.RequestStart(salaries);
            collection.RemoveAll();
            server.GetLastError();

            BsonClassMap.RegisterClassMap<People>(cm =>
            {
                cm.AutoMap();
            });
            BsonClassMap.RegisterClassMap<SumPeopleDouble1>(cm =>
            {
                cm.AutoMap();
            });


            var p = new List<People>();
            for (int cpt = 0; cpt < 800000; cpt++)
            {
                p.Add(CreatePeople(cpt));
            }

            Console.WriteLine(DateTime.Now+": Start saving");
            server.RequestStart(salaries);
            collection.InsertBatch(p);
            /*foreach(var item in p)
            {
                collection.Save(item);
            }*/
            Console.WriteLine(DateTime.Now + ": Save end");
            server.GetLastError();
            Console.WriteLine(DateTime.Now + ": GetLastError");
            Console.WriteLine(DateTime.Now + ": Start Query");
            var result = collection.AsQueryable()
                .Where(x => x.Firstname == "Mathias" && x.Lastname == "Kluba");

            Console.WriteLine(DateTime.Now + ": Query end "+result.Count());

            string map = File.ReadAllText("MapReduce/PeopleDouble1/Map.js");
            string reduce = File.ReadAllText("MapReduce/PeopleDouble1/Reduce.js");
            
            Console.WriteLine(DateTime.Now + ": Start MapReduce");
            
            var mapReduceResult = collection
                .MapReduce(map, reduce)
                .GetResultsAs<SumPeopleDouble1>();

            Console.WriteLine(DateTime.Now + ": MapReduce End ");
            foreach (var item in mapReduceResult)
            {
                Console.WriteLine("id: {0} count:{1} double1:{2}", item.Id, item.Value.Count, item.Value.Double1);
            }
        }

        private static People CreatePeople(int cpt)
        {
            string firstName = cpt % 2 == 0 ? "Mathias" : "Michel";
            var people = new People { Firstname = firstName, Lastname = "Kluba" };
            people.String1 = "AAAAA" + cpt;
            people.String2 = "AAAAA" + cpt;
            people.String3 = "AAAAA" + cpt;
            people.String4 = "AAAAA" + cpt;
            people.String5 = "AAAAA" + cpt;
            people.String6 = "AAAAA" + cpt;
            people.String7 = "AAAAA" + cpt;
            people.String8 = "AAAAA" + cpt;
            people.String9 = "AAAAA" + cpt;
            people.String10 = "AAAAA" + cpt;
            people.Double1 = 30.6;
            people.Double2 = 30.6;
            people.Double3 = 30.6;
            people.Double4 = 30.6;
            people.Double5 = 30.6;
            people.Double6 = 30.6;
            people.Double7 = 30.6;
            people.Double8 = 30.6;
            people.Double9 = 30.6;
            people.Double10 = 30.6;

            return people;
        }
    }
}
