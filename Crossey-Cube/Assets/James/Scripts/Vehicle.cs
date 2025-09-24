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
    public TextMeshProUGUI Score;

    private Rigidbody carRb;
    
    /*
        private CarLights carLights;
    */
    public void Start()
    {
        carRb = GetComponent<Rigidbody>();
        carRb.centerOfMass = _centerOfMass;
        moveInput = 1.0f;

       /* carLights = GetComponent<CarLights>();*/
    }

    public void FixedUpdate()
    {
        GetInputs();
        AnimateWheels();
        ClampRotationRigidbody();
        /*WheelEffects();*/
    }

    void LateUpdate()
    {
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

        /*// Optional: keep steering input if using keyboard
        if (control == ControlMode.Keyboard)
        {
            
        }*/
    }

   /* private float currentXRotation;
    [SerializeField] float minXRotation;
    [SerializeField] float maxXRotation;


    void rotationClamp()
    {

        Quaternion currentXRotation = carRb.rotation;

        float clampedX = Mathf.Clamp(0, -10f, 10f);



        //Quaternion newRot = Quaternion.Slerp(currentXRotation)

        currentXRotation = Mathf.Clamp(currentXRotation,  , maxXRotation);

        if (carRb.MoveRotation.)
        {

        }
        
        carRb.MoveRotation(clampedX



        carRb.maxAngularVelocity = maxXRotation;
    }*/



    void ClampRotationRigidbody()
    {
        Quaternion currentRot = carRb.rotation;
        Vector3 euler = currentRot.eulerAngles;

        float x = (euler.x > 180) ? euler.x - 360 : euler.x;
        float z = (euler.z > 180) ? euler.z - 360 : euler.z;

        float clampedX = Mathf.Clamp(x, -10f, 10f);
        float clampedZ = Mathf.Clamp(z, -10f, 10f);

        Quaternion targetRot = Quaternion.Euler(clampedX, euler.y, clampedZ);
        Quaternion newRot = Quaternion.Slerp(currentRot, targetRot, Time.fixedDeltaTime * 5f);
        carRb.MoveRotation(newRot);

        carRb.angularVelocity *= 0.5f;
    }







    void Move()
    {
        foreach (var wheel in wheels)
        {
            wheel.wheelCollider.motorTorque = 600 * maxAcceleration * Time.deltaTime;

           
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
/*
    void WheelEffects()
    {
        foreach (var wheel in wheels)
        {
            //var dirtParticleMainSettings = wheel.smokeParticle.main;

            if (Input.GetKey(KeyCode.Space) && wheel.axel == Axel.Rear && wheel.wheelCollider.isGrounded == true && carRb.velocity.magnitude >= 10.0f)
            {
                wheel.wheelEffectObj.GetComponentInChildren<TrailRenderer>().emitting = true;
                wheel.smokeParticle.Emit(1);
            }
            else
            {
                wheel.wheelEffectObj.GetComponentInChildren<TrailRenderer>().emitting = false;
            }
        }
    }*/
}
