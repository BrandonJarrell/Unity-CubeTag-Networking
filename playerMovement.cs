using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

public class playerMovement : NetworkBehaviour
{
   public float movementSpeed;
   public bool canMove;
   Rigidbody2D player;


   void Start()
   {

      //Fetch the Rigidbody component you attach from your GameObject
      player = this.gameObject.GetComponent<Rigidbody2D>();
      movementSpeed = 3;
      canMove = true;

   }

   // Update is called once per frame
   void Update()
   {


      /*/ UP
      if (Input.GetKey("w"))
         player.velocity = new Vector3(Input.GetAxis("Horizontal") * movementSpeed, Input.GetAxis("Vertical") * movementSpeed, 0);

      // DOWN
      if (Input.GetKey("s"))
         player.velocity = new Vector3(Input.GetAxis("Horizontal") * movementSpeed, Input.GetAxis("Vertical") * movementSpeed, 0);

      // LEFT
      if (Input.GetKey("a"))
         player.velocity = new Vector3(Input.GetAxis("Horizontal") * movementSpeed, Input.GetAxis("Vertical") * movementSpeed, 0);
      else

      // RIGHT
      if (Input.GetKey("d"))
         player.velocity = new Vector3(Input.GetAxis("Horizontal") * movementSpeed, Input.GetAxis("Vertical") * movementSpeed, 0);*/









      /***************************
      very simple input based on the UNITY INPUT SETTINGS
      ***************************/
      //Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal") * movementSpeed, Input.GetAxis("Vertical") * movementSpeed, 0);
      //player.velocity = m_Input;


      /**************************
      WASD INPUT TEMPLATE
      ***************************/
      /*
      if (Input.GetKey("w"))


      // DOWN
      if (Input.GetKey("s"))


      // LEFT
      if (Input.GetKey("a"))


      // RIGHT
      if (Input.GetKey("d"))
      */


      if (Input.GetKeyUp("space") && IsOwner)
         GetComponent<tagController>().easychangeIsItClientRpc();

      /*********************************
       CONSTANTLY ADDS A FORCE IN THE MOVEMENT DIRECTION
      ********************************/

      if (this.gameObject.GetComponent<tagController>().isIt && canMove)
      {
         Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal") * movementSpeed, Input.GetAxis("Vertical") * movementSpeed, 0);
         player.velocity = m_Input;

         // delete
         
      }
      else if (canMove)
      {
         
         // UP
          if (Input.GetKey("w"))
             player.AddForce(transform.up * (movementSpeed + 3));

          // DOWN
          if (Input.GetKey("s"))
             player.AddForce(transform.up * (-movementSpeed - 3));

          // LEFT
          if (Input.GetKey("a"))
             player.AddForce(transform.right * (-movementSpeed - 3));

          // RIGHT
          if (Input.GetKey("d"))
             player.AddForce(transform.right * (movementSpeed + 3));

          if (Input.GetKey("space"))
             player.drag = 1;

          // BRAKES
          if (Input.GetKeyUp("space") && IsLocalPlayer)
             GetComponent<tagController>().changeIsItClientRpc();
         //player.drag = 0;

      }





      /**************************
      SINGLE INPUT FOR INSTANT DIRECTION CHANGE
      **************************/
      /* // UP
       if (Input.GetKey("w"))
          player.velocity += transform.up * movementSpeed;

       // DOWN
       if (Input.GetKey("s"))
          player.velocity += transform.up * -movementSpeed;

       // LEFT
       if (Input.GetKey("a"))
          player.velocity += transform.right * -movementSpeed;
       else

       // RIGHT
       if (Input.GetKey("d"))
          player.velocity += transform.right * movementSpeed;*/

   }
}
