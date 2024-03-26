using System;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using Core.Interfaces;
using UniRx;
using UnityEngine;

namespace Systems
{
    public class CinemachineTargetGroupHandler : MonoBehaviour
    {
        [SerializeField] private CinemachineTargetGroup _targetGroup;
        
        
        private void Awake()
        {
            MessageBroker.Default.Receive<CameraTargetAddedtSignal>()
                .Subscribe(_ => AddTargetToGroup(_.Target)).AddTo(gameObject);
            
            MessageBroker.Default.Receive<CameraTargetRemovetSignal>()
                .Subscribe(_ => RemoveTargetFromGroup(_.Target)).AddTo(gameObject);
        }

        private void AddTargetToGroup(ITarget target)
        {
            _targetGroup.AddMember(target.Transform, 1.5f, 10);
        }
        private void RemoveTargetFromGroup(ITarget target)
        {
            _targetGroup.RemoveMember(target.Transform);
        }

    }
}