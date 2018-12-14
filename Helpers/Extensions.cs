using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Helpers.Extensions
{
        public enum Direction
    {
        Down,
        Up,
        Right,
        Left
    }
    public static class MyExtensions {
        public static bool CanReact(this char poly1, char poly2){
            var sameType = char.ToUpperInvariant(poly1) == char.ToUpperInvariant(poly2);
            if(sameType)
            {
                var oppositePolarity = (char.IsLower(poly1) && char.IsUpper(poly2)) || (char.IsUpper(poly1) && char.IsLower(poly2));
                return oppositePolarity;
            }            
            return false;
        }
    }

    public static class StringManipulationExtensions
    {
        public static StringBuilder SwapPositions(this StringBuilder source, int x, int y)
        {
            var xChar = source[x];
            var yChar = source[y];

            source = source.Remove(x, 1);
            source = source.Insert(x, yChar);

            source = source.Remove(y, 1);
            source = source.Insert(y, xChar);

            return source;
        }

        public static string SwapPositions(this string source, int x, int y)
        {
            return new StringBuilder(source).SwapPositions(x, y).ToString();
        }

        public static StringBuilder RotateLeft(this StringBuilder source)
        {
            var startChar = source[0];

            source.Remove(0, 1);
            source.Insert(source.Length, startChar);

            return source;
        }

        public static StringBuilder RotateRight(this StringBuilder source)
        {
            var endChar = source[source.Length - 1];

            source.Remove(source.Length - 1, 1);
            source.Insert(0, endChar);

            return source;
        }

        public static string RotateLeft(this string source)
        {
            return new StringBuilder(source).RotateLeft().ToString();
        }

        public static string RotateRight(this string source)
        {
            return new StringBuilder(source).RotateRight().ToString();
        }

        public static StringBuilder RotateRight(this StringBuilder source, int rotateCount)
        {
            for (var i = 0; i < rotateCount; i++)
            {
                source.RotateRight();
            }

            return source;
        }

        public static StringBuilder RotateLeft(this StringBuilder source, int rotateCount)
        {
            for (var i = 0; i < rotateCount; i++)
            {
                source.RotateLeft();
            }

            return source;
        }

        public static string RotateRight(this string source, int rotateCount)
        {
            for (var i = 0; i < rotateCount; i++)
            {
                source.RotateRight();
            }

            return source;
        }

        public static string RotateLeft(this string source, int rotateCount)
        {
            for (var i = 0; i < rotateCount; i++)
            {
                source.RotateLeft();
            }

            return source;
        }

        public static string ReverseString(this string source)
        {
            return new string(source.Reverse().ToArray());
        }

        public static IEnumerable<string> Lines(this string input)
        {
            return input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static IEnumerable<string> Words(this string input)
        {
            return input.Split(new string[] { " ", "\t", Environment.NewLine, "," }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static IEnumerable<int> Integers(this string input)
        {
            return input.Words().Select(x => int.Parse(x)).ToList();
        }

        public static IEnumerable<double> Doubles(this string input)
        {
            return input.Words().Select(x => double.Parse(x)).ToList();
        }

        public static bool IsAnagram(this string a, string b)
        {
            return a.ToCharArray().UnorderedEquals(b.ToCharArray());
        }

        public static string ShaveLeft(this string a, int characters)
        {
            return a.Substring(characters);
        }

        public static string ShaveLeft(this string a, string shave)
        {
            var result = a;

            while (result.StartsWith(shave))
            {
                result = result.Substring(shave.Length);
            }

            return result;
        }

        public static string ShaveRight(this string a, int characters)
        {
            return a.Substring(0, a.Length - characters);
        }

        public static string ShaveRight(this string a, string shave)
        {
            var result = a;

            while (result.EndsWith(shave))
            {
                result = result.Substring(0, result.Length - shave.Length);
            }

            return result;
        }

        public static string Shave(this string a, int characters)
        {
            return a.Substring(characters, a.Length - (characters * 2));
        }

        public static string Shave(this string a, string shave)
        {
            var result = a;

            while (result.StartsWith(shave))
            {
                result = result.Substring(shave.Length);
            }

            while (result.EndsWith(shave))
            {
                result = result.Substring(0, result.Length - shave.Length);
            }

            return result;
        }

        public static string Strip(this string a, params string[] remove)
        {
            var result = a;

            while (remove.Any(x => result.Contains(x)))
            {
                var r = remove.First(x => result.Contains(x));

                result = result.Remove(result.IndexOf(r), r.Length);
            }

            return result;
        }

        public static string HexToBinary(this string hex)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var c in hex.ToCharArray())
            {
                var intValue = int.Parse(c.ToString(), System.Globalization.NumberStyles.HexNumber);
                sb.Append(Convert.ToString(intValue, 2).PadLeft(4, '0'));
            }

            return sb.ToString();
        }

        public static string Overlap(this string a, string b)
        {
            return new string(Overlap<char>(a, b).ToArray());
        }

        public static IEnumerable<T> Overlap<T>(this IEnumerable<T> a, IEnumerable<T> b) where T : IEquatable<T>
        {
            var result = new List<T>();
            var c = a.ToList();
            var d = b.ToList();

            for (var x = 0; x < Math.Min(c.Count, d.Count); x++)
            {
                if (c[x].Equals(d[x]))
                {
                    result.Add(c[x]);
                }
            }

            return result;
        }

        public static void Deconstruct<T>(this IList<T> list, out T first)
        {
            first = list.Count > 0 ? list[0] : default(T); // or throw
        }

        public static void Deconstruct<T>(this IList<T> list, out T first, out T second)
        {
            first = list.Count > 0 ? list[0] : default(T); // or throw
            second = list.Count > 1 ? list[1] : default(T); // or throw

        }

        public static void Deconstruct<T>(this IList<T> list, out T first, out T second, out T third)
        {
            first = list.Count > 0 ? list[0] : default(T); // or throw
            second = list.Count > 1 ? list[1] : default(T); // or throw
            third = list.Count > 2 ? list[2] : default(T); // or throw
        }

        public static void Deconstruct<T>(this IList<T> list, out T first, out T second, out T third, out T fourth)
        {
            first = list.Count > 0 ? list[0] : default(T); // or throw
            second = list.Count > 1 ? list[1] : default(T); // or throw
            third = list.Count > 2 ? list[2] : default(T); // or throw
            fourth = list.Count > 3 ? list[3] : default(T); // or throw
        }

        public static void Deconstruct<T>(this IList<T> list, out T first, out T second, out T third, out T fourth, out T fifth)
        {
            first = list.Count > 0 ? list[0] : default(T); // or throw
            second = list.Count > 1 ? list[1] : default(T); // or throw
            third = list.Count > 2 ? list[2] : default(T); // or throw
            fourth = list.Count > 3 ? list[3] : default(T); // or throw
            fifth = list.Count > 4 ? list[4] : default(T); // or throw
        }

        public static void Deconstruct<T>(this IList<T> list, out T first, out T second, out T third, out T fourth, out T fifth, out T sixth)
        {
            first = list.Count > 0 ? list[0] : default(T); // or throw
            second = list.Count > 1 ? list[1] : default(T); // or throw
            third = list.Count > 2 ? list[2] : default(T); // or throw
            fourth = list.Count > 3 ? list[3] : default(T); // or throw
            fifth = list.Count > 4 ? list[4] : default(T); // or throw
            sixth = list.Count > 5 ? list[5] : default(T); // or throw
        }

        public static void Deconstruct<T>(this IList<T> list, out T first, out T second, out T third, out T fourth, out T fifth, out T sixth, out T seventh)
        {
            first = list.Count > 0 ? list[0] : default(T); // or throw
            second = list.Count > 1 ? list[1] : default(T); // or throw
            third = list.Count > 2 ? list[2] : default(T); // or throw
            fourth = list.Count > 3 ? list[3] : default(T); // or throw
            fifth = list.Count > 4 ? list[4] : default(T); // or throw
            sixth = list.Count > 5 ? list[5] : default(T); // or throw
            seventh = list.Count > 6 ? list[6] : default(T); // or throw
        }

        public static void Deconstruct<T>(this IList<T> list, out T first, out T second, out T third, out T fourth, out T fifth, out T sixth, out T seventh, out T eigth)
        {
            first = list.Count > 0 ? list[0] : default(T); // or throw
            second = list.Count > 1 ? list[1] : default(T); // or throw
            third = list.Count > 2 ? list[2] : default(T); // or throw
            fourth = list.Count > 3 ? list[3] : default(T); // or throw
            fifth = list.Count > 4 ? list[4] : default(T); // or throw
            sixth = list.Count > 5 ? list[5] : default(T); // or throw
            seventh = list.Count > 6 ? list[6] : default(T); // or throw
            eigth = list.Count > 7 ? list[7] : default(T); // or throw
        }
    }

    public static class CollectionExtensions
    {
        public static void AddRange<T>(this ConcurrentBag<T> @this, IEnumerable<T> toAdd)
        {
            foreach (var element in toAdd)
            {
                @this.Add(element);
            }
        }

        public static bool UnorderedEquals<T>(this IEnumerable<T> a, IEnumerable<T> b)
        {
            if (a.Count() != b.Count())
            {
                return false;
            }

            var sortedA = a.OrderBy(x => x);
            var sortedB = b.OrderBy(x => x);

            return sortedA.SequenceEqual(sortedB);
        }

        public static void ForEach<T>(this T[,] a, Action<int, int> action)
        {
            for (var x = a.GetLowerBound(0); x <= a.GetUpperBound(0); x++)
            {
                for (var y = a.GetLowerBound(1); y <= a.GetUpperBound(1); y++)
                {
                    action(x, y);
                }
            }
        }

        public static void ForEach<T>(this T[,] a, Action<T> action)
        {
            for (var x = a.GetLowerBound(0); x <= a.GetUpperBound(0); x++)
            {
                for (var y = a.GetLowerBound(1); y <= a.GetUpperBound(1); y++)
                {
                    action(a[x, y]);
                }
            }
        }

        public static IEnumerable<(int index, T item)> SelectWithIndex<T>(this IEnumerable<T> a)
        {
            var list = a.ToList();

            for (var i = 0; i < list.Count; i++)
            {
                yield return (i, list[i]);
            }
        }

        public static IEnumerable<T> ToList<T>(this T[,] a)
        {
            for (var x = a.GetLowerBound(0); x <= a.GetUpperBound(0); x++)
            {
                for (var y = a.GetLowerBound(1); y <= a.GetUpperBound(1); y++)
                {
                    yield return a[x, y];
                }
            }
        }

        public static void ForEach<T>(this T[,,] a, Action<int, int, int> action)
        {
            for (var x = a.GetLowerBound(0); x <= a.GetUpperBound(0); x++)
            {
                for (var y = a.GetLowerBound(1); y <= a.GetUpperBound(1); y++)
                {
                    for (var z = a.GetLowerBound(2); z <= a.GetUpperBound(2); z++)
                    {
                        action(x, y, z);
                    }
                }
            }
        }

        public static void ForEach<T>(this T[,,] a, Action<T> action)
        {
            for (var x = a.GetLowerBound(0); x <= a.GetUpperBound(0); x++)
            {
                for (var y = a.GetLowerBound(1); y <= a.GetUpperBound(1); y++)
                {
                    for (var z = a.GetLowerBound(2); z <= a.GetUpperBound(2); z++)
                    {
                        action(a[x, y, z]);
                    }
                }
            }
        }

        public static IEnumerable<T> ToList<T>(this T[,,] a)
        {
            for (var x = a.GetLowerBound(0); x <= a.GetUpperBound(0); x++)
            {
                for (var y = a.GetLowerBound(1); y <= a.GetUpperBound(1); y++)
                {
                    for (var z = a.GetLowerBound(2); z <= a.GetUpperBound(2); z++)
                    {
                        yield return a[x, y, z];
                    }
                }
            }
        }

        public static int IndexOf<T>(this T[] a, T b)
        {
            for (var i = a.GetLowerBound(0); i <= a.GetUpperBound(0); i++)
            {
                if (a[i].Equals(b))
                {
                    return i;
                }
            }

            return -1;
        }

        public static T WithMin<T>(this IEnumerable<T> a, Func<T, int> selector)
        {
            var min = a.Min(selector);
            return a.First(x => selector(x) == min);
        }

        public static T WithMin<T>(this IEnumerable<T> a, Func<T, long> selector)
        {
            var min = a.Min(selector);
            return a.First(x => selector(x) == min);
        }

        public static T WithMin<T>(this IEnumerable<T> a, Func<T, double> selector)
        {
            var min = a.Min(selector);
            return a.First(x => selector(x) == min);
        }

        public static T WithMax<T>(this IEnumerable<T> a, Func<T, int> selector)
        {
            var max = a.Max(selector);
            return a.First(x => selector(x) == max);
        }

        public static T WithMax<T>(this IEnumerable<T> a, Func<T, long> selector)
        {
            var max = a.Max(selector);
            return a.First(x => selector(x) == max);
        }

        public static T WithMax<T>(this IEnumerable<T> a, Func<T, double> selector)
        {
            var max = a.Max(selector);
            return a.First(x => selector(x) == max);
        }

        public static IEnumerable<T> Cycle<T>(this IEnumerable<T> a)
        {
            while (true)
            {
                foreach (var x in a)
                {
                    yield return x;
                }
            }
        }

        public static void SafeIncrement<TKey>(this Dictionary<TKey, int> dict, TKey key)
        {
            if (dict.ContainsKey(key))
            {
                dict[key]++;
            }
            else
            {
                dict.Add(key, 1);
            }
        }

        public static void SafeDecrement<TKey>(this Dictionary<TKey, int> dict, TKey key)
        {
            if (dict.ContainsKey(key))
            {
                dict[key]++;
            }
            else
            {
                dict.Add(key, -1);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            list.ToList().ForEach(action);
        }

        public static LinkedListNode<T> PreviousCircular<T>(this LinkedListNode<T> node)
        {
            return node.Previous ?? node.List.Last;
        }

        public static LinkedListNode<T> PreviousCircular<T>(this LinkedListNode<T> node, int hops)
        {
            var result = node;

            Enumerable.Range(0, hops).ForEach(x => result = result.PreviousCircular());

            return result;
        }

        public static LinkedListNode<T> NextCircular<T>(this LinkedListNode<T> node)
        {
            return node.Next ?? node.List.First;
        }

        public static LinkedListNode<T> NextCircular<T>(this LinkedListNode<T> node, int hops)
        {
            var result = node;

            Enumerable.Range(0, hops).ForEach(x => result = result.NextCircular());

            return result;
        }
    }

    public static class PointExtensions
    {
        public static IEnumerable<Point> GetNeighbors(this Point point)
        {
            return point.GetNeighbors(true);
        }

        public static IEnumerable<Point> GetNeighbors(this Point point, bool includeDiagonals)
        {
            var adjacentPoints = new List<Point>(8);

            adjacentPoints.Add(new Point(point.X - 1, point.Y));
            adjacentPoints.Add(new Point(point.X + 1, point.Y));
            adjacentPoints.Add(new Point(point.X, point.Y + 1));
            adjacentPoints.Add(new Point(point.X, point.Y - 1));

            if (includeDiagonals)
            {
                adjacentPoints.Add(new Point(point.X - 1, point.Y - 1));
                adjacentPoints.Add(new Point(point.X + 1, point.Y - 1));
                adjacentPoints.Add(new Point(point.X + 1, point.Y + 1));
                adjacentPoints.Add(new Point(point.X - 1, point.Y + 1));
            }

            return adjacentPoints;
        }

        public static int ManhattanDistance(this Point point)
        {
            return point.ManhattanDistance(new Point(0, 0));
        }

        public static int ManhattanDistance(this Point point, Point target)
        {
            return Math.Abs(point.X - target.X) + Math.Abs(point.Y - target.Y);
        }

        public static Point MoveDown(this Point point, int distance)
        {
            return new Point(point.X, point.Y - distance);
        }

        public static Point MoveUp(this Point point, int distance)
        {
            return new Point(point.X, point.Y + distance);
        }

        public static Point MoveRight(this Point point, int distance)
        {
            return new Point(point.X + distance, point.Y);
        }

        public static Point MoveLeft(this Point point, int distance)
        {
            return new Point(point.X - distance, point.Y);
        }

        public static Point MoveDown(this Point point)
        {
            return point.MoveDown(1);
        }

        public static Point MoveUp(this Point point)
        {
            return point.MoveUp(1);
        }

        public static Point MoveRight(this Point point)
        {
            return point.MoveRight(1);
        }

        public static Point MoveLeft(this Point point)
        {
            return point.MoveLeft(1);
        }

        public static Point Move(this Point point, Direction direction, int distance)
        {
            switch (direction)
            {
                case Direction.Down:
                    return point.MoveDown(distance);
                case Direction.Up:
                    return point.MoveUp(distance);
                case Direction.Right:
                    return point.MoveRight(distance);
                case Direction.Left:
                    return point.MoveLeft(distance);
                default:
                    throw new ArgumentException();
            }
        }

        public static Point Move(this Point point, Direction direction)
        {
            return point.Move(direction, 1);
        }
    }

    public static class RectangleExtensions
    {
        public static IEnumerable<Point> GetPoints(this Rectangle rect)
        {
            for (var x = rect.Left; x < rect.Left + rect.Width; x++)
            {
                for (var y = rect.Top; y < rect.Top + rect.Height; y++)
                {
                    yield return new Point(x, y);
                }
            }
        }
    }

    public class Point3D : IEquatable<Point3D>
    {
        public long X { get; set; }
        public long Y { get; set; }
        public long Z { get; set; }

        public Point3D(long x, long y, long z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point3D(string coordinates) :
            this(long.Parse(coordinates.Words().ToList()[0]),
                 long.Parse(coordinates.Words().ToList()[1]),
                 long.Parse(coordinates.Words().ToList()[2]))
        {
        }

        public long GetManhattanDistance()
        {
            return Math.Abs(X - 0) + Math.Abs(Y - 0) + Math.Abs(Z - 0);
        }

        public static bool operator ==(Point3D a, Point3D b)
        {
            return a.X == b.X && a.Y == b.Y && a.Z == b.Z;
        }

        public static bool operator !=(Point3D a, Point3D b)
        {
            return a.X != b.X || a.Y != b.Y || a.Z != b.Z;
        }

        public static Point3D operator +(Point3D a, Point3D b)
        {
            return new Point3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Point3D operator -(Point3D a, Point3D b)
        {
            return new Point3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public override string ToString()
        {
            return $"{X},{Y},{Z}";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Point3D);
        }

        public bool Equals(Point3D other)
        {
            return other != null && this == other;
        }

        public override int GetHashCode()
        {
            var hashCode = -307843816;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            hashCode = hashCode * -1521134295 + Z.GetHashCode();
            return hashCode;
        }
    }
}