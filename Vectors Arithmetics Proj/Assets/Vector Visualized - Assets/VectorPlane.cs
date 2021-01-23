using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roundbeargames
{
    public class VectorPlane : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField] GameObject VisualizedVectorPrefab = null;
        [SerializeField] GameObject MousePositionPrefab = null;
        [SerializeField] GameObject VectorMoverPrefab = null;
        [SerializeField] GameObject PlanePrefab = null;
        [SerializeField] GameObject BackgroundLinesPrefab = null;
        [SerializeField] GameObject ResultTextPrefab = null;

        [Header("Properties")]
        [SerializeField] Color color = new Color();
        [SerializeField] Vector3 PlanePosition = new Vector3();
        [SerializeField] Vector3 PlaneScale = new Vector3();

        GameObject plane = null;
        ResultText resultText = null;
        VisualizedVector visualizedVector = null;

        private void Start()
        {
            Instantiate(MousePositionPrefab, this.transform);
            Instantiate(VectorMoverPrefab, this.transform);
            Instantiate(BackgroundLinesPrefab, this.transform);

            plane = Instantiate(PlanePrefab,
                PlanePosition + this.transform.position,
                Quaternion.Euler(-90f, 0f, 0f),
                this.transform);

            visualizedVector = Instantiate(
                VisualizedVectorPrefab,
                this.transform).
                GetComponent<VisualizedVector>();

            resultText = Instantiate(ResultTextPrefab,
                this.transform.position + (Vector3.up * 3f),
                Quaternion.identity, this.transform).
                GetComponent<ResultText>();
        }

        private void LateUpdate()
        {
            plane.transform.localPosition = PlanePosition;
            plane.transform.localScale = PlaneScale;
        }

        public Color GetColor()
        {
            return color;
        }

        public Vector2 GetVector()
        {
            return visualizedVector.GetCurrentVector();
        }
    }
}