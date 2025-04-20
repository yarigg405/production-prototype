using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using System.Linq;
using System.Text;


namespace Yrr.Utils
{
    public static class Extensions
    {
        public static void ClearChildren(this Transform transform)
        {
            var count = transform.childCount;
            if (count <= 0) return;
            for (var i = count - 1; i >= 0; i--)
            {
                var child = transform.GetChild(i);
                child.SetParent(null);
                Object.Destroy(child.gameObject);
            }
        }


        #region Vectors

        public static Vector2 GetRandomCoordinatesAroundPoint(this Vector2 originalPoint, float radius,
               bool pointOnRadiusLine = false)
        {
            float angle = Random.Range(0, 360);
            var lenght = pointOnRadiusLine ? radius :
                (Random.Range(0, radius));

            var x = Mathf.Cos(angle * Mathf.Deg2Rad) * lenght;
            var y = Mathf.Sin(angle * Mathf.Deg2Rad) * lenght;


            var result = new Vector2(originalPoint.x + x, originalPoint.y + y);


            return result;
        }

        public static Vector3 GetRandomCoordinatesAroundPointZX(this Vector3 originalPoint, float radius,
                bool pointOnRadiusLine = false)
        {
            float angle = Random.Range(0, 360);
            var lenght = pointOnRadiusLine ? radius :
                (Random.Range(0, radius));

            var x = Mathf.Cos(angle * Mathf.Deg2Rad) * lenght;
            var y = Mathf.Sin(angle * Mathf.Deg2Rad) * lenght;


            var result = new Vector3(originalPoint.x + x, originalPoint.y, originalPoint.z + y);
            return result;
        }

        public static Vector3 GetRandomCoordinatesAroundPointXY(this Vector3 originalPoint, float radius,
               bool pointOnRadiusLine = false)
        {
            float angle = Random.Range(0, 360);
            var lenght = pointOnRadiusLine ? radius :
                (Random.Range(0, radius));

            var x = Mathf.Cos(angle * Mathf.Deg2Rad) * lenght;
            var y = Mathf.Sin(angle * Mathf.Deg2Rad) * lenght;


            var result = new Vector3(originalPoint.x + x, originalPoint.y + y, originalPoint.z);
            return result;
        }

        public static Vector2 ToVector2XZ(this Vector3 vector)
        {
            return new Vector2(vector.x, vector.z);
        }

        public static Vector2 ToVector2XY(this Vector3 vector)
        {
            return new Vector2(vector.x, vector.y);
        }

        public static Vector3 InvertYZ(this Vector3 vector)
        {
            return new Vector3(vector.x, vector.z, vector.y);
        }

        #endregion


        #region GetRandom

        public static float GetRandomValue(this Vector2 vector)
        {
            return Random.Range(vector.x, vector.y);
        }

        public static T GetRandomItem<T>(this List<T> list)
        {
            return list.Count < 1 ? default : list[Random.Range(0, list.Count)];
        }

        public static T GetRandomItem<T>(this T[] list)
        {
            return list.Length < 1 ? default : list[Random.Range(0, list.Length)];
        }

        public static T GetRandomItem<T>(this IEnumerable<T> list)
        {
            var enumerable = list as T[] ?? list.ToArray();
            return enumerable.Any() ? enumerable.ElementAt(Random.Range(0, enumerable.Length)) : default;
        }

        #endregion


        #region Collections

        public static T GetLast<T>(this List<T> list)
        {
            return list.Count < 1 ? default : list[^1];
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = Random.Range(0, n);
                list.Swap(k, n);
            }
        }

        public static void Swap<T>(this IList<T> list, int indexA, int indexB)
        {
            (list[indexA], list[indexB]) = (list[indexB], list[indexA]);
        }

        public static void SwapWith<T>(this LinkedListNode<T> first, LinkedListNode<T> second)
        {
            var tmp = first.Value;
            first.Value = second.Value;
            second.Value = tmp;
        }
        #endregion


        #region Strings

        public static string ToIntString(this float value)
        {
            return ((int)value).ToString();
        }

        public static string ToDotString(this float value)
        {
            var str = value.ToString(CultureInfo.InvariantCulture);
            return str.Replace(",", ".");
        }

        public static string ToShortMoneyString(this int value)
        {
            return ((ulong)value).ToShortMoneyString();
        }

        private static string[] _moneyPrefix = { string.Empty, "K", "M", "B" };

        public static string ToShortMoneyString(this float value)
        {
            return ((ulong)value).ToShortMoneyString();
        }

        public static string ToShortMoneyString(this ulong value)
        {
            if (value == 0) return "0";
            string[] prefix = { string.Empty, "K", "M", "B" };
            var absolute = Mathf.Abs(value);
            int add;
            if (absolute < 1)
            {
                add = (int)Mathf.Floor(Mathf.Floor(Mathf.Log10(absolute)) / 3);
            }
            else
            {
                add = (int)(Mathf.Floor(Mathf.Log10(absolute)) / 3);
            }

            var shortNumber = value / Mathf.Pow(10, add * 3);

            shortNumber *= 100;
            shortNumber = Mathf.Floor(shortNumber);
            shortNumber /= 100;

            if (shortNumber > 100f)
                return $"{(int)shortNumber}{prefix[add]}";
            else if (shortNumber > 10f)
                return $"{shortNumber:0.#}{prefix[add]}";
            else
                return $"{shortNumber:0.##}{prefix[add]}";

        }

        public static ulong ToRounded(this ulong value)
        {
            if (value < 1000) return value;

            if (value < 10_000)
            {
                var shortVal = value / 10f;
                var rounded = Mathf.Round(shortVal);
                return (ulong)(rounded * 10f);
            }

            if (value < 100_000)
            {
                var shortVal = value / 100f;
                var rounded = Mathf.Round(shortVal);
                return (ulong)(rounded * 100f);
            }

            if (value < 1_000_000)
            {
                var shortVal = value / 1000f;
                var rounded = Mathf.Round(shortVal);
                return (ulong)(rounded * 1000f);
            }

            if (value < 1_000_000_000)
            {
                var shortVal = value / 100000f;
                var rounded = Mathf.Round(shortVal);
                return (ulong)(rounded * 100000f);
            }

            var shortVal1 = value / 1000000f;
            var rounded1 = Mathf.Round(shortVal1);
            return (ulong)(rounded1 * 1000000f);
        }

        public static string ToShortTimeString(this float timeValue)
        {
            var time = (int)timeValue + 1;

            var seconds = time % 60f;
            var minutes = time / 60;
            var hours = minutes / 60;
            minutes = minutes % 60;

            if (hours > 0) return hours.ToString("00") + "h ";
            if (minutes > 0) return minutes.ToString("00") + "m ";
            return seconds.ToString("00") + "s";
        }

        public static string ToTimeString(this float timeValue)
        {
            var time = (int)timeValue + 1;

            var seconds = time % 60f;
            var minutes = time / 60;
            var hours = minutes / 60;
            minutes = minutes % 60;

            var sb = new StringBuilder();
            if (hours > 0)
            {
                sb.Append(hours.ToString("00"));
                sb.Append(":");
            }
            sb.Append(minutes.ToString("0"));
            sb.Append(":");
            sb.Append(seconds.ToString("00"));

            return sb.ToString();
        }


        #endregion

    }
}