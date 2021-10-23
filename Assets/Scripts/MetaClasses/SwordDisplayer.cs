using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YagizAYER.Helper;

namespace YagizAYER
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Image))]
    public class SwordDisplayer : MonoBehaviour
    {
        [SerializeField] private Sword_SO _mySword;
        [SerializeField] private Slider _linkedSlider;

        private GameManager _gameManager;
        private Collider _myCollider;
        private Animator _myAnimator;
        private Image _myImage;

        private void Start()
        {
            Initialize();
        }
        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.CompareTag(transform.tag))
                _gameManager.EventManager.InvokeCollisionEnterEvent();
        }
        private void OnCollisionStay(Collision other)
        {
            if (other.transform.CompareTag(transform.tag))
                _gameManager.EventManager.InvokeCollisionEvent(other);
        }
        private void OnCollisionExit() => _gameManager.EventManager.InvokeCollisionExitEvent();

        [ContextMenu("Set Variables")]
        private void Initialize()
        {
            _gameManager = FindObjectOfType<GameManager>();
            _myCollider = GetComponent<Collider>();
            _myAnimator = GetComponent<Animator>();
            _myImage = GetComponent<Image>();

            _myImage.sprite = _mySword.DefaultSprite;
            _myImage.color = _mySword.DefaultColor;
            _myImage.preserveAspect = true;

            RotateSword(_mySword.StartAngle);

            _linkedSlider.maxValue = _mySword.RotationRange.y;
            _linkedSlider.minValue = _mySword.RotationRange.x;
            _linkedSlider.value = _mySword.StartAngle;
            _linkedSlider.onValueChanged.AddListener(RotateSword);
        }

        private void RotateSword(float targetAngle) => transform.rotation = Quaternion.Euler(Vector3.forward * targetAngle);


    }
}
