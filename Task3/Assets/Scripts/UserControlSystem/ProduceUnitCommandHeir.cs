using Abstractions;
using UnityEngine;

namespace UserControlSystem
{
    public class ProduceUnitCommandHeir : ProduceUnitCommand, IProduceUnitCommand
    {
        public ProduceUnitCommandHeir(GameObject unitPrefab) : base(unitPrefab)
        {
        }
    }
}