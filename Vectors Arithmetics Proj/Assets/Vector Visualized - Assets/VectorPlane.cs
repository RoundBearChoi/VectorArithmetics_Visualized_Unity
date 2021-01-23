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

        [Header("Debug")]
        [SerializeField] List<VisualizedVector> listVisualizedVectors = new List<VisualizedVector>();
        ResultText resultText = null;
        //VisualizedVector visualizedVector = null;
        //VisualizedVector anothervis = null;
        LineMover vectorMover = null;
        GameObject backgroundPlane = null;

        public void Init()
        {
            listVisualizedVectors.Clear();

            Instantiate(MousePositionPrefab, this.transform);
            Instantiate(BackgroundLinesPrefab, this.transform);

            backgroundPlane = Instantiate(PlanePrefab, this.transform);

            VisualizedVector v = Instantiate(
                VisualizedVectorPrefab,
                this.transform).
                GetComponent<VisualizedVector>();

            listVisualizedVectors.Add(v);

            resultText = Instantiate(ResultTextPrefab,
                this.transform.position + (Vector3.up * 3f),
                Quaternion.identity, this.transform).
                GetComponent<ResultText>();

            vectorMover = Instantiate(VectorMoverPrefab,
                this.transform).
                GetComponent<LineMover>();
        }

        public void UpdateVector()
        {
            foreach(VisualizedVector v in listVisualizedVectors)
            {
                v.UpdateVisuals();
            }

            vectorMover.UpdateOnMouse();
            resultText.UpdateText();
        }

        public Color GetColor()
        {
            return color;
        }

        public Vector2 GetVector(int index)
        {
            return listVisualizedVectors[index].GetCurrentVector();
        }

        public void SetBackgroundPlane(Vector3 localPosition, Vector3 localRotation)
        {
            backgroundPlane.transform.localPosition = localPosition;
            backgroundPlane.transform.localRotation = Quaternion.Euler(localRotation);
        }

        public VisualizedVector GetVisualizedVector(int index)
        {
            return listVisualizedVectors[index];
        }
    }
}