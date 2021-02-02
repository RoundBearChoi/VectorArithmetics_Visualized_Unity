using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Roundbeargames
{
    public class ScalarValue : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField] Slider slider = null;
        [SerializeField] Text textSliderValue = null;
        [SerializeField] Text textLengthValue = null;

        VectorTimesScalar sceneData;

        private void Start()
        {
            sceneData = FindObjectOfType<VectorTimesScalar>();
        }

        private void Update()
        {
            textSliderValue.text = slider.value.ToString("F2");

            Vector2 resultVec = sceneData.GetSlate(1).GetVector(1);
            textLengthValue.text = Vector2.SqrMagnitude(resultVec).ToString("F2");
        }

        public float GetValue()
        {
            return slider.value;
        }
    }
}