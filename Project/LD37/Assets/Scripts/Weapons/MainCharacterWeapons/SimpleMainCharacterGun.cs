using System.Collections;
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
        [SerializeField] [Range(1, 10)] private int _bulletPerShot;
        [Space]
        [Space]
        [SerializeField] [Range(1, 40)] private int _bulletsInHolder;
        [SerializeField] [Range(1, 40)] private int _currentBulletsInHolder;
        [SerializeField] [Range(0, 5)] private int _reloadingTime;
        [SerializeField] private bool _reloading;

        private float _lastShotTimeStamp;

        #endregion

        #region Properties

        private bool IsTime { get { return Time.time - _lastShotTimeStamp > _shotDelay; } }

        protected override bool IsShotTime
        {
            get
            {
                return !_reloading && IsTime && _movementController.CheckShootEvent();
            }
        }

        private float RandomAngle { get { return Random.Range(-_angleOfFire, _angleOfFire); } }

        private bool IsBulletsRanOut { get { return _currentBulletsInHolder == 0; } }

        #endregion

        #region Unity events

        protected virtual void OnEnable()
        {
            if (_reloading) StartCoroutine(Reload());
        }

        protected virtual void Start()
        {
            ResetBullets();
        }

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
            _currentBulletsInHolder--;
            _lastShotTimeStamp = Time.time;
            base.MakeShot(RandomAngle);
            if (IsBulletsRanOut) StartCoroutine(Reload());
        }

        #endregion

        #region Private methods

        private void ResetBullets()
        {
            _currentBulletsInHolder = _bulletsInHolder;
        }

        private IEnumerator Reload()
        {
            _reloading = true;
            yield return new WaitForSeconds(_reloadingTime);
            _reloading = false;
            ResetBullets();
        }
        
        #endregion
    }
}
