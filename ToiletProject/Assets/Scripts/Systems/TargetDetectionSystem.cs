using Core.Interfaces;
using UnityEngine;

namespace Systems
{
    [System.Serializable]
    public class TargetDetectionSystem
    {
        [SerializeField] private TargetEntity _targetToTrack;
        [SerializeField] private Transform _baseTransform;
        [SerializeField] private float _radiusCheck;

        public bool TryFindTarget(out ITarget newTarget)
        {
            Collider[] colls = Physics.OverlapSphere(_baseTransform.position, _radiusCheck);
            if (colls.Length <= 0)
            {
                newTarget = null;
                return false;
            }

            foreach (var coll in colls)
            {
                if (coll.TryGetComponent(out ITarget target))
                {
                    if (_targetToTrack == target.TargetEntity && !target.Health.IsDead)
                    {
                        newTarget = target;
                        return true;
                    }
                }
            }

            newTarget = null;
            return false;
        }
        

        public void DrawGizmos()
        {
            if(_baseTransform == null)
                return;
            
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_baseTransform.position, _radiusCheck);
        }
        
    }
}