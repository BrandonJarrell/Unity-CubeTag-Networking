# Overview

This project's purpose was to teach myself how to connect game clients and even set up a dedicated server for any future idea's I have.
Learning how to network games is something I've always wanted to do because I hate single player games and I need to know how to do this is I'm ever to make my dream game

The game is very simple, it's just cubes playing tag with a small twist. The goal is for this to be ran on any Web Browser and connect to a dedicated server I could run anywhere. Every player cube is spawned on each client, the physics runs on every client but the positions are constantly updated.  When a function needs to happen, it is called on every client's version of that game object thus it appears the same to everyone. The game starts with 3 buttons, these are just standard button templates, but they are connected to call the host, client and server options. They currntly do not have a method of inputting a IP address to connect to, but this was my setback once I realized WebGL doesn't accept hosting of servers quite like a real machine application do.

I REALLY wanted to learn how to network a game. I have a vision of my dream game and it must have multiplayer to play with my brothers and friends, this was a simple proof of concept that I can learn how to network clients together and that it's very managable.

[Quick Demonstration Of Software](https://youtu.be/9gI1GtWZBRg)

# Network Communication

I was using Unity's new MLAPI format for networking which allowed the client to connect through tunnels to a IP address. Each client can select to be a server, host, or a client. I primarily used the client/server model. Every client connects to the host.

TCP was used, this is done through the API's reliable methods. 

Each client has a serialized network variables and functions, this Unity's RPC (Remote Procedure Calls). This basically converts the variable to network owned variable. The networked functions are what I defined, allowing for one client to call another clients functions.

# Development Environment

Unity

Visual Studio - C#

# Useful Websites

[Using Unity MLAPI (Youtube)](https://www.youtube.com/watch?v=qJMXv5J4wf4&list=PLbxeTux6kwSAseRmJeCyvkANHsI16PoM6&index=1)

[Unity MLAPI Documentation](https://docs-multiplayer.unity3d.com/docs/getting-started/about/index.html)

# Future Work

* Add IP address Input, this will allow connection with anyone hosting
* Create a version of the game that only runs as a dedicated server that I could run on a Raspberry Pi, allowing anyone to connect through a web browser with the game files.
* Research other methods of similating physics or faster networking. The game physics and collision can look weird sometimes. 

![image of game](https://github.com/KoddakJrell/Networking/blob/main/Screenshot%20(318).png)
