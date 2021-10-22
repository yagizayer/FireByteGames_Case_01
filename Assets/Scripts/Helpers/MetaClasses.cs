using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using System;

namespace YagizAYER
{
    namespace Helper
    {
        namespace MetaClasses
        {
            [Serializable]
            public class NavmeshMovementConfig
            {
                public Transform CurrentCamera => _currentCamera.transform;
                public float MoveSpeed => _moveSpeed;
                public float RotationSpeed => _rotationSpeed;
                public float SprintingSpeed => _sprintingSpeed;
                public float VerticalInput
                {
                    get => _verticalInput;
                    set
                    {
                        _verticalInput = value;
                        if (_verticalInput == 0 && _horizontalInput == 0) _isMoving = false;
                        else _isMoving = true;
                    }
                }
                public float HorizontalInput
                {
                    get => _horizontalInput; 
                    set
                    {
                        _horizontalInput = value;
                        if (_verticalInput == 0 && _horizontalInput == 0) _isMoving = false;
                        else _isMoving = true;
                    }
                }
                public bool IsSprinting { get => _isSprinting; set => _isSprinting = value; }
                public bool IsMoving => _isMoving;

                [SerializeField] private Camera _currentCamera;
                [SerializeField] private float _moveSpeed;
                [SerializeField] private float _rotationSpeed;
                [SerializeField] private float _sprintingSpeed;
                private float _verticalInput;
                private float _horizontalInput;
                private bool _isSprinting;
                private bool _isMoving;

                public NavmeshMovementConfig(float vertical, float horizontal, bool isSprinting, Camera currentCamera, float moveSpeed = 5, float rotationSpeed = 120, float sprintingSpeed = 10, bool isMoving = false)
                {
                    _currentCamera = currentCamera;
                    _moveSpeed = moveSpeed;
                    _rotationSpeed = rotationSpeed;
                    this._verticalInput = vertical;
                    this._horizontalInput = horizontal;
                    this._isSprinting = isSprinting;
                    _sprintingSpeed = sprintingSpeed;
                    _isMoving = isMoving;
                }
            }
        }
    }
}
