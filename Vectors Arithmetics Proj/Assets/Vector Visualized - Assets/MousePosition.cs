using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roundbeargames
{
    public class MousePosition : MonoBehaviour
    {
        [SerializeField] Transform redDot = null;
        [SerializeField] Vector3 clickedMousePosition = new Vector3();
        Camera cam;
        GameObject clickedPlane = null;
        bool mouseIsClicked = false;

        private void Start()
        {
            cam = FindObjectOfType<Camera>();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.root == this.transform.root)
                    {
                        clickedMousePosition = hit.point;
                        redDot.position = new Vector3(hit.point.x, hit.point.y, 1f);

                        clickedPlane = hit.transform.gameObject;
                        mouseIsClicked = true;
                    }
                }
            }
        }

        public Vector3 GetClickedMousePosition()
        {
            return clickedMousePosition;
        }

        public GameObject GetClickedPlane()
        {
            return clickedPlane;
        }

        public bool MouseIsClicked()
        {
            return mouseIsClicked;
        }

        public void ResetMouseClick()
        {
            mouseIsClicked = false;
        }
    }
}