using UnityEngine;

namespace MergeProj.MergeObjects
{
    public abstract class MergeObject : MonoBehaviour
    {
        public int Level => _level;

        private int _level;
        
        public virtual void LevelUp()
        {
            _level++;
        }

        public void DestroyObject()
        {
            Destroy(gameObject);
        }
    }
}