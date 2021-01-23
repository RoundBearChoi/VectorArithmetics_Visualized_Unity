using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roundbeargames
{
    public class VisualizedVector : MonoBehaviour
    {
        [SerializeField] LineRenderer leftArrow = null;
        [SerializeField] LineRenderer rightArrow = null;
        [SerializeField] float ArrowLength = 0f;
        VectorPlane vectorPlane;

        LineRenderer lineRenderer = null;
        Vector3 endPoint = new Vector3(0f, 0f, 0f);

        private void Start()
        {
            lineRenderer = this.gameObject.GetComponent<LineRenderer>();
            vectorPlane = this.gameObject.GetComponentInParent<VectorPlane>();
        }

        private void LateUpdate()
        {
            endPoint = lineRenderer.GetPosition(1);
            Vector3 worldpos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            leftArrow.transform.position = worldpos + endPoint;
            rightArrow.transform.position = worldpos + endPoint;

            RotateLine(ref leftArrow, lineRenderer.GetPosition(0) - lineRenderer.GetPosition(1), 30f);
            RotateLine(ref rightArrow, lineRenderer.GetPosition(0) - lineRenderer.GetPosition(1), -30f);

            lineRenderer.startColor = vectorPlane.GetColor();
            leftArrow.startColor = vectorPlane.GetColor();
            rightArrow.startColor = vectorPlane.GetColor();

            lineRenderer.endColor = vectorPlane.GetColor();
            leftArrow.endColor = vectorPlane.GetColor();
            rightArrow.endColor = vectorPlane.GetColor();
        }

        private void RotateLine(ref LineRenderer line, Vector2 baseDirection, float angle)
        {
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            Vector2 rotatedVec = q * baseDirection;
            rotatedVec.Normalize();
            rotatedVec *= ArrowLength;

            line.SetPosition(1, rotatedVec);
        }

        public Vector2 GetCurrentVector()
        {
            return lineRenderer.GetPosition(1) - lineRenderer.GetPosition(0);
        }
    }
}