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

        LineRenderer lineRenderer = null;
        Vector2 endPoint = new Vector2(0f, 0f);

        private void Start()
        {
            lineRenderer = this.gameObject.GetComponent<LineRenderer>();
        }

        private void LateUpdate()
        {
            endPoint = lineRenderer.GetPosition(1);
            Vector2 worldpos = new Vector2(this.transform.position.x, this.transform.position.y);
            leftArrow.transform.position = worldpos + endPoint;
            rightArrow.transform.position = worldpos + endPoint;

            RotateLine(ref leftArrow, lineRenderer.GetPosition(0) - lineRenderer.GetPosition(1), 30f);
            RotateLine(ref rightArrow, lineRenderer.GetPosition(0) - lineRenderer.GetPosition(1), -30f);
        }

        private void RotateLine(ref LineRenderer line, Vector2 baseDirection, float angle)
        {
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            Vector2 rotatedVec = q * baseDirection;
            rotatedVec.Normalize();
            rotatedVec *= ArrowLength;

            line.SetPosition(1, rotatedVec);
        }
    }
}