using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roundbeargames
{
    public class ResultText : MonoBehaviour
    {
        Slate slate = null;
        TMPro.TextMeshPro textMeshPro = null;

        private void InitTextField()
        {
            slate = this.gameObject.GetComponentInParent<Slate>();
            textMeshPro = this.gameObject.GetComponent<TMPro.TextMeshPro>();
            textMeshPro.text = "(0, 0)";
        }

        public void UpdateText(int index)
        {
            if (textMeshPro == null)
            {
                InitTextField();
            }
            else
            {
                textMeshPro.text = slate.GetVector(index).ToString();
            }
        }
    }
}