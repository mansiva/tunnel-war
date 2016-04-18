using UnityEngine;
using System.Collections.Generic;

public static class ArrayExtensions
{
	public static void Shuffle<T> ( this List<T> list )
    {// shuffles the elements in the list randomly with knuth fischer yates shuffle, source: http://forum.unity3d.com/threads/46234-Shuffling-an-array, http://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle, http://forum.unity3d.com/threads/29977-Randomising-shuffling-library
        int count = list.Count, i, randIndex;
        for (i = count - 1; i > 0; --i)
        {
            randIndex = Random.Range ( 0, i );  // note: shifts random elements to the foward going end so the order is determined in opposite direction, the elements choosen first are the last ones in the resulting list
            T temp = list[i];
            list[i] = list[randIndex];
            list[randIndex] = temp;
        }
    }

   public static void Shuffle<T> ( this T[] array )
    {// shuffles the elements in the list randomly with knuth fischer yates shuffle, source: http://forum.unity3d.com/threads/46234-Shuffling-an-array, http://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle, http://forum.unity3d.com/threads/29977-Randomising-shuffling-library
        int count = array.Length, i, randIndex;
        for (i = count - 1; i > 0; --i)
        {
            randIndex = Random.Range ( 0, i );
            T temp = array[i];
            array[i] = array[randIndex];    // note: shifts random elements to the foward going end so the order is determined in opposite direction, the elements choosen first are the last ones in the resulting list
            array[randIndex] = temp;
        }
    }
}
