using UnityEngine;

namespace Project
{
    public class InputPlayer : MonoBehaviour
    {
        [SerializeField] private bool Mobile;

        public static IInput Input { get; private set; }
        public static bool IsAndroid { get; private set; }

        private void Start()
        {
            if (!Mobile)
            {
                if (Application.platform == RuntimePlatform.Android)
                    Android();
                else
                    Desktop();
            }
            else
                Android();
        }

        private void Android()
        {
            Input = new InputMobile();
            IsAndroid = true;
        }

        private void Desktop()
        {
            Input = new InputDesktop();
            IsAndroid = false;
        }
    }
}