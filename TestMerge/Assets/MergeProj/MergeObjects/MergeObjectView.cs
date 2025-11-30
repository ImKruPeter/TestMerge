using UnityEngine;

namespace MergeProj.MergeObjects
{
    public class MergeObjectView : MonoBehaviour
    {
        public SpriteRenderer ObjectSpriteRenderer => objectSpriteRenderer;
        
        [SerializeField] private SpriteRenderer objectSpriteRenderer;
        
        public int Level => _level;

        private int _level;
        
        public void LevelUp()
        {
            _level++;
        }

        public void SetObjectLevel(int objectLevel)
        {
            _level = objectLevel;
        }

        public void DestroyObject()
        {
            Destroy(gameObject);
        }
    }
}