using System;
using Abstractions;
using UnityEngine;
using Utils.AssetsInjector;
using Zenject;

namespace UserControlSystem.Model.CommandCreators
{
    public class ProduceUnitCommandCreator :
        CommandCreatorBase<IProduceUnitCommand>
    { 
        [Inject] private AssetsContext _context;
        private GameObject _gameObject;
        protected override void ClassSpecificCommandCreation(Action<IProduceUnitCommand> 
            creationCallback)
        {
            creationCallback?.Invoke(_context.Inject(new 
                ProduceUnitCommandHeir(_gameObject)));
        }
    }
}