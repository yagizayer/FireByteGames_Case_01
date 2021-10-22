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

        public EventManager EventManager => _eventManager;


        private EventManager _eventManager;

        private void Start() => Initialize();

        private void Initialize() => _eventManager = FindObjectOfType<EventManager>();

        public void SpawnParticles(Collision other)
        {
            if (!_collisionParticles.activeSelf)
                _collisionParticles.SetActive(true);
            _collisionParticles.transform.position = other.contacts[0].point;
        }
        public void DeactivateParticles() => _collisionParticles.SetActive(false);
    }
}
