//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace TrainingMongoDB.Data.Services
{
    using System.Collections.Generic;
    using Entities;
    using MongoDB.Driver.Builders;

    public class CourseService : EntityService<Course>
    {
        public IEnumerable<Course> GetCourseDetails(int limit, int skip)
        {
            var courseCursor = this.MongoConnectionHandler.MongoCollection.FindAllAs<Course>()
                //.SetSortOrder(SortBy<Course>.Descending(c => c.ReleaseDate))
                .SetLimit(limit)
                .SetSkip(skip)
                .SetFields(Fields<Course>.Include(c => c.Id, c => c.Title));
            //add other fields as we go forward
            //to entity as well
            return courseCursor;
        }

        public override void Update(Course entity)
        {
            //not needed for this example???  I think it prob is needed
        }
    }
}
