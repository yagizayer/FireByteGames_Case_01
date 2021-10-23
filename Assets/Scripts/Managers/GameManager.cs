using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using YagizAYER.Helper;

namespace YagizAYER
{
    public class GameManager : MonoBehaviour
    {

        [SerializeField] private GameObject _collisionParticles;
        [SerializeField] private Transform _background;

        public EventManager EventManager => _eventManager;


        private SoundManager _soundManager;
        private EventManager _eventManager;
        private Functions _helperFunctions;

        private void Start() => Initialize();

        private void Initialize()
        {
            _eventManager = FindObjectOfType<EventManager>();
            _soundManager = FindObjectOfType<SoundManager>();
            _helperFunctions = GetComponent<Functions>() ?? gameObject.AddComponent<Functions>();
        }

        public void SpawnParticles(Collision other)
        {
            if (!_collisionParticles.activeSelf)
                _collisionParticles.SetActive(true);
            _collisionParticles.transform.position = other.contacts[0].point;
        }
        public void DeactivateParticles() => _collisionParticles.SetActive(false);

        public void ShakeCamera() => _helperFunctions.Shake(_background, .3f, 20);
    }
}
