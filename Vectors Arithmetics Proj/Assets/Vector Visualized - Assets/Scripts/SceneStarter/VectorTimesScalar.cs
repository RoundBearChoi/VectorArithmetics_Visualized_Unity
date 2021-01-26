using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roundbeargames
{
    public class VectorTimesScalar : SceneStarter
    {
        [Header("Setup")]
        [SerializeField] Color ColorA = new Color();
        [SerializeField] Color ColorB = new Color();
        [SerializeField] Material FilledLineMaterial = null;
        [SerializeField] Material DottedLineMaterial = null;

        private void Start()
        {
            StartScene();
        }

        public override void StartScene()
        {
            listSlates.Clear();

            listSlates.Add(Instantiate(SlatePrefab).GetComponent<Slate>());
            listSlates.Add(Instantiate(SlatePrefab).GetComponent<Slate>());

            foreach (Slate s in listSlates)
            {
                s.CreateCommonComponents();
            }

            listSlates[0].transform.position = new Vector3(-3f - 1f, 1.3f, 0f);
            listSlates[1].transform.position = new Vector3(0 - 1f, -3.4f, 0f);

            listSlates[0].CreateVisualizedVector();
            listSlates[1].CreateVisualizedVector();
            listSlates[1].CreateVisualizedVector();

            listSlates[0].BACKGROUND_PLANE.transform.localScale = new Vector3(0.45f, 1f, 0.425f);
            listSlates[1].BACKGROUND_PLANE.transform.localScale = new Vector3(0.45f, 1f, 0.425f);

            listSlates[0].BACKGROUND_PLANE.transform.localPosition = new Vector3(0.925f, 0.95f, 8f);
            listSlates[1].BACKGROUND_PLANE.transform.localPosition = new Vector3(0.925f, 0.95f, 8f);

            listSlates[0].BACKGROUND_PLANE.transform.localRotation = Quaternion.Euler(new Vector3(-90f, 0f, 0f));
            listSlates[1].BACKGROUND_PLANE.transform.localRotation = Quaternion.Euler(new Vector3(-90f, 0f, 0f));
        }

        private void Update()
        {
            foreach(Slate s in listSlates)
            {
                s.UpdateLine();
            }

            listSlates[0].TITLE_TEXT.transform.localPosition = (Vector3.left * 2f) + (Vector3.up * 2.5f);
            listSlates[1].TITLE_TEXT.transform.localPosition = (Vector3.left * 2f) + (Vector3.up * 2.5f);

            // result: vector A
            listSlates[1].LINE_MOVER.ManualSetLine(0, 0, Vector3.zero);
            listSlates[1].LINE_MOVER.ManualSetLine(0, 1, listSlates[0].GetVector(0));

            // scalar
            float scalar = 1.2f;

            // result: A * scalar
            Vector2 resultVec = listSlates[0].GetVector(0) * scalar;
            listSlates[1].LINE_MOVER.ManualSetLine(1, 0, Vector3.zero);
            listSlates[1].LINE_MOVER.ManualSetLine(1, 1, resultVec);

            // show result in text
            listSlates[1].RESULT_TEXT.SetText(resultVec);

            // show result red dot
            Vector3 v3convert = new Vector3(listSlates[1].GetVector(1).x, listSlates[1].GetVector(1).y, 2f);
            listSlates[1].MOUSE_DATA.SetRedDotPosition(listSlates[1].transform.position + v3convert);

            SetLineMaterial(listSlates[0], 0, FilledLineMaterial, ColorA);
            SetLineMaterial(listSlates[1], 0, FilledLineMaterial, ColorA);
            SetLineMaterial(listSlates[1], 1, FilledLineMaterial, ColorB);

            listSlates[0].TITLE_TEXT.SetTitle("A");
            listSlates[1].TITLE_TEXT.SetTitle("A * Scalar");

            listSlates[0].UpdateArrows();
            listSlates[1].UpdateArrows();
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