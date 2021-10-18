using MLAPI;
using UnityEngine;

namespace HelloWorld
{
   public class HelloWorldManager : MonoBehaviour
   {

   /*********************
    * Makes the buttons on the screen??
    *********************/
      void OnGUI()
      {
         GUILayout.BeginArea(new Rect(10, 10, 300, 300));
         if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
         {
            StartButtons();
         }

         GUILayout.EndArea();
      }


     /*********************
    * This is the buttons displayed at initial start?
    *********************/
      static void StartButtons()
      {
         if (GUILayout.Button("Host")) NetworkManager.Singleton.StartHost();
         if (GUILayout.Button("Client")) NetworkManager.Singleton.StartClient();
         if (GUILayout.Button("Server")) NetworkManager.Singleton.StartServer();
      }


    /*********************
    * No idea
    *********************/
      static void StatusLabels()
      {
         var mode = NetworkManager.Singleton.IsHost ?
             "Host" : NetworkManager.Singleton.IsServer ? "Server" : "Client";

         GUILayout.Label("Transport: " +
             NetworkManager.Singleton.NetworkConfig.NetworkTransport.GetType().Name);
         GUILayout.Label("Mode: " + mode);
      }


    /*********************
    * If the game is started
    *********************/
      /*static void SubmitNewPosition()
      {                     // in line if statement,   if isServer, display "move" else "request position"
         if (GUILayout.Button(NetworkManager.Singleton.IsServer ? "Move" : "Request Position Change"))
         {
            // ___
            if (NetworkManager.Singleton.ConnectedClients.TryGetValue(NetworkManager.Singleton.LocalClientId,
                out var networkedClient))
            {
               var player = networkedClient.PlayerObject.GetComponent<HelloWorldPlayer>();
               if (player) 
               {
                  player.Move();
               }
            }
         }
      }//end of function*/
   }
}