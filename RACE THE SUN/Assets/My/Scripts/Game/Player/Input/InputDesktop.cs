using UnityEngine;

namespace Project
{
    public class InputDesktop : IInput
    {
        public Side Value { get; set; }

        private const string HORIZONTAL = "Horizontal";

        public float Direction()
        {
            var direction = Input.GetAxis(HORIZONTAL);

            if (direction > 0)
                Value = Side.Right;
            else
                Value = Side.Left;

            return Mathf.Abs(direction);
        }
    }
}