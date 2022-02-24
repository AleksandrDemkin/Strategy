using System;
using Abstractions;
using UnityEngine;

namespace UserControlSystem.Model
{
    [CreateAssetMenu(fileName = nameof(AttackableValue), menuName = "Strategy Game/" + nameof(AttackableValue), order = 0)]
    public class AttackableValue : ScriptableObject
    {
        public IAttackable CurrentValue { get; private set; }
        public event Action<IAttackable> OnAttacked;

        public void SetValue(IAttackable value)
        {
            CurrentValue = value;
            OnAttacked?.Invoke(value);
        }
    }
}

