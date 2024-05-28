using System.Globalization;
using System.Security.Cryptography;

namespace Charts.Services
{
    /// <summary>
    /// https://stackoverflow.com/questions/12294296/list-with-limited-item
    /// </summary>
    public class Buffer<T> : Queue<T>
    {
        public int? MaxCapacity { get; }

        public Buffer(int capacity)
        {
            MaxCapacity = capacity;
        }

        public int TotalItemsAddedCount { get; private set; }

        public void Add(T newElement)
        {
            Enqueue(newElement);
            TotalItemsAddedCount++;

            if (MaxCapacity.HasValue && Count > MaxCapacity)
            {
                Dequeue();
            }
        }
    }

    public static class BufferExtensions
    {
        public static Point AddNewRandomPoint(this Buffer<Point> buffer)
        {
            var now = DateTime.UtcNow.AddMonths(buffer.TotalItemsAddedCount);
            var year = now.Year;
            var monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(now.Month);
            var point = new Point($"{monthName} ({year})", RandomNumberGenerator.GetInt32(1, 11));
            buffer.Add(point);
            return point;
        }
    }
}
