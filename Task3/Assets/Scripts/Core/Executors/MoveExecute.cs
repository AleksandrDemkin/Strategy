using Abstractions;
using UnityEngine;

namespace Core.Executors
{
    public class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
    {
        private CommandExecutorBase<IMoveCommand> _commandExecutorBaseImplementation;

        public override void ExecuteSpecificCommand(IMoveCommand command)
        {
            Debug.Log($"{name} is moving to {command.Target}!");
        }
    }
}