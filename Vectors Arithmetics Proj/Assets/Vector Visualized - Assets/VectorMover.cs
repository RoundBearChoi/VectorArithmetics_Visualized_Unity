using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roundbeargames
{
    public class VectorMover : MonoBehaviour
    {
        [SerializeField] LineRenderer targetVector = null;
        [SerializeField] Vector3 mousePos = new Vector3();
        MousePosition mousePosition = null;

        private void Start()
        {
            mousePosition = FindObjectOfType<MousePosition>();
        }

        private void Update()
        {
            mousePos = mousePosition.GetClickedMousePosition();
            
            if (targetVector != null)
            {
                Vector3 pos = new Vector3(mousePos.x, mousePos.y, 0f);
                targetVector.SetPosition(1, pos);
            }
        }
    }
}