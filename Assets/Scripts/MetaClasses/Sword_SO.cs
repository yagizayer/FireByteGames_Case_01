using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using YagizAYER.Helper;

namespace YagizAYER
{

    [CreateAssetMenu(fileName = "New Sword_SO", menuName = "FireByteGames_Case_01/Sword_SO", order = 20)]
    public class Sword_SO : Weapon_SO
    {
        [Header("Sword Variables")]
        [SerializeField] private Vector2 _rotationRange = new Vector2(-30, 90);
        [SerializeField, Range(-360, 360)] private float _startAngle;


        public Vector2 RotationRange => _rotationRange;
        public float StartAngle => _startAngle;


        private void OnValidate()
        {
            if (_startAngle > _rotationRange.y) _startAngle = _rotationRange.y;
            if (_startAngle < _rotationRange.x) _startAngle = _rotationRange.x;
        }
    }
}
