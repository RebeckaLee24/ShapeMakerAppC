using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeMakerC_BL
{
    public class Square : Shape
    {
        public override string ToString()
        {
            return "Square";
        }

        public override bool LabelFits(int labelLine, int labelLength)
        {
            if (labelLine > ShapeHeight | labelLength > ShapeHeight)
                return false;
            else
                return true;
        }

        public override void BuildShape()
        {
            List<string> tempLines = new List<string>();
            string tempLine = "";
            int lineNum;


            for (lineNum = 1; lineNum <= ShapeHeight; lineNum++)
            {
                for (var item = 1; item <= ShapeHeight; item++)
                    // Dim placeholder As Char = Char.ConvertFromUtf32(235)
                    tempLine += " S";
                tempLines.Add(tempLine);
                tempLine = "";
            }

            ShapeLines = tempLines;
        }
    }
}
