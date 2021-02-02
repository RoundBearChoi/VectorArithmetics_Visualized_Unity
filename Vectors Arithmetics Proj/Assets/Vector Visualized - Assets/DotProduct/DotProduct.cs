using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Roundbeargames
{
    public class DotProduct : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField] Text resultText = null;

        [Header("Debug")]
        [SerializeField] GameObject Cube1 = null;
        [SerializeField] GameObject Cube2 = null;
        [SerializeField] float dot = 0f;

        private void Update()
        {
            dot = Vector3.Dot(Cube1.transform.position, Cube2.transform.position);
            resultText.text = dot.ToString("F3");
        }
    }
}