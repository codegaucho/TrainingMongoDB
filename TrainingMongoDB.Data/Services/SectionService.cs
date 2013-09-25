//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace TrainingMongoDB.Data.Services {

    using System.Collections.Generic;
    using Entities;
    using MongoDB.Driver.Builders;

    public class SectionService : EntityService<Section> {
        public IEnumerable<Section> GetSectionDetails(int limit, int skip)
        {
            var sectionCursor = this.MongoConnectionHandler.MongoCollection.FindAllAs<Section>()
                //.SetSortOrder(SortBy<Course>.Descending(c => c.ReleaseDate))
                .SetLimit(limit)
                .SetSkip(skip)
                .SetFields(Fields<Section>.Include(c => c.Id, c => c.Title, c => c.Content, c => c.CourseId));
            //add other fields as we go forward
            //to entity as well
            return sectionCursor;
        }

        public override void Update(Section entity)
        {
            //not needed for this example???  I think it prob is needed
        }

    }
}
