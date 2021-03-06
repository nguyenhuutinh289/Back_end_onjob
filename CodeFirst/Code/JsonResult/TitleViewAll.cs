﻿using Code.ModelsView;
using System;
using System.Collections.Generic;

namespace Code.JsonResult
{
    public class TitleViewAll
    {

        public TitleView Title { get; set; }

        public List<int> Categories { get; set; }

        public List<int> Authors { get; set; }

        public TitleViewAll(TitleView view, List<int> categories, List<int> authors)
        {
            this.Title = view;
            this.Categories = categories;
            this.Authors = authors;
        }

    }
}