// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

using ShapeMakerC_BL;


static class Program
{
    private static Shape _myShape;
    private static bool _inValidResponse;
    private static bool _keepDrawing = true;

    public static void Main(string[] args)
     {
        string answer;

        do
        { 
        _inValidResponse = true;
        while (_inValidResponse)
            GetShape();

        _inValidResponse = true;
        while (_inValidResponse)
            GetShapeHeight();

        _inValidResponse = true;
        while (_inValidResponse)
            GetLabels();

        try
        {
            _myShape.BuildShape();

            foreach (var item in _myShape.Labels)
            {
                if (_myShape.LabelFits(item.labelHeight, item.LabelText.Length))
                {
                    _myShape.PlaceLabels(item);
                }                    
                else
                {
                    Console.WriteLine("Label, " + item.LabelText + " does not fit on row " + item.labelHeight +
                                      Environment.NewLine + "Label will not be placed on the " + _myShape.ToString());
                    Console.ReadLine();
                }
                    
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: Error trying to draw your shape and/or place labels " + ex.ToString());
        }

        Console.WriteLine(Environment.NewLine);
        for (var item = 0; item <= _myShape.ShapeHeight - 1; item++)
        {           
            Console.WriteLine(_myShape.ShapeLines[item]);            
        }
        Console.WriteLine(Environment.NewLine);

        Console.ReadLine();

        Console.WriteLine("Should I draw another shape, (Y)es or (N)o ? ");
        answer = Console.ReadLine();

        if (answer.Trim().ToUpper() == "Y" | answer.Trim().ToUpper() == "YES" | answer.Trim().ToUpper() == "1")
        {
                _keepDrawing = true;
        }
        else
        {
            Console.WriteLine("Thanks for drawing, Good-bye! ");
            _keepDrawing = false;
            }
            


        } while (_keepDrawing);
    }

    public static bool IsNumeric(string value)
    {
        //return value.All(char.IsNumber);
        int answer;
        return int.TryParse(value, out answer);
    }

    private static void GetShape()
    {
        string Response;

        Console.WriteLine("Hello World!");
        Console.WriteLine(Environment.NewLine);
        Console.WriteLine("What Shape should I draw? " + Environment.NewLine + "1) Triangle" +
            Environment.NewLine + "2) Square " + Environment.NewLine + "3) Diamond");

        Response = Console.ReadLine();

        _inValidResponse = false;

        try
        {
            if (IsNumeric(Response))
            {
                switch (System.Convert.ToInt32(Response))
                {
                    case 1:
                        {
                            _myShape = new Triangle();
                            break;
                        }

                    case 2:
                        {
                            _myShape = new Square();
                            break;
                        }

                    case 3:
                        {
                            _myShape = new Diamond();
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("I'm sorry, I don't understand that response. " + "Please enter a number 1 to 3");
                            _inValidResponse = true;
                            break;
                        }
                }
            }
            else if (Response.Trim().ToUpper() == "T" | Response.Trim().ToUpper() == "TRI" | Response.Trim().ToUpper() == "TRIANGLE")
                _myShape = new Triangle();
            else if (Response.Trim().ToUpper() == "S" | Response.Trim().ToUpper() == "SQU" | Response.Trim().ToUpper() == "SQUARE")
                _myShape = new Square();
            else if (Response.Trim().ToUpper() == "D" | Response.Trim().ToUpper() == "DIA" | Response.Trim().ToUpper() == "DIAMOND")
                _myShape = new Diamond();
            else
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("I'm sorry, I don't understand that response. " + "Please enter a number 1 to 3");
                _inValidResponse = true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: Error trying to get your shape " + ex.ToString());
        }
    }

    private static void GetShapeHeight()
    {
        string Response;
        int tempHeight = 0;

        Console.WriteLine("How tall should the " + _myShape.ToString() + " be?");

        Response = Console.ReadLine();

        _inValidResponse = false;

        try
        {
            if ((IsNumeric(Response)) && (System.Convert.ToInt32(Response) > 0))               
            {
                if (System.Convert.ToInt32(Response) > 80)
                {
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("Large numbers cause the shape lines to wrap and distort the shape." +
                        Environment.NewLine + "Please select a number less than 80. ");
                    _inValidResponse = true;
                }
                else
                {
                    _myShape.ShapeHeight = System.Convert.ToInt32(Response);
                }
                
            }            
            else
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("I'm sorry, I don't understand that response. " + "Please enter a positive integer");
                _inValidResponse = true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: Error trying to get your shape height " + ex.ToString());
            Console.ReadLine();
        }
    }

    private static void GetLabels()
    {
        string Response;
        bool pleaseContinue;
        string tempString;
        int tempLabelRow = 0;
        LabelType templabel;

        try
        {
            if (_myShape.Labels.Count > 0)
            {
                // not first label
                Console.WriteLine("Would you like to add another label on this " + _myShape.ToString() + "? ");

                Response = Console.ReadLine().Trim().ToUpper();
                if (Response == "Y" | Response == "YES")
                    pleaseContinue = true;
                else
                {
                    pleaseContinue = false;
                    _inValidResponse = false; // stop outer loop
                }
            }
            else
                pleaseContinue = true;

            if (pleaseContinue)
            {
                Console.WriteLine("What label should I print on this " + _myShape.ToString() + " (Leave blank for \"LU\" ? )");

                Response = Console.ReadLine();
                if (Response != "")
                    tempString = Response.Trim();
                else
                    tempString = "LU";

                GetLabelRow(ref tempLabelRow, tempString);

                templabel = new LabelType(tempLabelRow, tempString);
                _myShape.Labels.Add(templabel);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: Error trying to get your labels " + ex.ToString());
            Console.ReadLine();
        }
    }

    private static void GetLabelRow(ref int lblRow, string tempString)
    {
        string response;
        bool IsValidRow = false;

        try
        {
            while (!IsValidRow)
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("On what row should I print " + tempString);
                response = Console.ReadLine();

                if (IsNumeric(response))
                {
                    lblRow = System.Convert.ToInt32(response);
                    if (lblRow > 0 & lblRow <= _myShape.ShapeHeight)
                        IsValidRow = true;
                    else
                    {
                        Console.WriteLine("I'm sorry, that is not a valid response. " + "Please enter a positive integer less than or = to shape height.");
                        IsValidRow = false;
                    }
                }
                else
                {
                    Console.WriteLine(Environment.NewLine); 
                    Console.WriteLine("I'm sorry, I don't understand that response. " + "Please enter a positive integer");
                    IsValidRow = false;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: Error trying to get the row for your label " + ex.ToString());
            Console.ReadLine();
        }
    }
}