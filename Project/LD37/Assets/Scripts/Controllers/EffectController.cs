using System.Collections;
using System.Linq;
using Assets.Scripts.Core.Pull;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class EffectController : BaseController
    {
        #region Fields
        
        [SerializeField] private PortablePool _sparksPool;
        [SerializeField] private AnimationCurve _animationCurve;
        [SerializeField] private PortablePool _boomsPool;
        [SerializeField] private PortablePool _blackHolesPool;
        [Space]
        [SerializeField] private bool _recochet;
        [SerializeField] private int _recochetNumber;

        private Vector3 _cameraPos;

        private IEnumerator _coroutine;

        #endregion

        #region Unity events

        protected virtual void Awake()
        {
            _cameraPos = Camera.main.transform.position;
        }

        #endregion

        #region Public methods

        public void MakeSparks(Vector2 respPos)
        {
            var @object = _sparksPool.PopObject();
            var pos = @object.transform.position;
            pos.x = respPos.x;
            pos.y = respPos.y;
            @object.transform.position = pos;
        }

        public void Shake()
        {
            if (_coroutine!= null) StopCoroutine(_coroutine);
            Camera.main.transform.position = _cameraPos;
            _coroutine = ShakeCoroutine();
            StartCoroutine(_coroutine);
        }

        public void MakeBoom(Vector2 pos)
        {
            var boom = _boomsPool.PopObject();
            Vector3 newPos = pos;
            newPos.z = boom.transform.position.z;
            boom.transform.position = newPos;
        }

        public void MakeBlackHole(Vector2 pos)
        {
            var blackHole = _blackHolesPool.PopObject();
            Vector3 newPos = pos;
            newPos.z = blackHole.transform.position.z;
            blackHole.transform.position = newPos;
        }

        public bool Recochet { get { return _recochet; }set { _recochet = value; } }

        public int RecochetNumber { get { return _recochetNumber; } }

        #endregion

        #region Private methods

        private IEnumerator ShakeCoroutine()
        {
            var timeStamp = 0f;
            var endTime = _animationCurve.keys.Last().time;
            var cameraPos = Camera.main.transform.position;
            while (timeStamp < endTime)
            {
                var newCameraPos = cameraPos;
                Camera.main.transform.position = cameraPos;
                var value = _animationCurve.Evaluate(timeStamp);
                newCameraPos.x += Random.Range(-value, value);
                newCameraPos.y += Random.Range(-value, value);
                Camera.main.transform.position = newCameraPos;
                timeStamp += Time.deltaTime;
                yield return new WaitForSeconds(Time.deltaTime);
            }
            Camera.main.transform.position = _cameraPos;
        }

        #endregion
    }
}
