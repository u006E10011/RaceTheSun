using UnityEngine;

namespace Project
{
    public class SimpleFilter : MonoBehaviour
    {
        [SerializeField] private Shader _shader;

        protected Material _material;

        private bool _useFilter = true;

        private void Awake() => _material = new(_shader);

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
                _useFilter = !_useFilter;

            OnUpdate();
        }

        protected virtual void OnUpdate() { }

        private void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            if(_useFilter)
                Graphics.Blit(source, destination, _material);
            else
                Graphics.Blit(source, destination);
        }
    }
}