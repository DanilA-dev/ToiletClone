using Systems;
using UnityEngine;

namespace Core.Interfaces
{
    public interface ITarget
    {
        public Transform Transform { get; }
        public HealthSystem Health { get; }
    }
}