namespace AFS.Core.Model
{
    public class CurrentPrevious
    {
        private double current;
        private double previous;

        public event Action? OnChange;
        public double Current
        {
            get => current;
            set
            {
                current = AFSConstraints.RoundStat(value);
                NotifyStateChanged();
            }
        }
        public double Previous
        {
            get => previous;
            set
            {
                previous = AFSConstraints.RoundStat(value);
                NotifyStateChanged();
            }
        }

        internal void Init(CurrentPrevious fild)
        {
            current = fild.Current;
            previous = fild.Previous;
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}