using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roundbeargames
{
    public class VectorPlusVector : SceneStarter
    {
        private void Start()
        {
            StartScene();
        }

        public override void StartScene()
        {
            listVectorPlanes.Clear();

            listVectorPlanes.Add(Instantiate(VectorPlanePrefab).GetComponent<Slate>());
            //listVectorPlanes.Add(Instantiate(VectorPlanePrefab).GetComponent<Slate>());

            foreach (Slate s in listVectorPlanes)
            {
                s.CreateCommonComponents();
            }

            listVectorPlanes[0].CreateVisualizedVector();
        }

        private void Update()
        {
            foreach(Slate s in listVectorPlanes)
            {
                s.UpdateVector();
                s.SetBackgroundPlane(new Vector3(0f, 0f, 5f), new Vector3(-90f, 0f, 0f));
            }
        }
    }
}