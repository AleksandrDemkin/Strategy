using Abstractions;
using UnityEngine;

namespace Core.Executors
{
    public class PatrolExecute : CommandExecutorBase<IPatrolCommand>
    {
        public override void ExecuteSpecificCommand(IPatrolCommand command)
        {
            Debug.Log($"{name} is moving from {command.Target} to {command.Target1}!");
        }
    }
}