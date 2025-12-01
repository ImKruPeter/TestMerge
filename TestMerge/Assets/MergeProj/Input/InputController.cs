using System;
using MergeProj.Camera;
using MergeProj.MergeObjects;
using UnityEngine;
using Zenject;

namespace MergeProj.Input
{
    public class InputController : ITickable
    {
        public event Action<MergeObjectView, MergeObjectView> MergeEventInvoked;
        
        private InputHandler _inputHandler;
        private UnityEngine.Camera _mainCamera;
        
        private MergeObjectView _mergeObject;
        
        private bool _isMergeObjectFound;
        
        private Vector3 _bufferVector3;
        private Vector3 _startVector3;
        
        public InputController(InputHandler inputHandler, CameraView cameraView)
        {
            _inputHandler = inputHandler;
            _mainCamera = cameraView.Camera;
            
            _inputHandler.MouseDownEvent += PickMergeObject;
            _inputHandler.MouseUpEvent += PutMergeObject;
        }
        
        public void Tick()
        {
            if (_isMergeObjectFound)
            {
                _bufferVector3.x = _mainCamera.ScreenToWorldPoint(UnityEngine.Input.mousePosition).x;
                _bufferVector3.y = _mainCamera.ScreenToWorldPoint(UnityEngine.Input.mousePosition).y;
                
                _mergeObject.transform.position = _bufferVector3;
            }
        }
        
        private void PickMergeObject()
        {
            if (!_isMergeObjectFound)
            {
                Vector2 worldPoint = _mainCamera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
                
                RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
                
                if (hit)
                {
                    _mergeObject = hit.collider.gameObject.GetComponent<MergeObjectView>();
                    if (_mergeObject.Level == 10)
                    {
                        return;
                    }
                    _startVector3 = hit.transform.position;
                    _mergeObject.ObjectSpriteRenderer.sortingOrder = 3;
                    _mergeObject.ObjectCollider2D.enabled = false;
                    _isMergeObjectFound = true;
                }
            }
        }

        private void PutMergeObject()
        {
            if (_isMergeObjectFound)
            {
                Vector2 worldPoint = _mainCamera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
                
                RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
                
                if (hit)
                {
                    MergeEventInvoked?.Invoke(_mergeObject, hit.collider.gameObject.GetComponent<MergeObjectView>());
                }
                
                if (_mergeObject)
                {
                    _mergeObject.ObjectSpriteRenderer.sortingOrder = 2;
                    _mergeObject.transform.position = _startVector3;
                    _mergeObject.ObjectCollider2D.enabled = true;
                }
                
                _mergeObject = null;
                _isMergeObjectFound = false;
            }
        }
    }
}