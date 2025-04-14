
namespace COMTRADE_parser.MathMetod
{

    internal class SymmetricComponents
    {
        private readonly List<AnalogChannelConfig> _cfgChannels;
        private readonly List<List<double>> _datSamples;
        private List<int> _phaseIndices = new List<int>();

        public SymmetricComponents(List<AnalogChannelConfig> cfgChannels, List<List<double>> datSamples)
        {
            _cfgChannels = cfgChannels;
            _datSamples = datSamples;

            // Находим индексы фаз A, B, C
            FindPhaseIndices();
        }
        public List<List<double>> CalculateI0()
        {
            List<List<double>> I0 = new List<List<double>>();

            foreach (var sample in _datSamples)
            {
                double sum = sample[_phaseIndices[0]] + sample[_phaseIndices[1]] + sample[_phaseIndices[2]];
                I0.Add(sum / 3.0);
            }

            return I0;
        }
        private void FindPhaseIndices()
        {
            _phaseIndices.Clear();

            for (int i = 0; i < _cfgChannels.Count; i++)
            {
                var channel = _cfgChannels[i];
                // Проверяем, является ли канал фазой A, B или C (пример для токов)
                if (channel.Name.ToUpper().Contains("IA"))
                {
                    _phaseIndices.Add(i);
                }
                else if (channel.Name.ToUpper().Contains("IB"))
                {
                    _phaseIndices.Add(i);
                }
                else if (channel.Name.ToUpper().Contains("IC"))
                {
                    _phaseIndices.Add(i);
                }
            }

            if (_phaseIndices.Count != 3)
                throw new InvalidDataException("Не найдены фазы A, B, C.");
        }

    }
}
