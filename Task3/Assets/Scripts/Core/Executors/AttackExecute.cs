using Abstractions;
using UnityEngine;

namespace Core.Executors
{
    public class AttackExecute: CommandExecutorBase<IAttackCommand>
    { 
        public override void ExecuteSpecificCommand(IAttackCommand command)
        {
            Debug.Log("Attacking");
        }
    }
}