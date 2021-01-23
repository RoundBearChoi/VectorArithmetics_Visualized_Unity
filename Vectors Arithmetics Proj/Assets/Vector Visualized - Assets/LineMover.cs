using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roundbeargames
{
    public class LineMover : MonoBehaviour
    {
        VectorPlane vectorPlane = null;
        MouseData mouseData = null;

        public LineRenderer LINE_RENDERER(int index)
        {
            return vectorPlane.GetVisualizedVector(index).GetLineRenderer();
        }

        public void UpdateOnMouse()
        {
            if (mouseData == null || vectorPlane == null)
            {
                vectorPlane = this.gameObject.GetComponentInParent<VectorPlane>();
                mouseData = this.transform.root.GetComponentInChildren<MouseData>();

                LINE_RENDERER(0).SetPosition(0, Vector3.zero);
                LINE_RENDERER(0).SetPosition(1, Vector3.zero);
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
                if (LINE_RENDERER(0) != null)
                {
                    if (mouseData.GetClickedPlane() != null)
                    {
                        if (mouseData.GetClickedPlane().transform.root == this.transform.root)
                        {
                            Vector3 clickPosition = mouseData.GetClickedMousePosition();
                            Vector3 pos = new Vector3(clickPosition.x, clickPosition.y, this.transform.position.z);

                            Vector3 relativePos = pos - LINE_RENDERER(0).transform.position;

                            Vector3 scale = this.transform.root.transform.localScale;
                            Vector3 scaledPos = new Vector3(
                                relativePos.x / scale.x,
                                relativePos.y / scale.y,
                                relativePos.z);

                            LINE_RENDERER(0).SetPosition(1, scaledPos);

                            mouseData.ResetMouseClick();
                        }
                    }
                }
            }
        }
    }
}