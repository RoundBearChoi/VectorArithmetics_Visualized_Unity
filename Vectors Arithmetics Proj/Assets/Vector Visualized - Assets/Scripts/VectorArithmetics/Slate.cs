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
        [SerializeField] GameObject TitleTextPrefab = null;

        [Header("Debug")]
        [SerializeField] List<VisualizedVector> listVisualizedVectors = new List<VisualizedVector>();
        TitleText titleText = null;
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

        public ResultText RESULT_TEXT
        {
            get
            {
                return resultText;
            }
        }

        public TitleText TITLE_TEXT
        {
            get
            {
                return titleText;
            }
        }

        public BackgroundPlane BACKGROUND_PLANE
        {
            get
            {
                return backgroundPlane;
            }
        }

        public MouseData MOUSE_DATA
        {
            get
            {
                return mouseData;
            }
        }

        public void CreateCommonComponents()
        {
            listVisualizedVectors.Clear();

            backgroundLines = InstantiateComponent<BackgroundLines>(BackgroundLinesPrefab);
            backgroundPlane = InstantiateComponent<BackgroundPlane>(BackgroundPlanePrefab);
            lineMover = InstantiateComponent<LineMover>(LineMoverPrefab);
            mouseData = InstantiateComponent<MouseData>(MouseDataPrefab);
            titleText = InstantiateComponent<TitleText>(TitleTextPrefab);
            resultText = InstantiateComponent<ResultText>(ResultTextPrefab);

            //titleText.transform.localPosition = (Vector3.left * 2f) + (Vector3.up * 2.5f);
            resultText.transform.localPosition = Vector3.up * 2.5f;
            backgroundLines.transform.localPosition = Vector3.forward * 3f;
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

        public void UpdateLine()
        {
            mouseData.UpdateData();
            lineMover.UpdateOnMouse(0);
            resultText.UpdateText(0);
        }

        public void UpdateArrows()
        {
            foreach (VisualizedVector v in listVisualizedVectors)
            {
                v.RenderArrow();
            }
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