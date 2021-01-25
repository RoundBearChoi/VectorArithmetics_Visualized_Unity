using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roundbeargames
{
    public class ReverseImage : MonoBehaviour
    {
        [SerializeField] Color ClickedColor = new Color();
        [SerializeField] Color NotClickedColor = new Color();

        Camera cam = null;
        Renderer objRenderer = null;

        private void Start()
        {
            cam = FindObjectOfType<Camera>();
            objRenderer = this.gameObject.GetComponent<Renderer>();
        }

        public void UpdateClick(ref bool reverse)
        {
            if (cam != null)
            {
                RaycastHit hit = MouseClick.GetMouseUpHit(cam);

                if (hit.transform != null)
                {
                    if (hit.transform == this.transform)
                    {
                        if (!reverse)
                        {
                            reverse = true;
                        }
                        else
                        {
                            reverse = false;
                        }
                    }
                }
            }

            if (reverse)
            {
                objRenderer.material.color = ClickedColor;
            }
            else
            {
                objRenderer.material.color = NotClickedColor;
            }
        }
    }
}