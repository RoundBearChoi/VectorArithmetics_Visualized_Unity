using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roundbeargames
{
    public class VectorMover : MonoBehaviour
    {
        [SerializeField] LineRenderer targetVector = null;
        [SerializeField] MousePosition mousePosition = null;

        private void Start()
        {
            targetVector.SetPosition(1, Vector3.zero);
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Mouse0))
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