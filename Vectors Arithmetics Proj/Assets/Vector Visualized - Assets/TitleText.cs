using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roundbeargames
{
    public class TitleText : MonoBehaviour
    {
        TMPro.TextMeshPro textMeshPro = null;

        public void SetTitle(string str)
        {
            if (textMeshPro == null)
            {
                textMeshPro = this.gameObject.GetComponent<TMPro.TextMeshPro>();
            }

            textMeshPro.text = str;
        }
    }
}