using MergeProj.MergeObjects;
using UnityEngine;

namespace MergeProj
{
    public class GameController
    {
        private static MergeController _mergeController;

        private static bool _isInitialized;

        public GameController(MergeController mergeController)
        {
            _mergeController = mergeController;
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void Init()
        {
            if (_isInitialized)
            {
                return;
            }

            _isInitialized = true;

            _mergeController.StartSpawnObjects();
        }
    }
}