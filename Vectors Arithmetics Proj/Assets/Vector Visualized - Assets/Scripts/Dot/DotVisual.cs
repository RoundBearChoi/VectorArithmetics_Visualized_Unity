using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roundbeargames
{
    public class DotVisual : MonoBehaviour
    {
        LineRenderer lineRenderer = null;

        private void Start()
        {
            lineRenderer = this.gameObject.GetComponentInChildren<LineRenderer>();
        }

        private void Update()
        {
            lineRenderer.SetPosition(1, this.transform.position);
        }
    }
}