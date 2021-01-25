using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roundbeargames
{
    public static class MouseClick
    {
        public static RaycastHit GetClickHit(Camera cam)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            hit.point = Vector3.zero;

            if (Input.GetKey(KeyCode.Mouse0))
            {
                Physics.Raycast(ray, out hit);
            }

            return hit;
        }
    }
}