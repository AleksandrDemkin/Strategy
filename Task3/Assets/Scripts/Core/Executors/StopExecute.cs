using Abstractions;
using UnityEngine;

namespace Core.Executors
{
    public class StopExecute : CommandExecutorBase<IStopCommand>
    {
        public override void ExecuteSpecificCommand(IStopCommand command)
        {
            Debug.Log("Stopped");
        }
    }
}