using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;


namespace ShapeMakerC_BL
{
    public abstract class Shape
    {
        public int ShapeHeight { get; set; }

        public List<LabelType> Labels { get; set; } = new List<LabelType>();

        public List<string> ShapeLines { get; set; } = new List<string>();

        public abstract void BuildShape();

        public abstract bool LabelFits(int labelLine, int labelLength);
               
        public void PlaceLabels(LabelType item)
        {
            string tempLine;
            string tempText;
            int padcount = 0;
            int padcounter = 0;
            int textIndex = 0;           
            string[] tempArray;
            char[] newShapeLine;
                     
           
            //get non-space characters in shape line
            tempArray = ShapeLines[item.labelHeight - 1].Trim().Split(" "); 
            //get all characters in shape line 
            tempLine = ShapeLines[item.labelHeight - 1];
            newShapeLine = tempLine.ToCharArray();
            //get label text
            tempText = item.LabelText;
            //Find the difference between non-white spaces in shape and length of label and divide by 2                
            padcount = ((tempArray.Length) - tempText.Length) / (int)2;
            for (var i = 0; i <= tempLine.Length - 1; i++)
            {
                if (char.IsWhiteSpace(tempLine,i))
                {
                }
                else
                { if ((padcounter + 1 > padcount) && (textIndex < tempText.Length))
                    {
                        newShapeLine[i] =  tempText[textIndex];
                        textIndex += 1;
                     }
                     padcounter += 1;
                }
            }
               
            ShapeLines[item.labelHeight - 1] = new string(newShapeLine);
            padcounter = 0;
            textIndex = 0;
            
        }

    }
}