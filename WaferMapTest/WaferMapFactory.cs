using System;
using System.Collections;

namespace WaferMapTest
{
    public enum WaferSize
    { 
        Small,Middle,Big
    }
    public class WaferMapFactory
    {
        public static WaferMapFactory _waferMapFactory = new WaferMapFactory();

        private Hashtable waferMaps = new Hashtable();

        protected WaferMapFactory()
        {
            waferMaps.Add(WaferSize.Small, new SmallWaferMap());
            waferMaps.Add(WaferSize.Middle, new MiddleWaferMap());
            waferMaps.Add(WaferSize.Big, new BigWaferMap());
        }
        public static WaferMapFactory GetFactory()
        {
            return _waferMapFactory;
        }
        public WaferMap GetWaferMap(WaferSize waferSize)
        {
            return (WaferMap)waferMaps[waferSize];
        }

    }
}
