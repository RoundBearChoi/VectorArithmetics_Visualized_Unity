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

        public void UpdateVisuals()
        {
            if (lineRenderer == null || vectorPlane == null)
            {
                lineRenderer = this.gameObject.GetComponent<LineRenderer>();
                vectorPlane = this.gameObject.GetComponentInParent<VectorPlane>();
            }
            else
            {
                RenderArrow();
            }
        }

        public void RenderArrow()
        {
            endPoint = lineRenderer.GetPosition(1);

            Vector3 scale = this.transform.root.transform.localScale;
            Vector3 scaledEndPoint = new Vector3(endPoint.x * scale.x, endPoint.y * scale.y, 0f);

            leftArrow.transform.position = this.transform.position + scaledEndPoint;
            rightArrow.transform.position = this.transform.position + scaledEndPoint;

            Vector2 edge = lineRenderer.GetPosition(1);

            RotateLine(ref leftArrow, -edge, 30f);
            RotateLine(ref rightArrow, -edge, -30f);

            lineRenderer.startColor = vectorPlane.GetColor();
            leftArrow.startColor = vectorPlane.GetColor();
            rightArrow.startColor = vectorPlane.GetColor();

            lineRenderer.endColor = vectorPlane.GetColor();
            leftArrow.endColor = vectorPlane.GetColor();
            rightArrow.endColor = vectorPlane.GetColor();
        }

        private void RotateLine(ref LineRenderer line, Vector2 direction, float angle)
        {
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

            Vector2 rotatedVec = q * direction;
            rotatedVec.Normalize();
            rotatedVec *= ArrowLength;

            line.SetPosition(1, rotatedVec);
        }

        public Vector2 GetCurrentVector()
        {
            if (lineRenderer == null)
            {
                return Vector2.zero;
            }
            else
            {
                return lineRenderer.GetPosition(1) - lineRenderer.GetPosition(0);
            }
        }

        public LineRenderer GetLineRenderer()
        {
            return lineRenderer;
        }
    }
}