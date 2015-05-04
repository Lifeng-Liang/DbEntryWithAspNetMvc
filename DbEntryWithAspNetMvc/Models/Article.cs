using Leafing.Data.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Article : DbObjectModel<Article>
    {
        [Length(100)]
        public string Title { get; set; }

        [Length(255)]
        public string Content { get; set; }

        public long Index { get; set; }

        [SpecialName]
        public DateTime CreatedOn { get; set; }
    }
}