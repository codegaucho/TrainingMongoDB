//using System;
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
    public class Course : MongoEntity
    {
        //public Course()
        //{
        //    Sections = new List<Section>();
        //}

        public string Title { get; set; }

        //add other fields when we get everything connected
        //also add to the CourseService in Services
        //public List<Section> Sections { get; set; }
    }
}
