using Abstractions;
using UnityEngine;

namespace Core
{
    public class MainBuilding : CommandExecutorBase<IProduceUnitCommand>, 
        ISelectable, IAttackable
    {
        [SerializeField] private GameObject _unitsPprefab;
        [SerializeField] private Transform _unitsParent;
        [SerializeField] private Transform _pivotPoint;
        [SerializeField] private float _maxHealth = 1000;
        [SerializeField] private Sprite _icon;

        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Transform PivotPoint => _pivotPoint;
        public Sprite Icon => _icon;

        private float _health = 1000;

        public override void ExecuteSpecificCommand(IProduceUnitCommand command)
        {
            Instantiate(command.UnitPrefab, new Vector3(Random.Range(-10, 10), 0,
                Random.Range(-10, 10)), Quaternion.identity, _unitsParent);
        }
    }
}

