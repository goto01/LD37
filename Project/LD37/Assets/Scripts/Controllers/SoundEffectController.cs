using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class SoundEffectController : BaseController
    {
        public enum Sound
        {
            BulletDestroy,
            Shoot,
            Explosion,
            Blackhole,
            FlyAbility,
            TailAbility,
            Slowmo,
            Ricochet,
            HeroDamaged,
        }

        [Serializable]
        class SoundInfo
        {
            [SerializeField] private Sound _sound;
            [SerializeField] private AudioClip _audio;

            public Sound Sound{get {return _sound;} }
            public AudioClip Audio { get { return _audio;} }
        }

        #region Fields

        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private List<SoundInfo> _sounds;

        private Dictionary<Sound, AudioClip> _soundsDictionary;

        #endregion

        #region Unity events

        protected virtual void Awake()
        {
            _soundsDictionary = new Dictionary<Sound, AudioClip>();
            _sounds.ForEach(x=>_soundsDictionary.Add(x.Sound, x.Audio));
        }

        #endregion

        #region Public methods

        public void PlaySound(Sound sound)
        {
            _audioSource.PlayOneShot(_soundsDictionary[sound]);
        }

        #endregion
    }
}
