using System;
using Abstractions;
using UnityEngine;
using Utils.AssetsInjector;
using Zenject;

namespace UserControlSystem.Model.CommandCreators
{
    public class AttackCommandCreator : CommandCreatorBase<IAttackCommand>
    {
        [Inject] private AssetsContext _context;
        
        private Action<IAttackCommand> _creationCallback;
        
        [Inject]
        private void Init(AttackableValue groundClicks)
        {
            groundClicks.OnAttacked += OnAttacked;
        }
        
        private void OnAttacked(IAttackable attackable)
        {
            _creationCallback?.Invoke(_context.Inject(new AttackCommand(attackable)));
            _creationCallback = null;
        }
        protected override void ClassSpecificCommandCreation(Action<IAttackCommand> creationCallback)
        {
            _creationCallback = creationCallback;
        }
        
        public override void ProcessCancel()
        {
            base.ProcessCancel();
            _creationCallback = null;
        }
    }
}