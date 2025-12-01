using System;
using UnityEngine;
using Zenject;

namespace MergeProj.Input
{
    public class InputHandler : ITickable
    {
        public event Action MouseDownEvent;
        public event Action MouseUpEvent;
        
        public void Tick()
        {
            if (UnityEngine.Input.GetKey(KeyCode.Mouse0))
            {
                MouseDownEvent?.Invoke();
            }

            if (UnityEngine.Input.GetKeyUp(KeyCode.Mouse0))
            {
                MouseUpEvent?.Invoke();
            }
        }
    }
}