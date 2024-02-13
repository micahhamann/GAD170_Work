using System.Collections;
using UnityEngine;

namespace SAE.GAD170.WeekEleven
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        // These variables (visible in the inspector) are for you to set up to match the right feel
        public float speed = 12f;
        public float speedH = 2.0f;
        public float speedV = 2.0f;
        public float yaw = 0.0f;
        public float pitch = 0.0f;

        // This must be linked to the object that has the "Character Controller" in the inspector. You may need to add this component to the object
        public CharacterController controller;
        private Vector3 velocity;

        // Customisable gravity
        public float gravity = -20f;

        // Tells the script how far to keep the object off the ground
        public float groundDistance = 0.4f;

        // So the script knows if you can jump!
        private bool isGrounded;

        // How high the player can jump
        public float jumpHeight = 2f;

        public Animator animator;

        public Transform characterModel;

        private float startSpeed;

        public bool hasWon = false;

        float startHeight = 2.2f;
        float modelCharacterHeight = 0.9f;
        CapsuleCollider characterCollider;

        private void Start()
        {
            // If the variable "controller" is empty...
            if (controller == null)
            {
                // ...then this searches the components on the gameobject and gets a reference to the CharacterController class
                controller = GetComponent<CharacterController>();
            }

            // get reference to the capsual collider
            characterCollider = null;
            // set the start speed to be our current speed value this will be used for our crouching
            startSpeed = 0;
        }

        private void Update()
        {
            if (hasWon)
            {
                // if we have won, let's not allow anything else to happen and just return out of the function
                Win();
                return;
            }
            else
            {
                // These lines let the script rotate the player based on the mouse moving
                yaw += speedH * Input.GetAxis("Mouse X");
                pitch -= speedV * Input.GetAxis("Mouse Y");

                // Get the Left/Right and Forward/Back values of the input being used (WASD, Joystick etc.)
                float x = Input.GetAxis("Horizontal");
                float z = Input.GetAxis("Vertical");

                // flip the character model
                if (x > 0)
                {
                    // so here we want to rotate the characters model to 90 on the y axis.
                    characterModel.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else if (x < 0)
                {
                    // so here we want to rotate the characters model to 270 on the y axis.
                    characterModel.transform.rotation = Quaternion.Euler(0, 0, 0);
                }


                // Let the player jump if they are on the ground and they press the jump button
                if (Input.GetButtonDown("Jump") && isGrounded)
                {
                    velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
                    // so here we want to set the IsJumping animation to true in the animator.
                  
                }


                // This is stealing the data about the player being on the ground from the character controller
                isGrounded = controller.isGrounded;

                if (isGrounded && velocity.y < 0)
                {
                    velocity.y = -2f;
                    // so here we want to set the IsJumping animation to false in the animator.

                }

                // This fakes gravity!
                velocity.y += gravity * Time.deltaTime;

                // This takes the Left/Right and Forward/Back values to build a vector
                Vector3 move = transform.right * x;


                // the magnitude is the length of the vector, i.e. if it's greater than 0, we must be moving
                float moveVelocity = move.magnitude;
                // here we want to set the MovementVelocity of our animator to use the current movevelocity above.
                

                // Finally, it applies that vector it just made to the character
                controller.Move(move * speed * Time.deltaTime + velocity * Time.deltaTime);

                // we now want to call our crouch function to check if we should crouch.
               
            }
        }

        public void Win()
        {
            // here we just setting our velocity to 0 so we cancel out our movement.
            velocity = Vector3.zero;
            controller.Move(Vector3.zero);
            isGrounded = true;
            // set the animator bool "HasWon" to be true 

            // here let's set the rotation of our character model to face the camera when it's triggered, so 180 on the y axis.
            characterModel.transform.rotation = Quaternion.Euler(0, 0, 0);
            // dont forget to set hasWon to true.

        }

       
        void Crouch()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                // here we want to set the IsCrouching parameter of our animator to true.
                
                // here we want to half our move speed so it feels slower
                

                // we need to do some specific instruction to make the colliders work if we are crouching these next lines are adjusting the model + moving centres of the colliders
                characterModel.transform.localPosition = new Vector3(characterModel.transform.localPosition.x, 0, characterModel.transform.localPosition.z);
                controller.center = new Vector3(0, 0.5f, 0);
                characterCollider.center = new Vector3(0, 0.5f, 0);


                // but here we need to access both the character controller and it's height, as well as the characterCollider and it's height and half them.
                           
            }
            else if (Input.GetKeyUp(KeyCode.C))
            {
                // here we want to set the IsCrouching parameter of our animator to false.

                // we should set our speed back to our start speed that we stored in start.


                // here we are basically reverting back the halfing we did when we crouched, i've done the model and colliders centers for you.
                controller.center = new Vector3(0, 0f, 0);
                characterCollider.center = new Vector3(0, 0, 0);
                characterModel.transform.localPosition = new Vector3(characterModel.transform.localPosition.x, -modelCharacterHeight, characterModel.transform.localPosition.z);
                
                // here let's reset both the controllers height, and the character colliders height to the start height value.
 
            }
        }

    }
}