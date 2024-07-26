using System;

namespace Project
{
    [Serializable]
    public class PlayerConfiguration
    {
        public float LimitTurn = 15f;
        public float Smoothing = 5;
        public float SmoothingToDefaultRotation = 10;

        public float LimitY = 2;
    }

}