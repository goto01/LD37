using UnityEngine;

namespace Assets.Scripts.Core.Depended
{
    class MouseRotatedComponent : CustomMonoBehaviour
    {
        [SerializeField] private Camera _camera;

        protected virtual void Update()
        {
            var way = (Vector2)_camera.ScreenToWorldPoint(Input.mousePosition) - (Vector2) transform.position;
            float angle = Mathf.Atan2(way.y, way.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
