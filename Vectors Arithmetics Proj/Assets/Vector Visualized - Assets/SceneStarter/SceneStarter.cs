using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roundbeargames
{
    public abstract class SceneStarter : MonoBehaviour
    {
        [SerializeField] protected GameObject VectorPlanePrefab = null;
        [SerializeField] protected List<Slate> listVectorPlanes = new List<Slate>();

        public abstract void StartScene();
    }
}