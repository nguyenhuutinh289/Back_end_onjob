using Code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code.ModelsView
{
    public class ModelBindingTitleView
    {
        public Title Title { get; set; }
        public int[] Authors { get; set; }
        public int[] Categories { get; set; }
    }
}
