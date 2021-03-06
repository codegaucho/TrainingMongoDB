﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace TrainingMongoDB.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    [BsonIgnoreExtraElements]
    public class Student : MongoEntity
    {
        public Student()
        { 
            Registrations = new List<Registration>();
        }
        public string name { get; set; }

        //add rest of profile once we have this working

        public List<Registration> Registrations { get; set; }
    }
}
