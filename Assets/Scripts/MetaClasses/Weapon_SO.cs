using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using YagizAYER.Helper;

namespace YagizAYER
{

    [CreateAssetMenu(fileName = "New Weapon_SO", menuName = "FireByteGames_Case_01/Weapon_SO", order = 10)]
    public class Weapon_SO : ScriptableObject
    {
        [Header("Weapon Variables")]
        [SerializeField] private WeaponType _weaponType = WeaponType.TwoDimensional;
        [SerializeField] private Sprite _defaultSprite;
        [SerializeField] private Color _defaultColor;
        [SerializeField, Range(.01f, 360f)] private float _speed = 15f;

        public WeaponType WeaponType => _weaponType;
        public Sprite DefaultSprite => _defaultSprite;
        public Color DefaultColor => _defaultColor;
        public float Speed => _speed;
    }
}
