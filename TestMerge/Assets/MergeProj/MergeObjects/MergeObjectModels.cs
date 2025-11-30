using System;
using System.Collections.Generic;
using UnityEngine;

namespace MergeProj.MergeObjects
{
    [CreateAssetMenu(menuName = "Models/MergeObjectModels")]
    public class MergeObjectModels : ScriptableObject
    {
        [SerializeField] private List<MergeObjectModel> mergeObjectModels;

        private Dictionary<int, MergeObjectModel> _mergeObjectModelsDict = new Dictionary<int, MergeObjectModel>();

        [NonSerialized] private bool _isSet;

        public MergeObjectModel GetMergeObjectModel(int objectLevel)
        {
            if (!_isSet)
            {
                SetDict();
            }
            
            if (_mergeObjectModelsDict.ContainsKey(objectLevel))
            {
                return _mergeObjectModelsDict[objectLevel];
            }

            return new MergeObjectModel();
        }

        private void SetDict()
        {
            if (mergeObjectModels.Count != 0)
            {
                for (int i = 0; i < mergeObjectModels.Count; i++)
                {
                    _mergeObjectModelsDict.Add(mergeObjectModels[i].Level, mergeObjectModels[i]);
                }
            }

            _isSet = true;
        }
    }

    [Serializable]
    public struct MergeObjectModel
    {
        public int Level;
        public Sprite Sprite;
    }
}