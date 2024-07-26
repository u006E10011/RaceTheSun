using UnityEngine;

namespace Project
{
    public class InputMobile : IInput
    {
        public Side Value { get; set; }

        public float Direction()
        {
            if (Input.mousePosition.x < Screen.width / 2)
                Value = Side.Left;
            else
                Value = Side.Right;

            Debug.Log($"{this} value: {Normalize()}");
            return Normalize();

        }

        private float Normalize()
        {
            float width = Screen.width / 2;
            float segmentCount = 10;
            float segmentLenght = width / segmentCount;

            float input = Input.mousePosition.x - width;

            return Value switch
            {
                Side.Right => (input / segmentLenght) / 10,
                Side.Left => (Mathf.Abs(input) / segmentLenght) / 10,
                _ => 0
            };
        }
    }
}