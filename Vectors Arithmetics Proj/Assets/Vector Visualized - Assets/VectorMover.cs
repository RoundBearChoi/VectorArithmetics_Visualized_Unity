using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roundbeargames
{
    public class VectorMover : MonoBehaviour
    {
        LineRenderer targetVector = null;
        MouseData mouseData = null;

        public void UpdateOnMouse()
        {
            if (mouseData == null)
            {
                VisualizedVector v = this.transform.root.GetComponentInChildren<VisualizedVector>();
                targetVector = v.GetComponent<LineRenderer>();
                mouseData = this.transform.root.GetComponentInChildren<MouseData>();

                targetVector.SetPosition(1, Vector3.zero);
            }
            else
            {
                RunUpdate();
            }
        }

        private void RunUpdate()
        {
            mouseData.UpdateData();

            if (mouseData.MouseIsClicked())
            {
                if (targetVector != null)
                {
                    if (mouseData.GetClickedPlane() != null)
                    {
                        if (mouseData.GetClickedPlane().transform.root == this.transform.root)
                        {
                            Vector3 m = mouseData.GetClickedMousePosition();
                            Vector3 pos = new Vector3(m.x, m.y, this.transform.position.z);
                            targetVector.SetPosition(1, GetRelativePos(pos));

                            mouseData.ResetMouseClick();
                        }
                    }
                }
            }
        }

        Vector3 GetRelativePos(Vector3 worldPos)
        {
            return worldPos - targetVector.transform.position;
        }
    }
}