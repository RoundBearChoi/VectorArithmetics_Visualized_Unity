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

            listVectorPlanes.Add(Instantiate(VectorPlanePrefab).GetComponent<VectorPlane>());
            //listVectorPlanes.Add(Instantiate(VectorPlanePrefab).GetComponent<VectorPlane>());
        }

        private void Update()
        {
            foreach(VectorPlane p in listVectorPlanes)
            {
                p.UpdateVector();
                p.SetBackgroundPlane(new Vector3(0f, 0f, 5f), new Vector3(-90f, 0f, 0f));
            }
        }
    }
}