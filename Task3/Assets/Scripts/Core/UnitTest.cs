using Abstractions;
using UnityEngine;

namespace Core
{
    public class UnitTest : MonoBehaviour, ISelectable
    {
        [SerializeField] private float _maxHealth = 100;
        [SerializeField] private Sprite _icon;
        [SerializeField] private float _health = 100;

        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Transform PivotPoint { get; }
        public Sprite Icon => _icon;
    }
}