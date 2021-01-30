using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roundbeargames
{
    public class CharacterLine : MonoBehaviour
    {
        [SerializeField] GameObject targetStart = null;
        [SerializeField] GameObject targetEnd = null;

        LineRenderer lineRenderer = null;

        private void Start()
        {

            lineRenderer = this.gameObject.GetComponent<LineRenderer>();
        }

        private void Update()
        {
            if (targetEnd != null)
            {
                lineRenderer.SetPosition(0, this.transform.position + targetStart.transform.position);
                lineRenderer.SetPosition(1, this.transform.position + targetEnd.transform.position);
            }
        }
    }
}