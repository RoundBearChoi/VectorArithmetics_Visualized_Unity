using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roundbeargames
{
    public class VectorPlusVector : SceneStarter
    {
        [SerializeField] Color ColorA = new Color();
        [SerializeField] Color ColorB = new Color();
        [SerializeField] Color ColorC = new Color();

        private void Start()
        {
            StartScene();
        }

        public override void StartScene()
        {
            listSlates.Clear();

            listSlates.Add(Instantiate(VectorPlanePrefab).GetComponent<Slate>());
            listSlates.Add(Instantiate(VectorPlanePrefab).GetComponent<Slate>());
            listSlates.Add(Instantiate(VectorPlanePrefab).GetComponent<Slate>());

            foreach (Slate s in listSlates)
            {
                s.CreateCommonComponents();
                s.SetBackgroundPlane(new Vector3(0f, 0f, 5f), new Vector3(-90f, 0f, 0f));
            }

            listSlates[0].transform.position = new Vector3(-5f, 2f, 0f);
            listSlates[1].transform.position = new Vector3(5f, 2f, 0f);
            listSlates[2].transform.position = new Vector3(0, -3f, 0f);

            listSlates[0].CreateVisualizedVector();
            listSlates[1].CreateVisualizedVector();
            listSlates[2].CreateVisualizedVector();
            listSlates[2].CreateVisualizedVector();
        }

        private void Update()
        {
            foreach(Slate s in listSlates)
            {
                s.UpdateVector();
            }

            // vector A
            listSlates[2].LINE_MOVER.ManualSetLine(0, 1, listSlates[0].GetVector(0));

            // vector B
            listSlates[2].LINE_MOVER.ManualSetLine(1, 0, listSlates[0].GetVector(0));

            // vector A + B
            listSlates[2].LINE_MOVER.ManualSetLine(1, 1, listSlates[0].GetVector(0) + listSlates[1].GetVector(0));

            SetLineColor(listSlates[0], 0, ColorA);
            SetLineColor(listSlates[1], 0, ColorB);
            SetLineColor(listSlates[2], 0, ColorA);
            SetLineColor(listSlates[2], 1, ColorB);
        }

        void SetLineColor(Slate slate, int vectorIndex, Color color)
        {
            VisualizedVector targetVec = slate.GetVisualizedVector(vectorIndex);

            if (targetVec != null)
            {
                targetVec.SetColor(color);
            }
        }
    }
}