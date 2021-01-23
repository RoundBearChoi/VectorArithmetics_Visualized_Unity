using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roundbeargames
{
    public class VectorPlusVector : SceneStarter
    {
        Vector2 testing = new Vector2();

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
            }

            listSlates[0].transform.position = new Vector3(-5f, 2f, 0f);
            listSlates[1].transform.position = new Vector3(5f, 2f, 0f);
            listSlates[2].transform.position = new Vector3(0, -3f, 0f);

            listSlates[0].CreateVisualizedVector();
            listSlates[1].CreateVisualizedVector();
            listSlates[2].CreateVisualizedVector();
        }

        private void Update()
        {
            foreach(Slate s in listSlates)
            {
                s.UpdateVector();
                s.SetBackgroundPlane(new Vector3(0f, 0f, 5f), new Vector3(-90f, 0f, 0f));
            }

            testing = new Vector3(testing.x + Time.deltaTime * 0.2f, testing.y + Time.deltaTime * 0.15f, 0f);

            listSlates[2].LINE_MOVER.ManualSetLine(0, testing);
        }
    }
}