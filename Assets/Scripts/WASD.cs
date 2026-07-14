using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace Pacman
{
    public class WASD : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created

        public Animator anim;
        public Rigidbody rb;

        public KeyControl upKey;
        public KeyControl downKey;
        public KeyControl leftKey;
        public KeyControl rightKey;

        public int speed = 5;
    
        [Header("Movement Animation")]
        private float animationMultiplier = 5f;
        private float currentAnimSpeed = 0f;
        private float targetSpeed = 1f;

        void Start()
        {
            upKey = Keyboard.current.wKey;
            leftKey = Keyboard.current.aKey;
            rightKey = Keyboard.current.dKey;

        }

        // Update is called once per frame
        void Update()
        {
            if (rightKey.isPressed)
            {
                transform.Rotate(0, 1, 0);
                rb.linearVelocity = transform.forward*speed;
            }
            if (leftKey.isPressed)
            {
                transform.Rotate(0, -1, 0);
                rb.linearVelocity = transform.forward*speed;
            }
            if (upKey.isPressed)
            {
                rb.linearVelocity = transform.forward*speed;
            }
            else
            {
                rb.linearVelocity = new Vector3(0,0,0);
            }
            rb.angularVelocity = new Vector3(0, 0, 0);

            targetSpeed = rb.linearVelocity.normalized.magnitude;
        }

        void LateUpdate()
        {
            currentAnimSpeed = Mathf.Lerp(currentAnimSpeed, targetSpeed, animationMultiplier * Time.deltaTime);
            anim.SetFloat("MovementSpeed", currentAnimSpeed);
        }
    }

}
