using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedSpace
{
    public static class ColorTool
    {
        public static Color NewColorWithAlpha(Color old, float alpha = 0f)
        {
            return new Color(old.r, old.g, old.b, alpha);
        }
    }
}
