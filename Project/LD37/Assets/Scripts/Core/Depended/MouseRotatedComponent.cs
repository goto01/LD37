using UnityEngine;

namespace Assets.Scripts.Core.Depended
{
    class MouseRotatedComponent : CustomMonoBehaviour
    {
        protected virtual void Update()
        {
            var way = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2) transform.position;
            Debug.DrawLine((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.one);
            float angle = Mathf.Atan2(way.y, way.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
