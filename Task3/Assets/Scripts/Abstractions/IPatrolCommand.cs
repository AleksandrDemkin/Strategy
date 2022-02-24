using UnityEngine;

namespace Abstractions
{
    public interface IPatrolCommand : ICommand
    {
        public Vector3 Target { get; }
		public Vector3 Target1 { get; }
    }
}