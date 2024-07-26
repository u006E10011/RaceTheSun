using System.Collections.Generic;
using UnityEngine;

namespace Project.Tools
{
    public static class RandomTransform
    {
        public static void Rotate(List<GameObject> item)
        {
            foreach (var obj in item)
            {
                var rotate = Random.Range(0, 360);
                obj.transform.rotation = Quaternion.Euler(0, rotate, 0);
            }
        }

        public static void Scale(List<GameObject> item, float maxScale, float minScale)
        {
            foreach (var obj in item)
            {
                var scale = Random.Range(minScale, maxScale);
                obj.transform.localScale = new Vector3(scale, scale, scale);
            }
        }
    }

}