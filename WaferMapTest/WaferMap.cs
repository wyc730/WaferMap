using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaferMapTest
{
    public abstract class WaferMap
    {
        public abstract int Size { get; }

        public string Draw(string[][] matrix)
        {
            string map = "";
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    map += matrix[i][j].PadLeft(5, ' ');
                }
                map += "\r\n";
            }
            return map;
        }
        public string[][] GetMapData(string waferID, WaferDataType waferDataType)
        {
            return WaferDataProxy.GetWaferDataProxy().GetMapData(waferID, waferDataType, Size);
        }
    }

    public class SmallWaferMap : WaferMap
    { 
        public override int Size { get { return 3; } }
       
   
    }
    public class MiddleWaferMap : WaferMap
    {
        public override int Size { get { return 4; } }
     
    }
    public class BigWaferMap : WaferMap
    {
        public override int Size { get { return 6; } }
        
   
    }
}
