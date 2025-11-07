using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCVehicles : MonoBehaviour
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
        AnimateWheels();
        Move();
        //Steer();

    }



    void MaxSpeed()
    {
        Debug.Log(carRb.velocity.magnitude);
        if (carRb.velocity.magnitude > 50)
        {
            carRb.velocity = carRb.velocity.normalized * maxspeed;
        }
    }


    void Move()
    {
        MaxSpeed();
        foreach (var wheel in wheels)
        {
            wheel.wheelCollider.motorTorque = 600 * maxAcceleration * Time.deltaTime;


        }
        

    }

/*    void Steer()
    {
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                var _steerAngle = steerInput * turnSensitivity * maxSteerAngle;
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, _steerAngle, 0.6f);
            }
        }
    }*/

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


   
}

