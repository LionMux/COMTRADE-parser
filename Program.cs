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

            Currents currents = new Currents(new Reader("25_newRTDS.cfg", "25_newRTDS.dat"));
            var calculator = new SymmetricComponents(currents.GetCurrnetCFG(), currents.GetCurrentsData());
            List<List<double>> I0Data = calculator.CalculateI0();
            List<List<double>> IData = currents.GetCurrentsData();
            //CsvExporter.ExportToCsv("i0_results.csv", I0Data, samplingRate: 10000);
            CsvExporter.ExportToCsv("i_results.csv", IData, samplingRate: 10000);
            // Выведите первые 5 значений каждой группы
            //Console.WriteLine("Group 1: " + string.Join(", ", I0Data[0].Take(5)));
            //Console.WriteLine("Group 2: " + string.Join(", ", I0Data[1].Take(5)));

        }
    }
}
