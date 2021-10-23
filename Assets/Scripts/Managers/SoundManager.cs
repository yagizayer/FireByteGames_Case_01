using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YagizAYER.Helper;

namespace YagizAYER
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : MonoBehaviour
    {

        [SerializeField] private AudioClip _collisionStartAudio;
        [SerializeField] private AudioClip _collisionStayAudio;
        private GameManager _gameManager;
        private AudioSource _myAudioSource;

        private void Start()
        {
            _gameManager = FindObjectOfType<GameManager>();
            _myAudioSource = GetComponent<AudioSource>() ?? gameObject.AddComponent<AudioSource>();
            _myAudioSource.playOnAwake = false;
        }

        public void CollisionEnterAudio()
        {
            _myAudioSource.loop = false;
            _myAudioSource.clip = _collisionStartAudio;
            _myAudioSource.Play();
			CollisionStayAudio();
        }
        private void CollisionStayAudio() => StartCoroutine(StartingCollisionStayAudio());
        public void StopAudio(){
			_myAudioSource.loop = false;
			_myAudioSource.Stop();
		}
        private IEnumerator StartingCollisionStayAudio()
        {
            yield return new WaitForSeconds(_collisionStartAudio.length);

            _myAudioSource.loop = true;
            _myAudioSource.clip = _collisionStayAudio;
            _myAudioSource.Play();
        }
    }
}
