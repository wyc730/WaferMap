using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaferMapTest
{
    public class Wafer
    {
        public string WaferID { get; internal set; }
        public WaferDataType WaferDataType { get; internal set; }
        public WaferSize WaferSize { get; internal set; }
        public WaferMap Map { 
            get { 
                return WaferMapFactory.GetFactory().GetWaferMap(WaferSize);
            }  
        }
        public Wafer(string waferID, WaferDataType waferDataType, WaferSize waferSize)
        {
            WaferID = waferID;
            WaferDataType = waferDataType;
            WaferSize = waferSize;
        }
        public string[][] GetMapData()
        {
            return Map.GetMapData(WaferID,WaferDataType);
        }
        public void Draw()
        {
            Map.Draw(GetMapData());
        }

    }
}
