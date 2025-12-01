using UnityEngine;

namespace MergeProj.MergeObjects
{
    public class MergeObjectView : MonoBehaviour
    {
        public SpriteRenderer ObjectSpriteRenderer => objectSpriteRenderer;
        public Collider2D ObjectCollider2D => objectCollider2D;
        
        [SerializeField] private SpriteRenderer objectSpriteRenderer;
        [SerializeField] private Collider2D objectCollider2D;
        
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