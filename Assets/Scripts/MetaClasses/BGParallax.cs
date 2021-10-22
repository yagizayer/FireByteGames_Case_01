using System;
using System.Collections.Generic;
using UnityEngine;
using YagizAYER.Helper;

namespace YagizAYER
{
    public class BGParallax : MonoBehaviour
    {
        private RectTransform _myTransform;
        private Vector2 _screenDiff = new Vector2(Screen.width / 10, Screen.height / 10);
        private Vector2 _targetPos = new Vector2();

        private void Start() => _myTransform = GetComponent<RectTransform>();
        private void Update()
        {
            Vector2 mousePos = Input.mousePosition;

            if ((mousePos.x < Screen.width && mousePos.x >= 0) && (mousePos.y < Screen.height && mousePos.y >= 0))
                MakeParallaxEffect(mousePos);
        }

        private void MakeParallaxEffect(Vector2 mousePos)
        {
            _targetPos.x = mousePos.x.Remap(0, Screen.width, -_screenDiff.x, _screenDiff.x);
            _targetPos.y = mousePos.y.Remap(0, Screen.height, -_screenDiff.y, _screenDiff.y);
            _myTransform.anchoredPosition = _targetPos;
        }
    }
}
