using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    public class CellGenerator : MonoBehaviour
    {
        [SerializeField] private Vector3Int _count;
        [SerializeField] private Vector3Int _cellSize;

        [SerializeField, Space(10)] private GameObject _prefab;
        [SerializeField] private Transform _container;

        [ContextMenu(nameof(Generate))]
        private void Generate()
        {
            Clear();

            int count = 0;

            for (int x = 0; x < _count.x; x++)
            {
                for (int z = 0; z < _count.z; z++)
                {
                    var position = new Vector3(x * _cellSize.x, 0, z * _cellSize.z);
                    var item = Instantiate(_prefab, position, Quaternion.identity, _container);

                    count++;
                    item.name = $"{item.name} {count.ToString()}";
                }
            }
        }

        [ContextMenu(nameof(Clear))]
        private void Clear()
        {
            if (_container.childCount > 0)
            {
                for (int i = 0; i < _container.childCount; i++)
                    DestroyImmediate(_container.GetChild(i).gameObject);
            }
        }
    }
}
