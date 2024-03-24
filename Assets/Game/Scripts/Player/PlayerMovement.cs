using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player

{
    public class PlayerMovement : MonoBehaviour
    {
        private FloatingJoystick _joystick;
        public FloatingJoystick Joystick
        {
            get => _joystick;
            set => _joystick = value;
        }

        public CharacterController controller;

        public float speed = 5f;
        public float gravity = -15f;

        Vector3 velocity;

        bool isGrounded;
        
        private float jumpHeight = 1.0f;
        private float gravityValue = -9.81f;

        private void Start()
        {
            controller = gameObject.GetComponent<CharacterController>();
        }

        void Update()
        {
            
            isGrounded = controller.isGrounded;
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = 0f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
               OnJump();
            }

        }
        
        public void OnJump()
        {
            Debug.Log(111);
            if (isGrounded)
            {
                Debug.Log(222);
                velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }
        }
    }
}