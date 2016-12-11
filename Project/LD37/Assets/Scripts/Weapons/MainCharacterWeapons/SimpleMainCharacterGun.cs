using UnityEngine;

namespace Assets.Scripts.Weapons.MainCharacterWeapons
{
    class SimpleMainCharacterGun : BaseWeapon
    {
        #region Fields

        [Space]
        [Space]
        [SerializeField] [Range(.001f, 1)] private float _shotDelay;
        [SerializeField] [Range(0, 10)] private float _angleOfFire;

        private float _lastShotTimeStamp;

        #endregion

        #region Properties

        private bool IsTime { get { return Time.time - _lastShotTimeStamp > _shotDelay; } }

        protected override bool IsShotTime
        {
            get
            {
                return IsTime && _movementController.CheckShootEvent();
            }
        }

        private float RandomAngle { get { return Random.Range(-_angleOfFire, _angleOfFire); } }

        #endregion

        #region Unity events

#if UNITY_EDITOR

        protected virtual void OnDrawGizmos()
        {
            Gizmos.DrawLine(transform.position, transform.position + Vector3.right*10);
            Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, 0, _angleOfFire)*Vector3.right*10);
            Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, 0, -_angleOfFire)*Vector3.right*10);
        }

#endif

        #endregion

        #region Overrided methods

        protected override void MakeShot(float angle)
        {
            _lastShotTimeStamp = Time.time;
            base.MakeShot(RandomAngle);
        }

        #endregion
    }
}
