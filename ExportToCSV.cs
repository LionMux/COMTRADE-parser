
namespace COMTRADE_parser
{
    public class CsvExporter : IDataExporter
    {
        public void ExportToCsv(ComtradeConfig config, List<List<double>> analogData, List<List<bool>> discreteData, string outputPath)
        {
            using var writer = new StreamWriter(outputPath);

            // Заголовки
            writer.Write("Time,");
            config.AnalogChannels.ForEach(c => writer.Write($"{c.Name},"));
            config.DiscreteChannels.ForEach(c => writer.Write($"{c.Name},"));
            writer.WriteLine();

            // Данные
            for (int i = 0; i < analogData.Count; i++)
            {
                writer.Write($"{i * (1.0 / config.LineFrequency)},"); // Время

                foreach (var value in analogData[i])
                {
                    writer.Write($"{value},");
                }

                foreach (var value in discreteData[i])
                {
                    writer.Write($"{(value ? "1" : "0")},");
                }

                writer.WriteLine();
            }
        }
    }

}
