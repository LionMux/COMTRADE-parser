
namespace COMTRADE_parser.MathMetod
{

    internal class SymmetricComponents
    {
        private readonly List<AnalogChannelConfig> _cfgChannels;
        private readonly List<List<double>> _datSamples;
        private List<int> _phaseIndices = new List<int>();
        List<double> phaseA = new List<double>();
        List<double> phaseB = new List<double>();
        List<double> phaseC = new List<double>();

        public SymmetricComponents(List<AnalogChannelConfig> cfgChannels, List<List<double>> datSamples)
        {
            _cfgChannels = cfgChannels;
            _datSamples = datSamples;
        }
        public List<List<double>> CalculateI0()
        {
            List<List<double>> I0 = new List<List<double>>();
            for (int i = 0; i < _cfgChannels.Count; i++)
            {
                int j = i;
                FindPhaseIndices()
                double sum = phaseA[i] + phaseB[i] + phaseC[i];
                I0.Add(sum / 3.0);
            }


            return I0;
        }
        private void FindPhaseIndices()
        {
            _phaseIndices.Clear();
            var channel = _cfgChannels[j];
            // Проверяем, является ли канал фазой A, B или C (пример для токов)
            for (int i = 0; i < _cfgChannels.Count; i++)
            {
                foreach (var sample in _datSamples)
                {
                    if (channel.Name.ToUpper().Contains("IA"))
                    {
                        phaseA.Add(sample[i]);

                    }
                    else if (channel.Name.ToUpper().Contains("IB"))
                    {
                        phaseB.Add(sample[i]);
                    }
                    else if (channel.Name.ToUpper().Contains("IC"))
                    {
                        phaseC.Add(sample[i]);
                    }
                }
            }
        }

    }
}
