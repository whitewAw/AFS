namespace AFS.Core.Model
{
    public class CurentPrevious
    {
        private double curent;
        private double previous;

        public event Action? OnChange;
        public double Curent
        {
            get => curent;
            set
            {
                curent = AFSConstraints.RoundStat(value);
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

        internal void Init(CurentPrevious fild)
        {
            curent = fild.Curent;
            previous = fild.Previous;
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
