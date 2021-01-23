using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roundbeargames
{
    public class VectorMover : MonoBehaviour
    {
        LineRenderer lineRenderer = null;
        MouseData mouseData = null;

        public void UpdateOnMouse()
        {
            if (mouseData == null)
            {
                VisualizedVector v = this.transform.root.GetComponentInChildren<VisualizedVector>();
                lineRenderer = v.GetComponent<LineRenderer>();
                mouseData = this.transform.root.GetComponentInChildren<MouseData>();

                lineRenderer.SetPosition(0, Vector3.zero);
                lineRenderer.SetPosition(1, Vector3.zero);
            }
            else
            {
                SetLine();
            }
        }

        private void SetLine()
        {
            mouseData.UpdateData();

            if (mouseData.MouseIsClicked())
            {
                if (lineRenderer != null)
                {
                    if (mouseData.GetClickedPlane() != null)
                    {
                        if (mouseData.GetClickedPlane().transform.root == this.transform.root)
                        {
                            Vector3 clickPosition = mouseData.GetClickedMousePosition();
                            Vector3 pos = new Vector3(clickPosition.x, clickPosition.y, this.transform.position.z);
                            Vector3 relativePos = GetRelativePos(pos);

                            Vector3 scale = this.transform.root.transform.localScale;
                            Vector3 scaledPos = new Vector3(
                                relativePos.x / scale.x,
                                relativePos.y / scale.y,
                                relativePos.z);

                            lineRenderer.SetPosition(1, scaledPos);

                            mouseData.ResetMouseClick();
                        }
                    }
                }
            }
        }

        Vector3 GetRelativePos(Vector3 worldPos)
        {
            return worldPos - lineRenderer.transform.position;
        }
    }
}