using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roundbeargames
{
    public class LineMover : MonoBehaviour
    {
        Slate slate = null;
        MouseData mouseData = null;

        public LineRenderer LINE_RENDERER(int index)
        {
            return slate.GetVisualizedVector(index).GetLineRenderer();
        }

        void InitMover()
        {
            slate = this.gameObject.GetComponentInParent<Slate>();
            mouseData = this.transform.root.GetComponentInChildren<MouseData>();

            LINE_RENDERER(0).SetPosition(0, Vector3.zero);
            LINE_RENDERER(0).SetPosition(1, Vector3.zero);
        }

        public void UpdateOnMouse(int index)
        {
            if (mouseData == null || slate == null)
            {
                InitMover();
            }
            else
            {
                SetLineOnMouseData(index);
            }
        }

        private void SetLineOnMouseData(int index)
        {
            if (mouseData.MouseIsClicked())
            {
                if (LINE_RENDERER(index) != null)
                {
                    if (mouseData.GetClickedPlane() != null)
                    {
                        if (mouseData.GetClickedPlane().transform.root == this.transform.root)
                        {
                            Vector3 clickPosition = mouseData.GetClickedMousePosition();
                            Vector3 pos = new Vector3(clickPosition.x, clickPosition.y, this.transform.position.z);

                            Vector3 relativePos = pos - LINE_RENDERER(index).transform.position;

                            Vector3 scale = this.transform.root.transform.localScale;
                            Vector3 scaledPos = new Vector3(
                                relativePos.x / scale.x,
                                relativePos.y / scale.y,
                                relativePos.z);

                            LINE_RENDERER(index).SetPosition(1, scaledPos);

                            mouseData.ResetMouseClick();
                        }
                    }
                }
            }
        }
    }
}