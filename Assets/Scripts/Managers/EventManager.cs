using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using YagizAYER.Helper;

namespace YagizAYER
{
    public class EventManager : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField] private UnityEvent<Collision> _collisionEvent = new UnityEvent<Collision>();
        [SerializeField] private UnityEvent _collisionEnterEvent = new UnityEvent();
        [SerializeField] private UnityEvent _collisionExitEvent = new UnityEvent();

        internal void InvokeCollisionEnterEvent() => _collisionEnterEvent.Invoke();
        internal void InvokeCollisionEvent(Collision other) => _collisionEvent.Invoke(other);
        internal void InvokeCollisionExitEvent() => _collisionExitEvent.Invoke();

    }
}
