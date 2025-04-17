using COMTRADE_parser.Export;
using COMTRADE_parser.MathMetod;
using COMTRADE_parser.SelectSignal;
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
            //// Парсинг конфига
            //ICfgParser cfgParser = new CfgParser();
            //var config = cfgParser.Parse("25_newRTDS.cfg");
            //Console.WriteLine(config.AnalogChannels[0].Name);

            //// Парсинг данных
            //IDatParser datParser = new AsciiDatParser();
            //var analogData = datParser.ParseAnalogData("25_newRTDS.dat", config);
            //var discreteData = datParser.ParseDiscreteData("25_newRTDS.dat", config);

            // Экспорт в CSV
            CsvExporter csvExporter = new CsvExporter();
            Currents currents = new Currents(new Reader("25_newRTDS.cfg", "25_newRTDS.dat"));
            var calculator = new SymmetricComponents(currents.GetCurrnetCFG(), currents.GetCurrentsData());
            List<List<double>> I0Data = calculator.CalculateI0();
            csvExporter.ExportI0ToCsv("I0_Results.csv", I0Data);

            //exporter.ExportToCsv(config, analogData, discreteData, "output.csv");

            //foreach (var data in analogData)
            //{
            //    Console.WriteLine(data[0]);
            //}
        }
    }
}
