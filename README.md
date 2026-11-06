# INFR 3110 Make Up Assignment
---
### Name : Temiloluwa Awosiyan
### Student Number : 100977745
---
# Object Oriented Programming
---
### Description
<!-- Briefly describe the classes, their relationships, and how object-oriented
programming principles are demonstrated in your implementation. -->

Game contains:
PlayerController, which controls the snake, Game Manager, which handles win / loss conditions and progress towards them, 
AppleSpawner, which creates new apples at a position designated by the game manager
ScoreManager, which tracks the number of apples eaten
SnakeBody, which inherits from player controller, to mimick snake fucntionality
## UML Diagram
<!-- Attach your UML diagram here -->

<img width="1700" height="2200" alt="UML GEDI Makeup (1)-1" src="https://github.com/user-attachments/assets/20c7956e-5c5a-4e97-996c-ae9be4b9db91" />


---
# Singleton Pattern
---
### Purpose
<!-- Explain why the Singleton pattern is appropriate for this particular system.
-->
Game manager is a singleton as multiple different scripts need to have a reference to it, as well as the fact that there should only be one 
source of truth for the current score in the game.
### Implementation
<!--Describe how the Singleton pattern is implemented in your project. -->

Game manager contains a static public variable that any class can access in order to utulize game manager functionality.
---
# Factory Pattern
---
### Purpose
<!-- Explain why the Factory pattern is appropriate for this particular system. -->
There is an unbounded amount of apples that can be spawned over the course of a playthrough, so it is important that there is a
script dedicated to handling this. Single script responsibility means that whatever script is handling the spawning should
only handle the spawning. A factory is important here as it helps to maintain single script dependcy, as well as provide an extendible platform for more spawning functionality without having to deal with dependencies if the spawning was tied to other scripts.
### Implementation
<!-- Describe how the Factory pattern is implemented in your project. -->

AppleSpawner contains the ability to create a duplicate of a prefab Apple at runtime as many times as needed over the course of the 
playsession, with GameManager controlling when and where the apple is placed in the scene
---
# References
---
<!-- Identify sources used to create any gameplay logic or programming pattern
implementations. -->
