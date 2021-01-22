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
                    clickedMousePosition = hit.point;
                    redDot.position = hit.point;
                }
            }
        }

        public Vector3 GetClickedMousePosition()
        {
            return clickedMousePosition;
        }
    }
}