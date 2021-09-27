using System.Collections.Generic;

namespace Algorithm.Composition
{
    public class HighPassSummingAggregator
    {
        private IEnumerable<Measurement> _measurements;
        private IMeasurementFilter _filter = new HighPassFilter();
        private IAggregationStrategy _aggregator = new SummingStrategy();
        public HighPassSummingAggregator(IEnumerable<Measurement> measurements)
        {
            _measurements = measurements;
        }

        public Measurement Aggregate()
        {
            var measurements = _measurements;
            measurements = _filter.Filter(measurements);            
            return _aggregator.Aggregate(measurements);
        }
    }
}