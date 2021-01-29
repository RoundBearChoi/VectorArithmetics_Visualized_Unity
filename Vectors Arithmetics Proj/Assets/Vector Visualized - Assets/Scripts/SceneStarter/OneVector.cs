using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roundbeargames
{
    public class OneVector : SceneStarter
    {
        [Header("Setup")]
        [SerializeField] Color ColorA = new Color();
        [SerializeField] Material FilledLineMaterial = null;

        private void Start()
        {
            StartScene();
        }

        public override void StartScene()
        {
            listSlates.Clear();

            listSlates.Add(Instantiate(SlatePrefab).GetComponent<Slate>());

            foreach (Slate s in listSlates)
            {
                s.CreateCommonComponents();
            }

            listSlates[0].transform.position = new Vector3(-3f - 1f, 1.3f, 0f);
            listSlates[0].CreateVisualizedVector();
            listSlates[0].BACKGROUND_PLANE.transform.localScale = new Vector3(0.45f, 1f, 0.425f);
            listSlates[0].BACKGROUND_PLANE.transform.localPosition = new Vector3(0.925f, 0.95f, 8f);
            listSlates[0].BACKGROUND_PLANE.transform.localRotation = Quaternion.Euler(new Vector3(-90f, 0f, 0f));
        }

        private void Update()
        {
            foreach(Slate s in listSlates)
            {
                s.UpdateLine();
            }

            listSlates[0].UpdateArrows();

            listSlates[0].TITLE_TEXT.transform.localPosition = (Vector3.left * 2f) + (Vector3.up * 2.5f);

            SetLineMaterial(listSlates[0], 0, FilledLineMaterial, ColorA);

            listSlates[0].TITLE_TEXT.SetTitle("A");
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