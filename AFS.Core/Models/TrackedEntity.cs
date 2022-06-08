using System.Runtime.CompilerServices;

namespace AFS.Core.Models
{
    public class TrackedEntity
    {
        public event Action? PropertyChanged;

        internal void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke();
        }

        internal bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}