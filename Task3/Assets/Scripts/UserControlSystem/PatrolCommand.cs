using Abstractions;
using UnityEngine;

namespace UserControlSystem
{
    public class PatrolCommand : IPatrolCommand
    {
		public Vector3 Target { get; }
		public Vector3 Target1 { get; }
		
		public PatrolCommand(Vector3 target, Vector3 target1)
		{
			Target = target;
			Target1 = target1;
		}
    }
}