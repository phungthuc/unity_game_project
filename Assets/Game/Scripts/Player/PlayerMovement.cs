using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

        public UnityEvent PlayerMoved;
        public UnityEvent PlayerStoped;

        public CharacterController controller;
        
        public Animator animator;

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
            Move();
        }
        
        public void OnJump()
        {
            if (isGrounded)
            {
                velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }
        }

        private void Move()
        {
            isGrounded = controller.isGrounded;
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = 0f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            
            if (x != 0 || z != 0)
            {
                Debug.Log(123);
                animator.SetBool("Walk", true);
                animator.SetBool("Stop", false);
                PlayerMoved.Invoke();
            }
            else if (x == 0 && z == 0)
            {
                animator.SetBool("Walk", false);
                animator.SetBool("Stop", true);
                PlayerStoped.Invoke();
            }

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnJump();
            }
        }
    }
}