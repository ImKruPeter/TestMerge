using UnityEngine;

namespace MergeProj.Field
{
    public class ObjectSlotView : MonoBehaviour
    {
        public bool IsAvailable => _isAvailable;
        
        private bool _isAvailable = true;
        
        public void SetAvailable(bool isAvailable)
        {
            _isAvailable = isAvailable;
        }
    }
}