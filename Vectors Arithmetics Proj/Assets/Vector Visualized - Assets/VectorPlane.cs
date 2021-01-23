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

        ResultText resultText = null;
        VisualizedVector visualizedVector = null;
        VectorMover vectorMover = null;
        GameObject backgroundPlane = null;

        public void Init()
        {
            Instantiate(MousePositionPrefab, this.transform);
            Instantiate(BackgroundLinesPrefab, this.transform);

            backgroundPlane = Instantiate(PlanePrefab, this.transform);

            visualizedVector = Instantiate(
                VisualizedVectorPrefab,
                this.transform).
                GetComponent<VisualizedVector>();

            resultText = Instantiate(ResultTextPrefab,
                this.transform.position + (Vector3.up * 3f),
                Quaternion.identity, this.transform).
                GetComponent<ResultText>();

            vectorMover = Instantiate(VectorMoverPrefab,
                this.transform).
                GetComponent<VectorMover>();
        }

        public void UpdateVector()
        {
            visualizedVector.UpdateVisuals();
            vectorMover.UpdateOnMouse();
            resultText.UpdateText();
        }

        public Color GetColor()
        {
            return color;
        }

        public Vector2 GetVector()
        {
            return visualizedVector.GetCurrentVector();
        }

        public void SetBackgroundPlane(Vector3 localPosition, Vector3 localRotation)
        {
            backgroundPlane.transform.localPosition = localPosition;
            backgroundPlane.transform.localRotation = Quaternion.Euler(localRotation);
        }
    }
}