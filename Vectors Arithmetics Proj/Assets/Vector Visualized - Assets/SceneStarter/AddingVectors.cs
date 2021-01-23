using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roundbeargames
{
    public class AddingVectors : SceneStarter
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
            }
        }
    }
}