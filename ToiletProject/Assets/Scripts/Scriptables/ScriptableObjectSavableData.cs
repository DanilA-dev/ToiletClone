using Systems;
using UnityEngine;
using Zenject;

namespace Scriptables
{
    public abstract class ScriptableObjectSavableData : ScriptableObject
    {
        private SaveDataController _saveDataController;

        [Inject]
        private void Construct(SaveDataController saveDataController)
        {
            _saveDataController = saveDataController;
        }

        
        

    }
}