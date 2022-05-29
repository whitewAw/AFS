namespace AFS.Core.Model
{
    public class BeginEnd
    {
        private double begin;
        private double end;

        public event Action? OnChange;
        public double Begin
        {
            get => begin;
            set
            {
                if (begin != value)
                {
                    begin = AFSConstraints.RoundStat(value);
                    NotifyStateChanged();
                }
            }
        }
        public double End
        {
            get => end;
            set
            {
                if (end != value)
                {
                    end = AFSConstraints.RoundStat(value);
                    NotifyStateChanged();
                }
            }
        }

        internal void Init(BeginEnd fild)
        {
            begin = fild.Begin;
            end = fild.End;
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}