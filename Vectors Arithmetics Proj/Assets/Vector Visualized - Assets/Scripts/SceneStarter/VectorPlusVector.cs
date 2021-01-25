using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roundbeargames
{
    public class VectorPlusVector : SceneStarter
    {
        [Header("Setup")]
        [SerializeField] Color ColorA = new Color();
        [SerializeField] Color ColorB = new Color();
        [SerializeField] Color ColorC = new Color();
        [SerializeField] Material FilledLineMaterial = null;
        [SerializeField] Material DottedLineMaterial_A = null;
        [SerializeField] Material DottedLineMaterial_B = null;
                
        [Header("Debug")]
        [SerializeField] bool ReverseEquation = false;

        ReverseImage reverseImage = null;

        private void Start()
        {
            reverseImage = this.gameObject.GetComponentInChildren<ReverseImage>();
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
            }

            listSlates[0].transform.position = new Vector3(-3f - 1f, 1.3f, 0f);
            listSlates[1].transform.position = new Vector3(3f - 1f, 1.3f, 0f);
            listSlates[2].transform.position = new Vector3(0 - 1f, -3.4f, 0f);

            listSlates[0].CreateVisualizedVector();
            listSlates[1].CreateVisualizedVector();
            listSlates[2].CreateVisualizedVector();
            listSlates[2].CreateVisualizedVector();
            listSlates[2].CreateVisualizedVector();

            listSlates[0].BACKGROUND_PLANE.transform.localScale = new Vector3(0.45f, 1f, 0.425f);
            listSlates[1].BACKGROUND_PLANE.transform.localScale = new Vector3(0.45f, 1f, 0.425f);
            listSlates[2].BACKGROUND_PLANE.transform.localScale = new Vector3(0.45f, 1f, 0.425f);

            listSlates[0].BACKGROUND_PLANE.transform.localPosition = new Vector3(0.925f, 0.95f, 8f);
            listSlates[1].BACKGROUND_PLANE.transform.localPosition = new Vector3(0.925f, 0.95f, 8f);
            listSlates[2].BACKGROUND_PLANE.transform.localPosition = new Vector3(0.925f, 0.95f, 8f);

            listSlates[0].BACKGROUND_PLANE.transform.localRotation = Quaternion.Euler(new Vector3(-90f, 0f, 0f));
            listSlates[1].BACKGROUND_PLANE.transform.localRotation = Quaternion.Euler(new Vector3(-90f, 0f, 0f));
            listSlates[2].BACKGROUND_PLANE.transform.localRotation = Quaternion.Euler(new Vector3(-90f, 0f, 0f));

            listSlates[2].GetVisualizedVector(0).DeleteArrows();
            listSlates[2].GetVisualizedVector(1).DeleteArrows();
        }

        private void Update()
        {
            foreach(Slate s in listSlates)
            {
                s.UpdateLine();
            }

            listSlates[0].UpdateArrows();
            listSlates[1].UpdateArrows();
            listSlates[2].UpdateArrows();

            // result: vector A
            listSlates[2].LINE_MOVER.ManualSetLine(0, 1, listSlates[0].GetVector(0));

            // result: vector B
            listSlates[2].LINE_MOVER.ManualSetLine(1, 0, listSlates[0].GetVector(0));
            listSlates[2].LINE_MOVER.ManualSetLine(1, 1, listSlates[0].GetVector(0) + listSlates[1].GetVector(0));

            // result: vector C
            Vector2 resultVec = listSlates[0].GetVector(0) + listSlates[1].GetVector(0);
            listSlates[2].LINE_MOVER.ManualSetLine(2, 1, resultVec);

            SetLineMaterial(listSlates[0], 0, FilledLineMaterial, ColorA);
            SetLineMaterial(listSlates[1], 0, FilledLineMaterial, ColorB);
            SetLineMaterial(listSlates[2], 0, DottedLineMaterial_A, ColorA);
            SetLineMaterial(listSlates[2], 1, DottedLineMaterial_B, ColorB);
            SetLineMaterial(listSlates[2], 2, FilledLineMaterial, ColorC);

            listSlates[2].RESULT_TEXT.SetText(resultVec);

            listSlates[0].TITLE_TEXT.SetTitle("A");
            listSlates[1].TITLE_TEXT.SetTitle("B");

            if (ReverseEquation)
            {
                listSlates[2].TITLE_TEXT.SetTitle("B + A");
            }
            else
            {
                listSlates[2].TITLE_TEXT.SetTitle("A + B");
            }

            reverseImage.UpdateClick(ref ReverseEquation);
        }

        void SetLineMaterial(Slate slate, int vectorIndex, Material material, Color color)
        {
            VisualizedVector targetVec = slate.GetVisualizedVector(vectorIndex);

            if (targetVec != null)
            {
                targetVec.SetLineColor(color);
                targetVec.SetObjMaterial(material, color);
            }
        }
    }
}