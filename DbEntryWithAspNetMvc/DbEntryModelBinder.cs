using Leafing.Data;
using Leafing.Data.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1
{
    public class DbEntryModelBinderHelper
    {
        public static void Init()
        {
            var types = typeof(MvcApplication).Assembly.GetTypes();
            foreach (var type in types)
            {
                if (type.IsSubclassOf(typeof(DbObjectSmartUpdate)))
                {
                    ModelBinders.Binders.Add(type, new DbEntryModelBinder());
                }
            }
        }
    }

    public class DbEntryModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var ctx = ModelContext.GetInstance(bindingContext.ModelType);
            var id = GetId(bindingContext);
            object obj = id != 0 ? ctx.Operator.GetObject(id) : ctx.NewObject();
            foreach(var field in ctx.Info.Members)
            {
                if(!field.Is.RelationField && !field.Is.Count && !field.Is.CreatedOn 
                    && !field.Is.DbGenerate && !field.Is.DbGenerateGuid && !field.Is.LockVersion
                    && !field.Is.SavedOn)
                {
                    var result = bindingContext.ValueProvider.GetValue(field.Name);
                    if (result != null)
                    {
                        field.SetValue(obj, result.ConvertTo(field.MemberType));
                    }
                }
            }
            return obj;
        }

        private long GetId(ModelBindingContext bindingContext)
        {
            var idx = bindingContext.ValueProvider.GetValue("Id");
            if (idx != null)
            {
                var id = (long)idx.ConvertTo(typeof(long));
                if (id > 0)
                {
                    return id;
                }
            }
            return 0;
        }
    }
}