using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Messaging;

public class tagController : NetworkBehaviour
{

   public bool alreadyCalled;
   public bool isIt;

   // Start is called before the first frame update
   void Start()
   {
      isIt = false;
      alreadyCalled = false;
   }



   /****************************
    *  TRIGGER
    ****************************/
   private void OnTriggerEnter2D(Collider2D other)
   {

      if ((other.tag == "Player" && this.isIt))
      {
         other.GetComponent<tagController>().changeIsItClientRpc();
         changeIsItClientRpc();
      }
   }

   [ClientRpc]
   public void easychangeIsItClientRpc()
   {
      if (!isIt)
      {
         isIt = true;
         GetComponent<Renderer>().material.SetColor("_Color", Color.red);
      }
      else
      {
         isIt = false;
         GetComponent<Renderer>().material.SetColor("_Color", Color.white);
      }
   }

   [ClientRpc]
   public void changeIsItClientRpc()
   {
      if (alreadyCalled)
      {
         print("has been called");
         StartCoroutine(changeCalled());
         return;
      }
      alreadyCalled = true;
      print("hasnt been called");


      if (!this.isIt)
      {
         this.isIt = false;
         GetComponent<playerMovement>().canMove = false;
         GetComponent<Renderer>().material.SetColor("_Color", Color.red);
         StartCoroutine(ableToTagDelay());
      }
      else
      {
         this.isIt = false;
         GetComponent<Renderer>().material.SetColor("_Color", Color.white);
      }
   }

   IEnumerator changeCalled()
   {
      //Wait for the specified delay time before continuing.
      yield return new WaitForSeconds(1f);

      alreadyCalled = false;
   }

   IEnumerator ableToTagDelay()
   {
      //Wait for the specified delay time before continuing.
      yield return new WaitForSeconds(2f);

      //Do the action after the delay time has finished.
      testClientRpc();
   }

   [ClientRpc]
   public void testClientRpc()
   {
      GetComponent<playerMovement>().canMove = true;
      GetComponent<tagController>().isIt = true;

   }
}
