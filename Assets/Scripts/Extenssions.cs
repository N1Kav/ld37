using System.Collections.Generic;
using System.Linq;

public static class Extenssions
{
    public static void Shuffle<T>( this IList<T> list )
    {
        var n = list.Count;
        while ( n > 1 )
        {
            n--;
            var k = UnityEngine.Random.Range( 0, n + 1 );
            var value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public static Dictionary<TKey, TValue> Shuffle<TKey, TValue>( this Dictionary<TKey, TValue> source )
    {
        var random = UnityEngine.Random.Range( 0, source.Keys.Count + 1 );
        return source.OrderBy( x => random ).ToDictionary( item => item.Key, item => item.Value );
    }

    public static T GetRandomElement<T>( this IList<T> list )
    {
        return list.Count > 0 ? list[UnityEngine.Random.Range( 0, list.Count )] : default(T);
    }
}
