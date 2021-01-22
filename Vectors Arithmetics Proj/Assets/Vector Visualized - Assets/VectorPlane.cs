using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roundbeargames
{
    public class VectorPlane : MonoBehaviour
    {
        [SerializeField] GameObject VisualizedVectorPrefab = null;
        [SerializeField] GameObject MousePositionPrefab = null;
        [SerializeField] GameObject VectorMoverPrefab = null;
        [SerializeField] GameObject PlanePrefab = null;
        [SerializeField] GameObject BackgroundLinesPrefab = null;
        [SerializeField] Color color = new Color();
        [SerializeField] Vector3 PlanePosition = new Vector3();
        [SerializeField] Vector3 PlaneScale = new Vector3();

        GameObject plane = null;

        private void Start()
        {
            Instantiate(VisualizedVectorPrefab, this.transform);
            Instantiate(MousePositionPrefab, this.transform);
            Instantiate(VectorMoverPrefab, this.transform);
            Instantiate(BackgroundLinesPrefab, this.transform);
            plane = Instantiate(PlanePrefab, PlanePosition + this.transform.position, Quaternion.Euler(-90f, 0f, 0f), this.transform);
        }

        private void LateUpdate()
        {
            plane.transform.localPosition = PlanePosition;
            plane.transform.localScale = PlaneScale;
        }

        public Color GetColor()
        {
            return color;
        }
    }
}