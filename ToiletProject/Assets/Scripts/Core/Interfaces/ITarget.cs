using Systems;
using UnityEngine;

namespace Core.Interfaces
{
    public enum TargetEntity
    {
        Player,
        Enemy
    }
    
    public interface ITarget
    {
        public TargetEntity TargetEntity { get; }
        public Transform Transform { get; }
        public HealthSystem Health { get; }
    }
}