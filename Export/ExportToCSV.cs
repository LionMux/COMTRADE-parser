using System.IO;
using System.Text;
using System.Linq;

namespace COMTRADE_parser.Export
{
    public class CsvExporter
    {
        public static void ExportI0ToCsv(string filePath, List<List<double>> I0Data, double samplingRate = 1000)
        {
            if (I0Data == null || I0Data.Count == 0)
                throw new ArgumentException("Нет данных для экспорта");

            // Проверяем одинаковое ли количество сэмплов во всех группах
            int sampleCount = I0Data[0].Count;
            if (I0Data.Any(group => group.Count != sampleCount))
                throw new InvalidDataException("Разное количество сэмплов в группах");

            using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                // Заголовок CSV
                writer.Write("Time(sec)");
                for (int i = 0; i < I0Data.Count; i++)
                {
                    writer.Write($",Group_{i + 1}_I0");
                }
                writer.WriteLine();

                // Данные
                double timeStep = 1.0 / samplingRate;
                for (int i = 0; i < sampleCount; i++)
                {
                    writer.Write($"{i * timeStep:0.00000}");
                    foreach (var group in I0Data)
                    {
                        writer.Write($",{group[i]:0.00000}");
                    }
                    writer.WriteLine();
                }
            }
        }
    }
}