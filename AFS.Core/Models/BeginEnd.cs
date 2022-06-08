using AFS.Core.Models;

namespace AFS.Core.Model
{
    public class BeginEnd: TrackedEntity
    {
        private double begin;
        private double end;
        public double Begin
        {
            get => begin;
            set => SetProperty(ref begin, AFSConstraints.RoundStat(value));
        }
        public double End
        {
            get => end;
            set => SetProperty(ref end, AFSConstraints.RoundStat(value));
        }

        internal void Init(BeginEnd fild)
        {
            begin = fild.Begin;
            end = fild.End;
        }
    }
}