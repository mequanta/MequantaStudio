using System;
using SmartQuant;
using System.Collections.Generic;

namespace MequantaStudio.SmartQuant
{
    public static class SmartQuantUtils
    {
        public static string ConvertToString(byte dataType, BarType? barType = null, long? barSize = null)
        {
            switch (dataType)
            {
                case DataObjectType.Bid:
                    return "Bid";
                case DataObjectType.Ask:
                    return "Ask";
                case DataObjectType.Trade:
                    return "Trade";
                case DataObjectType.Quote:
                    return "Quote";
                case DataObjectType.Bar:
                    if (!barType.HasValue)
                        return "Bar";
                    if (!barSize.HasValue)
                        return string.Format("Bar {0}", barType.Value);
                    else
                        return string.Format("Bar {0} {1}", barType.Value, barSize.Value);
                default:
                    return string.Format("DataType #{0}", dataType);
            }
        }

        private static BarTypeSize[] GetAllowedBarTypeSizeList()
        {
            List<BarTypeSize> list = new List<BarTypeSize>();
            list.Add(new BarTypeSize(BarType.Time, 1));
            list.Add(new BarTypeSize(BarType.Time, 2));
            list.Add(new BarTypeSize(BarType.Time, 5));
            list.Add(new BarTypeSize(BarType.Time, 10));
            list.Add(new BarTypeSize(BarType.Time, 15));
            list.Add(new BarTypeSize(BarType.Time, 20));
            list.Add(new BarTypeSize(BarType.Time, 30));
            list.Add(new BarTypeSize(BarType.Time, 60));
            list.Add(new BarTypeSize(BarType.Time, 120));
            list.Add(new BarTypeSize(BarType.Time, 180));
            list.Add(new BarTypeSize(BarType.Time, 300));
            list.Add(new BarTypeSize(BarType.Time, 600));
            list.Add(new BarTypeSize(BarType.Time, 900));
            list.Add(new BarTypeSize(BarType.Time, 1200));
            list.Add(new BarTypeSize(BarType.Time, 1800));
            list.Add(new BarTypeSize(BarType.Time, 3600));
            list.Add(new BarTypeSize(BarType.Time, 7200));
            list.Add(new BarTypeSize(BarType.Time, 10800));
            list.Add(new BarTypeSize(BarType.Time, 21600));
            list.Add(new BarTypeSize(BarType.Time, 43200));
            list.Add(new BarTypeSize(BarType.Time, 86400));
            list.Add(new BarTypeSize(BarType.Tick, 1));
            list.Add(new BarTypeSize(BarType.Tick, 5));
            list.Add(new BarTypeSize(BarType.Tick, 10));
            list.Add(new BarTypeSize(BarType.Tick, 50));
            list.Add(new BarTypeSize(BarType.Tick, 100));
            list.Add(new BarTypeSize(BarType.Tick, 500));
            list.Add(new BarTypeSize(BarType.Tick, 1000));
            list.Add(new BarTypeSize(BarType.Volume, 10));
            list.Add(new BarTypeSize(BarType.Volume, 50));
            list.Add(new BarTypeSize(BarType.Volume, 100));
            list.Add(new BarTypeSize(BarType.Volume, 500));
            list.Add(new BarTypeSize(BarType.Volume, 1000));
            list.Add(new BarTypeSize(BarType.Volume, 5000));
            list.Add(new BarTypeSize(BarType.Volume, 10000));
            list.Add(new BarTypeSize(BarType.Volume, 50000));
            list.Add(new BarTypeSize(BarType.Volume, 100000));
            list.Add(new BarTypeSize(BarType.Range, 10));
            list.Add(new BarTypeSize(BarType.Range, 100));
            list.Add(new BarTypeSize(BarType.Range, 500));
            list.Add(new BarTypeSize(BarType.Range, 1000));
            list.Add(new BarTypeSize(BarType.Range, 5000));
            list.Add(new BarTypeSize(BarType.Range, 10000));

            return list.ToArray();
        }
    }

    class BarTypeSize
    {
        public BarType BarType { get; private set; }

        public long BarSize { get; private set; }

        public BarTypeSize(BarType barType, long barSize)
        {
            BarType = barType;
            BarSize = barSize;
        }
    }
}


