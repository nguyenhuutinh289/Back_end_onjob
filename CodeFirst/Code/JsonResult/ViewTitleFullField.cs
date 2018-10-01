using Code.ModelsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code.JsonResult
{
    public class ViewTitleFullField
    {
        public TitleView Title { get; set; }

        public List<string> Categories { get; set; }

        public List<string> Authors { get; set; }

        public ViewTitleFullField(TitleView view, List<string> categories, List<string> authors)
        {
            this.Title = view;
            this.Categories = categories;
            this.Authors = authors;
        }
    }
}
