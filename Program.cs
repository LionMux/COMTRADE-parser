using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ParseCFG;

namespace COMTRADE_parser
{
    class Program
    {
        static void Main()
        {
            // Парсинг конфига
            ICfgParser cfgParser = new CfgParser();
            var config = cfgParser.Parse("25_newRTDS.cfg");
            Console.WriteLine(config.AnalogChannels[0].Name);

            // Парсинг данных
            IDatParser datParser = new AsciiDatParser();
            var analogData = datParser.ParseAnalogData("25_newRTDS.dat", config);
            var discreteData = datParser.ParseDiscreteData("25_newRTDS.dat", config);

            //// Экспорт в CSV
            //IDataExporter exporter = new CsvExporter();
            //exporter.ExportToCsv(config, analogData, discreteData, "output.csv");

            foreach (var data in analogData)
            {
                Console.WriteLine(data[0]);
            }
        }
    }
}
