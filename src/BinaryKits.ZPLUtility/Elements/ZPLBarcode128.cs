﻿using System;
using System.Collections.Generic;

namespace BinaryKits.Utility.ZPLUtility.Elements
{
    /// <summary>
    /// Code 128
    /// </summary>
    public class ZPLBarcode128 : ZPLBarcode
    {
        public ZPLBarcode128(string content, int positionX, int positionY, int height = 100, string orientation = "N", bool printInterpretationLine = true, bool printInterpretationLineAboveCode = false)
            : base(content, positionX, positionY, height, orientation, printInterpretationLine, printInterpretationLineAboveCode)
        {
        }

        public override IEnumerable<string> Render(ZPLRenderOptions context)
        {
            //^FO100,100 ^ BY3
            //^BCN,100,Y,N,N
            //^FD123456 ^ FS
            var result = new List<string>();
            result.AddRange(Origin.Render(context));
            result.Add($"^B{Orientation},{context.Scale(Height)},{(PrintInterpretationLine ? "Y" : "N")},{(PrintInterpretationLineAboveCode ? "Y" : "N")}");
            result.Add($"^FD{Content}^FS");

            return result;
        }
    }

    [Obsolete("ZPLBarCode128 is deprecated, please use ZPLBarcode128 instead.")]
    public class ZPLBarCode128 : ZPLBarcode128
    {
        public ZPLBarCode128(string content, int positionX, int positionY, int height = 100, string orientation = "N", bool printInterpretationLine = true, bool printInterpretationLineAboveCode = false) 
            : base(content, positionX, positionY, height, orientation, printInterpretationLine, printInterpretationLineAboveCode)
        {
        }
    }
}
