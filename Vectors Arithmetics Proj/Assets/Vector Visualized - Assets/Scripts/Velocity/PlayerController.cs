using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Roundbeargames
{
    public class PlayerController : MonoBehaviour
    {
        float MaxVelocity = 0f;
        float MaxAcceleration = 0f;
        float AccelerationMagnitude = 0f;
        float MaxPosition = 0f;
        float SlowDownSpeed = 0f;

        [Header("Setup")]
        [SerializeField] Slider MaxVelocitySlider = null;
        [SerializeField] Slider MaxAccelerationSlider = null;
        [SerializeField] Slider AccelerationMagnitudeSlider = null;
        [SerializeField] Slider MaxPositionSlider = null;
        [SerializeField] Slider SlowDownSpeedSlider = null;

        [Header("Debug")]
        [SerializeField] Vector3 Velocity = new Vector3();
        [SerializeField] Vector3 Acceleration = new Vector3();
        [SerializeField] Vector3 PlayerPosition = new Vector3();

        private void Update()
        {
            UpdateStats();
            MovePlayer();
        }

        void UpdateStats()
        {
            MaxVelocity = MaxVelocitySlider.value;
            MaxAcceleration = MaxAccelerationSlider.value;
            AccelerationMagnitude = AccelerationMagnitudeSlider.value;
            MaxPosition = MaxPositionSlider.value;
            SlowDownSpeed = SlowDownSpeedSlider.value;
        }

        void MovePlayer()
        {
            Acceleration = Vector3.zero;

            if (Input.GetKey(KeyCode.W))
            {
                Acceleration += new Vector3(0f, AccelerationMagnitude, 0f);
            }

            if (Input.GetKey(KeyCode.A))
            {
                Acceleration -= new Vector3(AccelerationMagnitude, 0f, 0f);
            }

            if (Input.GetKey(KeyCode.S))
            {
                Acceleration -= new Vector3(0f, AccelerationMagnitude, 0f);
            }

            if (Input.GetKey(KeyCode.D))
            {
                Acceleration += new Vector3(AccelerationMagnitude, 0f, 0f);
            }

            ClampVector(ref Acceleration, MaxAcceleration);
            Velocity += (Acceleration * Time.deltaTime);

            ClampVector(ref Velocity, MaxVelocity);
            PlayerPosition += (Velocity * Time.deltaTime);

            ClampVector(ref PlayerPosition, MaxPosition);
            this.transform.position = PlayerPosition;

            Acceleration = Vector3.Lerp(Acceleration, Vector3.zero, SlowDownSpeed * Time.deltaTime);
            Velocity = Vector3.Lerp(Velocity, Vector3.zero, SlowDownSpeed * Time.deltaTime);
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