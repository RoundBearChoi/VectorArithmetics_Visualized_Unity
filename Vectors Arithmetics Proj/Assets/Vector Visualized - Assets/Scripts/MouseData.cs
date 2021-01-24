using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roundbeargames
{
    public class MouseData : MonoBehaviour
    {
        [SerializeField] Transform redDot = null;
        [SerializeField] Vector3 clickedMousePosition = new Vector3();
        Camera cam;
        GameObject clickedPlane = null;
        bool mouseIsClicked = false;

        void InitMouseData()
        {
            Debug.Log("initializing MouseData");
            cam = FindObjectOfType<Camera>();
        }

        public void UpdateData()
        {
            if (cam == null)
            {
                InitMouseData();
            }
            else
            {
                RunMouseUpdate();
            }
        }

        void RunMouseUpdate()
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
                        redDot.position = new Vector3(hit.point.x, hit.point.y, this.transform.position.z + 2f);

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