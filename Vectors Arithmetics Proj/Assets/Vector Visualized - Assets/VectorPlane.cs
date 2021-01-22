using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roundbeargames
{
    public class VectorPlane : MonoBehaviour
    {
        [SerializeField] GameObject VectorLinePrefab = null;
        [SerializeField] GameObject MousePositionPrefab = null;
        [SerializeField] GameObject VectorMoverPrefab = null;

        private void Start()
        {
            Instantiate(VectorLinePrefab, this.transform);
            Instantiate(MousePositionPrefab, this.transform);
            Instantiate(VectorMoverPrefab, this.transform);
        }
    }
}