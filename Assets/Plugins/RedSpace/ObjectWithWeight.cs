using System.Collections;
using System.Collections.Generic;
namespace RedSpace
{
    [System.Serializable]
    public class ObjectWithWeight<T>
    {
        public static System.Random random;
        public T element;
        public int weight;

        public static T GetRandomElementFrom(List<ObjectWithWeight<T>> list)
        {
            return GetRandomFrom(list.ToArray()).element;
        }
        public static T GetRandomElementFrom(ObjectWithWeight<T>[] array)
        {
            return GetRandomFrom(array).element;
        }
        public static ObjectWithWeight<T> GetRandomFrom(List<ObjectWithWeight<T>> list)
        {
            return GetRandomFrom(list.ToArray());
        }
        public static ObjectWithWeight<T> GetRandomFrom(ObjectWithWeight<T>[] array)
        {

#if UNITY_EDITOR
            if (array.Length < 1) { throw new System.Exception("Array should have at least one element !"); }
#endif
            if (random == null) { random = new System.Random(); }
            int totalWeight = 0;
            for (int i = 0; i < array.Length; ++i)
            {
#if UNITY_EDITOR
                if (array[i].weight < 0) { throw new System.Exception("An element weight should nether be <0 !"); }
#endif
                totalWeight += array[i].weight;
            }
            int selected = random.Next(0, totalWeight);
            int previousWeights = 0;
#if UNITY_EDITOR
            for (int i = 0; i < array.Length; ++i)
#else
            for (int i = 0; i < (array.Length - 1); ++i)
#endif
            {
                if (selected < previousWeights + array[i].weight)
                {
                    return array[i];
                }
                previousWeights += array[i].weight;
            }
#if UNITY_EDITOR
            throw new System.Exception("Error in this script, we should never reach this line.");
#else
            if (array.Length > 0)
            {
                return array[array.Length - 1]
            }
            return null;
#endif
        }
    }
}
