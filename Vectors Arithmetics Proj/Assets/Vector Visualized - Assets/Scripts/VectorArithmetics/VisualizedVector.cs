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
        Slate slate;

        LineRenderer lineRenderer = null;
        Vector3 endPoint = new Vector3(0f, 0f, 0f);
        Renderer objRenderer = null;
        Renderer objRenderer_leftArrow = null;
        Renderer objRenderer_rightArrow = null;

        public void InitVisualizedVector()
        {
            Debug.Log("initializing VisualizedVector");

            lineRenderer = this.gameObject.GetComponent<LineRenderer>();
            slate = this.gameObject.GetComponentInParent<Slate>();

            objRenderer = this.gameObject.GetComponent<Renderer>();

            if (leftArrow != null)
            {
                objRenderer_leftArrow = leftArrow.gameObject.GetComponent<Renderer>();
            }

            if (rightArrow != null)
            {
                objRenderer_rightArrow = rightArrow.gameObject.GetComponent<Renderer>();
            }
        }

        public void RenderArrow()
        {
            if (lineRenderer == null || slate == null)
            {
                InitVisualizedVector();
            }
            else
            {
                RunArrowRender();
            }
        }

        public void RunArrowRender()
        {
            endPoint = lineRenderer.GetPosition(1);

            Vector3 scale = this.transform.root.transform.localScale;
            Vector3 scaledEndPoint = new Vector3(endPoint.x * scale.x, endPoint.y * scale.y, 0f);

            Vector2 vec = lineRenderer.GetPosition(0) - lineRenderer.GetPosition(1);

            if (leftArrow != null)
            {
                leftArrow.transform.position = this.transform.position + scaledEndPoint;
                RotateLine(ref leftArrow, vec, 30f);
            }
            
            if (rightArrow != null)
            {
                rightArrow.transform.position = this.transform.position + scaledEndPoint;
                RotateLine(ref rightArrow, vec, -30f);
            }
        }

        public void SetLineColor(Color color)
        {
            if (lineRenderer == null)
            {
                InitVisualizedVector();
            }
            else
            {
                lineRenderer.startColor = color;
                lineRenderer.endColor = color;
                
                if (leftArrow != null)
                {
                    leftArrow.startColor = color;
                    leftArrow.endColor = color;
                }

                if (rightArrow != null)
                {
                    rightArrow.startColor = color;
                    rightArrow.endColor = color;
                }
            }
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

        public void SetObjMaterial(Material material, Color color)
        {
            objRenderer.material = material;
            objRenderer.material.color = color;

            if (objRenderer_leftArrow != null)
            {
                objRenderer_leftArrow.material = material;
                objRenderer_leftArrow.material.color = color;
            }

            if (objRenderer_rightArrow != null)
            {
                objRenderer_rightArrow.material = material;
                objRenderer_rightArrow.material.color = color;
            }
        }

        public void DeleteArrows()
        {
            Destroy(leftArrow.gameObject);
            Destroy(rightArrow.gameObject);
        }
    }
}