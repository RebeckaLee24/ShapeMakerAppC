using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeMakerC_BL
{
    public class Triangle : Shape
    {
        public override string ToString()
        {
            return "Triangle";
        }

        public override bool LabelFits(int labelLine, int labelLength)
        {
            if (labelLine > ShapeHeight | labelLength > labelLine)
                return false;
            else
                return true;
        }

        public override void BuildShape()
        {
            List<string> tempLines = new List<string>();
            string tempLine = "";
            int lineNum;

            int padcount = ShapeHeight - 1;

            for (lineNum = 1; lineNum <= ShapeHeight; lineNum++)
            {
                tempLine = tempLine.PadLeft(padcount);
                for (var item = 1; item <= lineNum; item++)
                    // Dim placeholder As Char = Char.ConvertFromUtf32(235)
                    tempLine += " T";
                tempLines.Add(tempLine);
                tempLine = "";
                padcount -= 1;
            }

            ShapeLines = tempLines;
        }
    }
}
