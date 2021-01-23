using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roundbeargames
{
    public class ResultText : MonoBehaviour
    {
        VectorPlane vectorPlane = null;
        TMPro.TextMeshPro textMeshPro = null;

        void Start()
        {
            vectorPlane = this.gameObject.GetComponentInParent<VectorPlane>();

            textMeshPro = this.gameObject.GetComponent<TMPro.TextMeshPro>();
            textMeshPro.text = "(0, 0)";
        }

        public void UpdateText()
        {
            if (textMeshPro != null)
            {
                textMeshPro.text = vectorPlane.GetVector().ToString();
            }
        }
    }
}