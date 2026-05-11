using System;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Smart Data/VariableSO", fileName = "VariableSO")]
    public class VariableSO<T> : ScriptableObject
    {
        [SerializeField] private T m_DefaultValue;
        protected T CurrentValue;
        public T Value => CurrentValue;
        public event Action ValueChangedEvent;
    
        public virtual void Initialize()
        {
            CurrentValue = m_DefaultValue;
            ValueChangedEvent?.Invoke();
        }

        public virtual void SetValue(T value)
        {
            CurrentValue = value;
            ValueChangedEvent?.Invoke();
        }
    }
}
