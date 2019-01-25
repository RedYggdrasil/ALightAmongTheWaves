using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RedSpace
{
    public static class MathRedSpace
    {
        public static int mod(int x, int m)
        {
            return (x % m + m) % m;
        }
    }
}
