using System;
using System.Threading;
using System.Threading.Tasks;
using MergeProj.Field;
using MergeProj.Input;
using UnityEngine;

namespace MergeProj.MergeObjects
{
    public class MergeController : IDisposable
    {
        private MergeObjectModels _mergeObjectModels;
        private MergeObjectFactory _mergeObjectFactory;
        private InputController _inputController;
        
        private CancellationTokenSource _spawnCancellationTokenSource;
        
        private float _spawnIntervalSec = 1f;
        
        public MergeController(
            MergeObjectModels mergeObjectModels,
            MergeObjectFactory mergeObjectFactory,
            InputController inputController)
        {
            _mergeObjectModels = mergeObjectModels;
            _mergeObjectFactory = mergeObjectFactory;
            _inputController = inputController;
        }
        
        public void StartSpawnObjects()
        {
            if (_spawnCancellationTokenSource != null)
            {
                Debug.Log("Spawn is already started");
                return;
            }
            
            _spawnCancellationTokenSource = new CancellationTokenSource();
            _ = RunSpawner(_spawnCancellationTokenSource.Token);
            
            _inputController.MergeEventInvoked += MergeObjects;
        }

        public void SpawnMergeObject()
        {
            _mergeObjectFactory.SpawnMergeObject(1);
        }
        
        public void StopSpawn()
        {
            _spawnCancellationTokenSource?.Cancel();
            _spawnCancellationTokenSource?.Dispose();
            _spawnCancellationTokenSource = null;
        }

        public void Dispose()
        {
            _spawnCancellationTokenSource?.Cancel();
            _spawnCancellationTokenSource?.Dispose();
            _spawnCancellationTokenSource = null;
        }
        
        private async Task RunSpawner(CancellationToken token)
        {
            try
            {
                await Task.Delay(TimeSpan.FromSeconds(_spawnIntervalSec), token);
                
                while (!token.IsCancellationRequested)
                {
                    SpawnMergeObject();
                    await Task.Delay(TimeSpan.FromSeconds(_spawnIntervalSec), token);
                }
            }
            catch (TaskCanceledException)
            { }
        }

        private void MergeObjects(MergeObjectView objectToMerge, MergeObjectView objectMergeIn)
        {
            if (objectToMerge.Level == objectMergeIn.Level)
            {
                objectToMerge.transform.parent.GetComponent<ObjectSlotView>().SetAvailable(true);
                objectToMerge.DestroyObject();
                objectMergeIn.LevelUp();
                objectMergeIn.ObjectSpriteRenderer.sprite = _mergeObjectModels.GetMergeObjectModel(objectMergeIn.Level).Sprite;
            }
        }
    }
}