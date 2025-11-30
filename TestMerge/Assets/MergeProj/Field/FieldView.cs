using System.Collections.Generic;
using UnityEngine;

namespace MergeProj.Field
{
    public class FieldView : MonoBehaviour
    {
        [SerializeField] private List<ObjectSlotView> objectSlotViewsList;

        private Dictionary<int, ObjectSlotView> _objectSlotViewsDict;
        private List<ObjectSlotView> _bufferObjectSlotViews = new List<ObjectSlotView>();

        private bool _isDictSet;

        public ObjectSlotView GetRandomAvailableObjectSlotView()
        {
            if (!_isDictSet)
            {
                SetDictionary();
            }
            
            _bufferObjectSlotViews.Clear();
            
            foreach (var slot in _objectSlotViewsDict)
            {
                if (slot.Value.IsAvailable)
                {
                    _bufferObjectSlotViews.Add(slot.Value);
                }
            }

            if (_bufferObjectSlotViews.Count == 0)
            {
                return null;
            }

            var randInt = Random.Range(0, _bufferObjectSlotViews.Count);

            return _bufferObjectSlotViews[randInt];
        }
        
        private void Start()
        {
            _objectSlotViewsDict = new Dictionary<int, ObjectSlotView>();
            
            if (!_isDictSet)
            {
                SetDictionary();
            }
        }

        private void SetDictionary()
        {
            if (objectSlotViewsList.Count != 0)
            {
                foreach (var slotView in objectSlotViewsList)
                {
                    _objectSlotViewsDict.Add(slotView.gameObject.GetInstanceID(), slotView);
                }

                _isDictSet = true;
            }
            else
            {
                Debug.Log("ObjectSlots on Field is empty");
            }
        }
    }
}