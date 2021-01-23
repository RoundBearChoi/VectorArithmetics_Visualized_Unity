using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roundbeargames
{
    public class Slate : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField] GameObject VisualizedVectorPrefab = null;
        [SerializeField] GameObject MouseDataPrefab = null;
        [SerializeField] GameObject LineMoverPrefab = null;
        [SerializeField] GameObject BackgroundPlanePrefab = null;
        [SerializeField] GameObject BackgroundLinesPrefab = null;
        [SerializeField] GameObject ResultTextPrefab = null;

        [Header("Properties")]
        [SerializeField] Color color = new Color();

        [Header("Debug")]
        [SerializeField] List<VisualizedVector> listVisualizedVectors = new List<VisualizedVector>();
        ResultText resultText = null;
        LineMover lineMover = null;
        MouseData mouseData = null;
        BackgroundLines backgroundLines = null;
        BackgroundPlane backgroundPlane = null;

        public LineMover LINE_MOVER
        {
            get
            {
                return lineMover;
            }
        }

        public void CreateCommonComponents()
        {
            listVisualizedVectors.Clear();

            backgroundLines = InstantiateComponent<BackgroundLines>(BackgroundLinesPrefab);
            backgroundPlane = InstantiateComponent<BackgroundPlane>(BackgroundPlanePrefab);
            lineMover = InstantiateComponent<LineMover>(LineMoverPrefab);
            mouseData = InstantiateComponent<MouseData>(MouseDataPrefab);
            resultText = InstantiateComponent<ResultText>(ResultTextPrefab);

            resultText.transform.localPosition = Vector3.up * 3f;
        }

        public void CreateVisualizedVector()
        {
            VisualizedVector v = InstantiateComponent<VisualizedVector>(VisualizedVectorPrefab);
            listVisualizedVectors.Add(v);
        }

        T InstantiateComponent<T>(GameObject prefab)
        {
            return Instantiate(prefab, this.transform).GetComponent<T>();
        }

        public void UpdateVector()
        {
            foreach(VisualizedVector v in listVisualizedVectors)
            {
                v.RenderArrow();
            }

            mouseData.UpdateData();
            lineMover.UpdateOnMouse(0);
            resultText.UpdateText(0);
        }

        public Color GetColor()
        {
            return color;
        }

        public Vector2 GetVector(int index)
        {
            if (listVisualizedVectors.Count > index)
            {
                return listVisualizedVectors[index].GetCurrentVector();
            }
            else
            {
                return Vector2.zero;
            }
        }

        public void SetBackgroundPlane(Vector3 localPosition, Vector3 localRotation)
        {
            backgroundPlane.transform.localPosition = localPosition;
            backgroundPlane.transform.localRotation = Quaternion.Euler(localRotation);
        }

        public VisualizedVector GetVisualizedVector(int index)
        {
            if (listVisualizedVectors.Count > index)
            {
                return listVisualizedVectors[index];
            }
            else
            {
                return null;
            }
        }
    }
}