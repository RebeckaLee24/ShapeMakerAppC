using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeMakerC_BL
{
    public class LabelType
    {
        public int labelHeight { get; set; }
        public string? LabelText { get; set; }

        public LabelType (int lblHeight, string lblTxt)
        {
            labelHeight = lblHeight;
            LabelText = lblTxt;
        }

    }
}
