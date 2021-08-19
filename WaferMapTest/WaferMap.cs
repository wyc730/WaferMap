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

        public abstract void Draw();
        public abstract string[][] GetMapData(string waferID, WaferDataType waferDataType);

    }

    public class SmallWaferMap : WaferMap
    { 
        public override int Size { get { return 3; } }
        public override void Draw()
        {
            throw new NotImplementedException();
        }

        public override string[][] GetMapData(string waferID, WaferDataType waferDataType)
        {
            return WaferDataProxy.GetWaferDataProxy().GetMapData(waferID, waferDataType, Size);
        }
    }
    public class MiddleWaferMap : WaferMap
    {
        public override int Size { get { return 4; } }
        public override void Draw()
        {
            throw new NotImplementedException();
        }
        public override string[][] GetMapData(string waferID, WaferDataType waferDataType)
        {
            return WaferDataProxy.GetWaferDataProxy().GetMapData(waferID, waferDataType, Size);
        }
    }
    public class BigWaferMap : WaferMap
    {
        public override int Size { get { return 6; } }
        public override void Draw()
        {
            throw new NotImplementedException();
        }
        public override string[][] GetMapData(string waferID,WaferDataType waferDataType)
        {
            return WaferDataProxy.GetWaferDataProxy().GetMapData(waferID, waferDataType, Size);
        }
    }
}
