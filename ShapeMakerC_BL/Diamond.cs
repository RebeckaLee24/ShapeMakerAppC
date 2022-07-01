using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeMakerC_BL
{
    public class Diamond : Shape
    {
        public override string ToString()
        {
            return "Diamond";
        }

        public override bool LabelFits(int labelLine, int labelLength)
        {
            if (labelLine > ShapeHeight | labelLength > (ShapeHeight / (int)2))
                return false;
            else
            {
                int halfCount;

                if (ShapeHeight % 2 == 0)
                    halfCount = ShapeHeight / (int)2;
                else
                    halfCount = (ShapeHeight + 1) / (int)2;

                if (labelLine < halfCount)
                {
                    if (labelLength > labelLine)
                        return false;
                    else
                        return true;
                }
                else if (labelLength > (ShapeHeight - labelLine + 1))
                    return false;
                else
                    return true;
            }
        }

        public override void BuildShape()
        {
            List<string> tempLines = new List<string>();
            string tempLine = "";
            int lineNum;
            int padcount = ShapeHeight - 1;
            int halfCount;

            if (ShapeHeight % 2 == 0)
                halfCount = ShapeHeight / (int)2;
            else
                halfCount = (ShapeHeight + 1) / (int)2;

            for (lineNum = 1; lineNum <= (ShapeHeight - halfCount); lineNum++)
            {
                tempLine = tempLine.PadLeft(padcount);
                for (var item = 1; item <= lineNum; item++)
                    // Dim placeholder As Char = Char.ConvertFromUtf32(235)
                    tempLine += " D";
                tempLines.Add(tempLine);
                tempLine = "";
                padcount -= 1;
            }

            for (lineNum = halfCount; lineNum >= 1; lineNum += -1)
            {
                tempLine = tempLine.PadLeft(padcount);
                for (var item = 1; item <= lineNum; item++)
                    // Dim placeholder As Char = Char.ConvertFromUtf32(235)
                    tempLine += " D";
                tempLines.Add(tempLine);
                tempLine = "";
                padcount += 1;
            }

            ShapeLines = tempLines;
        }
    }
}
