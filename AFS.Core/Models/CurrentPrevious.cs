using AFS.Core.Models;

namespace AFS.Core.Model
{
    public class CurrentPrevious : TrackedEntity
    {
        private double current;
        private double previous;
        public double Current
        {
            get => current;
            set => SetProperty(ref current, AFSConstraints.RoundStat(value));
        }
        public double Previous
        {
            get => previous;
            set => SetProperty(ref previous, AFSConstraints.RoundStat(value));
        }

        internal void Init(CurrentPrevious fild)
        {
            current = fild.Current;
            previous = fild.Previous;
        }
    }
}