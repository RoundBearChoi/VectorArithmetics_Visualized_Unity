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
        const float ScaleToRadius = 10f / 3.85f; //2.597f;

        [Header("Setup")]
        [SerializeField] Slider MaxVelocitySlider = null;
        [SerializeField] Slider MaxAccelerationSlider = null;
        [SerializeField] Slider AccelerationMagnitudeSlider = null;
        [SerializeField] Slider MaxPositionSlider = null;
        [SerializeField] Slider SlowDownSpeedSlider = null;
        [SerializeField] RectTransform BackgroundCircle = null;
        [SerializeField] List<GameObject> listKeyHighlights = new List<GameObject>();

        [Header("Debug")]
        [SerializeField] Vector3 Velocity = new Vector3();
        [SerializeField] Vector3 Acceleration = new Vector3();
        [SerializeField] Vector3 PlayerPosition = new Vector3();

        private void Update()
        {
            UpdateStats();
            MovePlayer();
            UpdateCircle();
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
                listKeyHighlights[0].SetActive(true);
            }
            else
            {
                listKeyHighlights[0].SetActive(false);
            }

            if (Input.GetKey(KeyCode.A))
            {
                Acceleration -= new Vector3(AccelerationMagnitude, 0f, 0f);
                listKeyHighlights[1].SetActive(true);
            }
            else
            {
                listKeyHighlights[1].SetActive(false);
            }

            if (Input.GetKey(KeyCode.S))
            {
                Acceleration -= new Vector3(0f, AccelerationMagnitude, 0f);
                listKeyHighlights[2].SetActive(true);
            }
            else
            {
                listKeyHighlights[2].SetActive(false);
            }

            if (Input.GetKey(KeyCode.D))
            {
                Acceleration += new Vector3(AccelerationMagnitude, 0f, 0f);
                listKeyHighlights[3].SetActive(true);
            }
            else
            {
                listKeyHighlights[3].SetActive(false);
            }

            ClampVector(ref Acceleration, MaxAcceleration);
            Velocity += (Acceleration * Time.deltaTime);

            ClampVector(ref Velocity, MaxVelocity);
            PlayerPosition += (Velocity * Time.deltaTime);

            ClampVector(ref PlayerPosition, MaxPosition);
            this.transform.position = PlayerPosition;

            if (Acceleration == Vector3.zero || Vector3.Dot(Acceleration, Velocity) < 0f)
            {
                Acceleration = Vector3.Lerp(Acceleration, Vector3.zero, SlowDownSpeed * Time.deltaTime);
                Velocity = Vector3.Lerp(Velocity, Vector3.zero, SlowDownSpeed * Time.deltaTime);
            }
        }

        void UpdateCircle()
        {
            BackgroundCircle.localScale = new Vector3(
                MaxPositionSlider.value * ScaleToRadius,
                MaxPositionSlider.value * ScaleToRadius,
                1f);
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