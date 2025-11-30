using System;
using MergeProj.Camera;
using UnityEngine;
using Zenject;

namespace MergeProj.Input
{
    public class InputController : ITickable
    {
        private InputHandler _inputHandler;
        private UnityEngine.Camera _mainCamera;
        private GameObject _mergeObject;

        private Vector3 _bufferVector3;
        
        public InputController(InputHandler inputHandler, CameraView cameraView)
        {
            _inputHandler = inputHandler;
            _mainCamera = cameraView.Camera;

            _inputHandler.MouseDownEvent += PickMergeObject;
            _inputHandler.MouseUpEvent += PutMergeObject;
        }
        
        public void Tick()
        {
            if (_mergeObject)
            {
                _bufferVector3 = UnityEngine.Input.mousePosition;

                _mergeObject.transform.position = _bufferVector3;
            }
        }
        
        private void PickMergeObject()
        {
            if (!_mergeObject)
            {
                Vector2 worldPoint = _mainCamera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);

                RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
                
                if (hit)
                {
                    Debug.Log(hit.collider.gameObject.name);
                    _mergeObject = hit.collider.gameObject;
                }
            }
        }

        private void PutMergeObject()
        {
            if (_mergeObject)
            {
                _mergeObject = null;
            }
        }
    }
}