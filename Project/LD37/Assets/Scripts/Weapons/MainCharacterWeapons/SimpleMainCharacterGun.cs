﻿using System.Collections;
using Assets.Scripts.Controllers;
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
        [Space]
        [Space]
        [SerializeField] private bool _isInfinite;
        [SerializeField] private int _totalBullets;
        [SerializeField] [Range(.1f, 1f)] private float _maxDistanceOfBullets;
        [SerializeField] [Range(10, 100)] private int _bulletInc;

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

        public bool IsBulletsInHolderRanOut { get { return _currentBulletsInHolder <= 0; } }

        public int TotalBullet { get
        {
            if (_isInfinite) _totalBullets = 999-_currentBulletsInHolder;
            return _totalBullets;
        } }

        public int TotalBulletWithInHolder { get { return _totalBullets + _currentBulletsInHolder; } }

        public int CurentBulletsInHolder { get { return _currentBulletsInHolder; } }

        public int BulletsInHolder { get { return _bulletsInHolder; } }

        public bool IsBulletsRanOut { get { return _totalBullets <= 0; } }

        public bool Reloaded { get { return _reloading; } }

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

        protected override void FixedUpdate()
        {
            if (_isInfinite) _totalBullets = 999 - _currentBulletsInHolder;
            base.FixedUpdate();
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

        #region Public methods

        public void IncBullets()
        {
            _totalBullets += _bulletInc;
        }

        #endregion

        #region Overrided methods


        protected override void MakeShot(float maxDistance, float angle)
        {
            if (IsBulletsRanOut && IsBulletsInHolderRanOut) return;
            _lastShotTimeStamp = Time.time;
            for (var index = 0; index < _bulletPerShot; index++)
            {
                _currentBulletsInHolder--;
                _soundEffectController.PlaySound(SoundEffectController.Sound.Shoot);
                base.MakeShot(_maxDistanceOfBullets, RandomAngle);
            }
            if (IsBulletsInHolderRanOut) StartCoroutine(Reload());
        }

        #endregion

        #region Private methods

        private void ResetBullets()
        {
            if (_totalBullets <= _bulletsInHolder)
            {
                _currentBulletsInHolder = _totalBullets;
                _totalBullets = 0;
            }
            else
            {
                _currentBulletsInHolder = _bulletsInHolder;
                _totalBullets -= _bulletsInHolder;
            }
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
