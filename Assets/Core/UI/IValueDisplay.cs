namespace Core.UI
{
    public interface IValueDisplay<in T>
    {
        /// <summary>
        /// Sets and updates the UI with the provided value.
        /// </summary>
        void Set(T value);
    }
}