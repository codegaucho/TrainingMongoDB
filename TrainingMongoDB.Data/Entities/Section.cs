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
    public class Section : MongoEntity
    {
        public Section() 
        { 
            Registrations = new List<Registration>();
        }
        public ObjectId CourseId { get; set; }
        public string Title { get; set; }

        //add rest of fields when it is all connected

        public List<Registration> Registrations { get; set; }
    }
}
