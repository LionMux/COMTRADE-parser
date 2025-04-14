using static ParseCFG;

namespace COMTRADE_parser.SelectSignal
{
    internal class Voltage
    {
        private readonly IDataReader _dataReader;
        private List<int> _voltageChannelIndexes;

        public Voltage(IDataReader dataReader)
        {
            _voltageChannelIndexes = FindIndexVoltage();
            _dataReader = dataReader;
        }

        public List<int> FindIndexVoltage()
        {
            List<int> Indexes = new List<int>();
            for (int i = 0; i < _dataReader.Config.AnalogChannels.Count; i++)
            {
                var channel = _dataReader.Config.AnalogChannels[i];
                if (channel.Unit == "kA" || channel.Unit == "A")
                {
                    Indexes.Add(i);
                }
            }
            return Indexes;
        }
        public List<List<double>> GetVoltageData()
        {
            List<List<double>> voltage = new List<List<double>>();

            foreach (var sample in _dataReader.AnalogData)
            {
                List<double> voltageSample = new List<double>();

                foreach (int channelIndex in _voltageChannelIndexes)
                {
                    if (channelIndex < sample.Count)
                    {
                        voltageSample.Add(sample[channelIndex]);
                    }
                }
                voltage.Add(voltageSample);
            }

            return voltage;
        }
    }
}
