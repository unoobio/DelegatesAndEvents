namespace DelegatesAndEvents.MaxExtension
{
    public static class EnumerableExtensions
    {
        public static T? GetMax<T>(this IEnumerable<T> enumerable, Func<T, float> getParameter) 
            where T : class
        {
            float max = float.MinValue;
            T? maxItem = default;
            foreach (T item in enumerable)
            {
                float currentValue = getParameter(item);
                if (currentValue > max)
                {
                    max = currentValue;
                    maxItem = item;
                }
            }

            return maxItem;
        }
    }
}
