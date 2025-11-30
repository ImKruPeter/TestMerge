using System.Collections.Generic;
using MergeProj.Field;
using UnityEngine;

namespace MergeProj.MergeObjects
{
    public class MergeObjectFactory
    {
        private MergeObjectModels _mergeObjectModels;
        private FieldView _fieldView;
        private Dictionary<int, MergeObjectView> _mergeObjectViewsSpawned = new Dictionary<int, MergeObjectView>();
        
        private MergeObjectView _mergeObjectViewPrefab;
        private ObjectSlotView _bufferedObjectSlotView;

        public MergeObjectFactory(MergeObjectModels mergeObjectModels, FieldView fieldView)
        {
            _mergeObjectViewPrefab = Resources.Load<MergeObjectView>("MergeObjectView");
            _mergeObjectModels = mergeObjectModels;
            _fieldView = fieldView;
        }

        public void SpawnMergeObject(int objectLevel)
        {
            _bufferedObjectSlotView = _fieldView.GetRandomAvailableObjectSlotView();

            if (_bufferedObjectSlotView != null)
            {
                var mergeObjSpawned = Object.Instantiate(_mergeObjectViewPrefab, _bufferedObjectSlotView.transform);
                _mergeObjectViewsSpawned.Add(mergeObjSpawned.GetInstanceID(), mergeObjSpawned);
                
                _bufferedObjectSlotView.SetAvailable(false);

                var objectModel = _mergeObjectModels.GetMergeObjectModel(objectLevel);

                mergeObjSpawned.SetObjectLevel(objectLevel);
                mergeObjSpawned.ObjectSpriteRenderer.sprite = objectModel.Sprite;
            }
        }

        public MergeObjectView GetMergeObjectByInstanceID(int instanceID)
        {
            if (_mergeObjectViewsSpawned.ContainsKey(instanceID))
            {
                return _mergeObjectViewsSpawned[instanceID];
            }
            
            Debug.Log("InstanceID not found");
            return null;
        }

        public void DeleteMergeObjByInstanceID(int instanceID)
        {
            if (_mergeObjectViewsSpawned.ContainsKey(instanceID))
            {
                _mergeObjectViewsSpawned.Remove(instanceID);
            }
        }
    }
}