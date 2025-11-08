using UnityEngine;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using System.Runtime.CompilerServices;

public class CarController : MonoBehaviour
{
    public enum ControlMode
    {
        Keyboard,
        Buttons
    };

    public enum Axel
    {
        Front,
        Rear
    }

    [Serializable]
    public struct Wheel
    {
        public GameObject wheelModel;
        public WheelCollider wheelCollider;
        public GameObject wheelEffectObj;
        public ParticleSystem smokeParticle;
        public Axel axel;
    }

    public ControlMode control;

    public float maxAcceleration = 30.0f;

    public float turnSensitivity = 1.0f;
    public float maxSteerAngle = 30.0f;

    public Vector3 _centerOfMass;

    public List<Wheel> wheels;

    float moveInput;
    float steerInput;

    public float score = 0;
    public TextMeshProUGUI ScoreText;

    private Rigidbody carRb;

    [SerializeField] int maxspeed;
    bool stopMoving;
    public bool clamprotation = true;
    
    //private CarLights carLights;
   
    public void Start()
    {
        carRb = GetComponent<Rigidbody>();
        carRb.centerOfMass = _centerOfMass;
        moveInput = 1.0f;
        carRb.interpolation = RigidbodyInterpolation.Interpolate;

        //carLights = GetComponent<CarLights>();
    }

    public void FixedUpdate()
    {
        GetInputs();
        AnimateWheels();
        if (clamprotation)
        {
            ClampRotationRigidbody();
        }

        Move();
        Steer();

    }

    public void SteerInput(float input)
    {
        steerInput = input;
    }
    void GetInputs()
    {
        // Force forward motion regardless of control mode
        moveInput = 1.0f;

        steerInput = Input.GetAxis("Horizontal");

     
        
    }

 


    void ClampRotationRigidbody()
    {
        Quaternion currentRot = carRb.rotation;
        Vector3 euler = currentRot.eulerAngles;

        float x = (euler.x > 180) ? euler.x - 360 : euler.x;
        float z = (euler.z > 180) ? euler.z - 360 : euler.z;
        float y = (euler.y > 180) ? euler.y - 360 : euler.y;

        float clampedX = Mathf.Clamp(x, -25f, 25f);
        float clampedZ = Mathf.Clamp(z, -25f, 25f);
        float clampedY = Mathf.Clamp(y, -25f, 25f);

        Quaternion targetRot = Quaternion.Euler(clampedX, clampedY, clampedZ);
        Quaternion newRot = Quaternion.Slerp(currentRot, targetRot, Time.fixedDeltaTime * 1f);
        carRb.MoveRotation(newRot);

        carRb.angularVelocity *= 0.5f;
    }





    void MaxSpeed()
    {
        Debug.Log(carRb.velocity.magnitude);
        if (carRb.velocity.magnitude > maxspeed)
        {
            carRb.velocity = carRb.velocity.normalized * maxspeed;
        }
    }

    void Move()
    {
        MaxSpeed();

      
        
        foreach (var wheel in wheels)
        {
            wheel.wheelCollider.motorTorque = 600 * maxAcceleration * Time.fixedDeltaTime;


        }
        
        
    }

    void Steer()
    {
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                var _steerAngle = steerInput * turnSensitivity * maxSteerAngle;
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, _steerAngle, 0.6f);
            }
        }
    }

    void AnimateWheels()
    {
        foreach (var wheel in wheels)
        {
            Quaternion rot;
            Vector3 pos;
            wheel.wheelCollider.GetWorldPose(out pos, out rot);
            wheel.wheelModel.transform.position = pos;
            wheel.wheelModel.transform.rotation = rot;
        }
    }

    [SerializeField] float explosionForce;
    private void OnCollisionEnter(Collision collision)
    {
        
        // Only affect certain layers (like obstacles)
        if (collision.gameObject.CompareTag("Obstacle"))
        {

            
            carRb.AddExplosionForce(explosionForce, collision.contacts[0].point, 5f, 1f, ForceMode.Impulse);

        }
    }

    private bool Checkpointtouched;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            
            score += 1;
            ScoreText.text = score.ToString();
            other.gameObject.SetActive(false);
            maxspeed += 1;
        }


    }
}
