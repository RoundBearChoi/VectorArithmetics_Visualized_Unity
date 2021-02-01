using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roundbeargames
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField] float MaxVelocity = 0f;
        [SerializeField] float MaxAcceleration = 0f;
        [SerializeField] float AccelerationMagnitude = 0f;
        [SerializeField] float MaxPosition = 0f;
        [SerializeField] float SlowDownSpeed = 0f;

        [Header("Debug")]
        [SerializeField] Vector3 Velocity = new Vector3();
        [SerializeField] Vector3 Acceleration = new Vector3();
        [SerializeField] Vector3 PlayerPosition = new Vector3();

        bool keyIsPressed = false;

        private void Update()
        {
            Acceleration = Vector3.zero;
            keyIsPressed = false;

            if (Input.GetKey(KeyCode.W))
            {
                Acceleration += new Vector3(0f, AccelerationMagnitude, 0f);
                keyIsPressed = true;
            }

            if (Input.GetKey(KeyCode.A))
            {
                Acceleration -= new Vector3(AccelerationMagnitude, 0f, 0f);
                keyIsPressed = true;
            }

            if (Input.GetKey(KeyCode.S))
            {
                Acceleration -= new Vector3(0f, AccelerationMagnitude, 0f);
                keyIsPressed = true;
            }

            if (Input.GetKey(KeyCode.D))
            {
                Acceleration += new Vector3(AccelerationMagnitude, 0f, 0f);
                keyIsPressed = true;
            }

            if (!keyIsPressed)
            {
                Acceleration = Vector3.Lerp(Acceleration, Vector3.zero, SlowDownSpeed * Time.deltaTime);
                Velocity = Vector3.Lerp(Velocity, Vector3.zero, SlowDownSpeed * Time.deltaTime);
            }

            ClampVector(ref Acceleration, MaxAcceleration);
            Velocity += (Acceleration * Time.deltaTime);
            
            ClampVector(ref Velocity, MaxVelocity);
            PlayerPosition += (Velocity * Time.deltaTime);

            ClampVector(ref PlayerPosition, MaxPosition);
            this.transform.position = PlayerPosition;
        }

        void ClampVector(ref Vector3 targetVec, float max)
        {
            if (targetVec.sqrMagnitude > max * max)
            {
                targetVec.Normalize();
                targetVec *= max;
            }
        }
    }
}