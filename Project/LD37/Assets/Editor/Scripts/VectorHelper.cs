using UnityEngine;

namespace Assets.Editor.Scripts
{
    public static class VectorHelper
    {
        public static Vector3 Lerp(Vector3 vector1, Vector3 vector2, float delta)
        {
            return new Vector3(Mathf.Lerp(vector1.x, vector2.x, delta),
                Mathf.Lerp(vector1.y, vector2.y, delta),
                Mathf.Lerp(vector1.z, vector2.z, delta));
        }

        public static Vector2 Clamp(Vector2 vector, Vector2 min, Vector2 max)
        {
            return new Vector2(Mathf.Clamp(vector.x, min.x, max.x), Mathf.Clamp(vector.y, min.y, max.y));
        }

        public static Vector2 Ceil(Vector2 vector)
        {
            return new Vector2(Mathf.Ceil(vector.x), Mathf.Ceil(vector.y));
        }
    }
}
