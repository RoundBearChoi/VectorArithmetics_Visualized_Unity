using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roundbeargames
{
    public class VectorMover : MonoBehaviour
    {
        LineRenderer targetVector = null;
        MouseData mousePosition = null;

        private void Start()
        {
            VisualizedVector v = this.transform.root.GetComponentInChildren<VisualizedVector>();
            targetVector = v.GetComponent<LineRenderer>();
            mousePosition = this.transform.root.GetComponentInChildren<MouseData>();

            targetVector.SetPosition(1, Vector3.zero);
        }

        private void Update()
        {
            if (mousePosition.MouseIsClicked())
            {
                if (targetVector != null)
                {
                    if (mousePosition.GetClickedPlane() != null)
                    {
                        if (mousePosition.GetClickedPlane().transform.root == this.transform.root)
                        {
                            Vector3 m = mousePosition.GetClickedMousePosition();
                            Vector3 pos = new Vector3(m.x, m.y, 0f);
                            targetVector.SetPosition(1, GetRelativePos(pos));

                            mousePosition.ResetMouseClick();
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