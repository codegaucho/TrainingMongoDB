//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

namespace TrainingMongoDB.CustomModelBinders
{
    using System.Web.Mvc;
    using MongoDB.Bson;

    public class BsonObjectIdBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext modelBindingContext) {
            ////Retriev a value object using modelBindingContext.ModelName as the key
            var valueProviderResult = modelBindingContext.ValueProvider.GetValue(modelBindingContext.ModelName);
            ////Now create and reutun a new instance of MongoDB.Bson.ObjectId with the raw string retrieved from the model
            return new ObjectId(valueProviderResult.AttemptedValue);
        }
    }
}