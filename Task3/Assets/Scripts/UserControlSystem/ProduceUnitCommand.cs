using System;
using Abstractions;
using UnityEngine;
using UserControlSystem.Model.CommandCreators;
using Utils.AssetsInjector;

namespace UserControlSystem
{
    public class ProduceUnitCommand : CommandCreatorBase<IProduceUnitCommand>
    {
        public GameObject UnitPrefab => _unitPrefab;
        [InjectAsset("Chomper")] private GameObject _unitPrefab;

        public ProduceUnitCommand(GameObject unitPrefab)
        {
            _unitPrefab = unitPrefab;
        }

        protected override void ClassSpecificCommandCreation(Action<IProduceUnitCommand> creationCallback)
        {
            throw new NotImplementedException();
        }
    }
}