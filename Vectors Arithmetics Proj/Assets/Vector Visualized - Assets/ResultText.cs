using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roundbeargames
{
    public class ResultText : MonoBehaviour
    {
        Slate slate = null;
        TMPro.TextMeshPro textMeshPro = null;
        Vector2 currentVector = new Vector2();

        private void InitResultText()
        {
            Debug.Log("initializing ResultText");

            slate = this.gameObject.GetComponentInParent<Slate>();
            textMeshPro = this.gameObject.GetComponent<TMPro.TextMeshPro>();
            textMeshPro.text = "(0, 0)";
        }

        public void UpdateText(int index)
        {
            if (textMeshPro == null)
            {
                InitResultText();
            }
            else
            {
                currentVector = slate.GetVector(index);
                textMeshPro.text = currentVector.ToString();
            }
        }
    }
}