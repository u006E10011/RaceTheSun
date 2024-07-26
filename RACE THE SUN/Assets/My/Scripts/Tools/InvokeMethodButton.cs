using System;
using System.Collections.Generic;

namespace Project
{
    [Serializable]
    public class InvokeMethodButton
    {
        public bool IsGenerate;
        public bool IsScale;
        public bool IsRotate;

        public void Invoke(List<Action> methods)
        {
            for (int i = 0; i < methods.Count; i++) 
                methods[i]?.Invoke();
        }
        
    }
}