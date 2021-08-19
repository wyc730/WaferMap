using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaferMapTest
{
    public enum WaferDataType
    {
        WaferBinData,
        WaferMeasureData
    }
    public class WaferDataProxy
    {
        Hashtable proxyData = new Hashtable();
        int refreshCount = 2;
        int refreshSeconds = 60;

        private static WaferDataProxy waferDataProxy=new WaferDataProxy();
        //protected WaferDataProxy()
        //{ }
        public WaferDataProxy()
        { }
        public static WaferDataProxy GetWaferDataProxy()
        {
            return waferDataProxy;
        }

        public string[][] GetMapData(string waferID, WaferDataType waferDataType, int size)
        {
           
            switch (waferDataType)
            {
                case WaferDataType.WaferBinData:
                    {
                        if (WaferBinDataSingleton.AccessCount > refreshCount || proxyData[waferID] == null)
                        {
                            WaferBinDataSingleton.Reset();
                            proxyData[waferID] = WaferBinDataSingleton.GetMapData(size);
                            return (string[][])proxyData[waferID];
                        }
                        else
                        {
                            WaferBinDataSingleton.AccessCount++;
                            return (string[][])proxyData[waferID];
                        }
                       
                    }
                case WaferDataType.WaferMeasureData:
                    {
                        if (WaferMeasureDataSingleton.AccessCount > refreshCount || proxyData[waferID] == null)
                        {
                            WaferMeasureDataSingleton.Reset();
                            proxyData[waferID] = WaferMeasureDataSingleton.GetMapData(size);
                            return (string[][])proxyData[waferID];
                        }
                        else
                        {
                            WaferMeasureDataSingleton.AccessCount++;
                            return (string[][])proxyData[waferID];
                        }
                    }
                default:
                    {
                        return null;
                    }
            }
           
        }

    }

   
    public class WaferBinDataSingleton
    {
        public static DateTime UpdateTime { get; internal set; }
        protected WaferBinDataSingleton()
        {
            UpdateTime = DateTime.Now;
        }

        public static string [][] GetMapData(int size)
        {
            AccessCount++;
            UpdateTime = DateTime.Now;
            var mapData = new string[size][];
            for (int i= 0; i < size; i++)
            {
                mapData[i] = new string[size];
                for (int x = 0; x < size; x++)
                {
                    mapData[i][x] = new Random().Next(1, size * size).ToString();
                }
            }
            return mapData;

        }


        public static int AccessCount { get; internal set; }
        public static void Reset()
        {
            AccessCount = 0;
        }

    }

    public class WaferMeasureDataSingleton
    {
        public static DateTime UpdateTime { get; internal set; }
        protected WaferMeasureDataSingleton()
        {
            UpdateTime = DateTime.Now;
        }

        public static string[][] GetMapData(int size)
        {
            AccessCount++;
            UpdateTime = DateTime.Now;
            var mapData = new string[size][];
            for (int i = 0; i < size; i++)
            {
                mapData[i] = new string[size];
                for (int x = 0; x < size; x++)
                {
                    mapData[i][x] = (new Random().Next(1, size * size)).ToString()+ " µm";
                }
            }
            return mapData;

        }


        public static int AccessCount { get; internal set; }
        public static void Reset()
        {
            AccessCount = 0;
        }

    }

}
