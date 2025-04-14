using static ParseCFG;

namespace COMTRADE_parser.SelectSignal
{
    internal class Currents 
    {
        private readonly IDataReader _dataReader;
        private List<int> _currentChannelIndexes;

        public Currents(IDataReader dataReader)
        {
            _dataReader = dataReader;
        }

        public List<AnalogChannelConfig> CFGCurrnet()
        {
            List<AnalogChannelConfig> cfgCurrents = new List<AnalogChannelConfig>();
            for (int i = 0; i < _dataReader.Config.AnalogChannels.Count; i++)
            {
                var channel = _dataReader.Config.AnalogChannels[i];
                if (channel.Unit == "kA" || channel.Unit == "A")
                {
                    _currentChannelIndexes.Add(i);
                    cfgCurrents.Add(channel);
                }
            }
            return cfgCurrents;
        }
        public List<List<double>> GetCurrentsData()
        {
            List<List<double>> currents = new List<List<double>>();

            foreach (var sample in _dataReader.AnalogData)
            {
                List<double> currentSample = new List<double>();

                foreach (int channelIndex in _currentChannelIndexes)
                {
                    if (channelIndex < sample.Count)
                    {
                        currentSample.Add(sample[channelIndex]);
                    }
                }
                currents.Add(currentSample);
            }

            return currents;
        }
    }
}
