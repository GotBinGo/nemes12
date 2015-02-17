using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace elore
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = File.ReadAllLines("elore.be").Select(x => x.Split().Select(y => int.Parse(y)).ToList()).ToList();
            var k = a[0][2];
            a.RemoveAt(0);
            using (StreamWriter sw = new StreamWriter("elore.ki"))
            {
                var f1 = a.Select((x, i) => new { x = x.Max(), i = i + 1 }).OrderByDescending(x => x.x).First().i;
                sw.WriteLine(f1);
                var f2 = a.Select((x, i) => new { x = x.Average(), i = i + 1 }).OrderByDescending(x => x.x).First().i;
                sw.WriteLine(f2);
                var f3 = a.Select((x, i) => new { x = la(x, k), i = i + 1 }).OrderByDescending(x => x.x).First();
                sw.WriteLine(f3.x == -1 ? -1 : f3.i);
                var cols = a.Select((x, num) => x.Select((y, i) => new { y, i, num })).SelectMany(x => x).GroupBy(x => x.i);
                var mad = cols.Select(x => new { x.Key, x = x.Select(y => Tuple.Create(y.y, y.num)).ToList(), i = x.Key }).Select(x => new { x.Key, ma = ma(x.x) });
                var f4 = mad.GroupBy(x => x.ma).OrderByDescending(x => x.Count()).ToList();
                sw.WriteLine(f4[0].Key == -1 ? -1 : f4[0].Key + 1);
            }
        }
        static int la(List<int> list, int k)
        {
            var p = string.Join("", list.Select(x => x > k ? 1 : 0)).Split('0').Max(x => x.Length);
            return p == 0 ? -1 : p;
        }
        static int ma(List<Tuple<int, int>> list)
        {
            var tmp = list.OrderByDescending(x => x.Item1).ToList();
            var p = tmp[0].Item1 == tmp[1].Item1 ? tmp[0].Item2 : -1;            
            return p == 0 ? -1 : p;
        }
    }
}
