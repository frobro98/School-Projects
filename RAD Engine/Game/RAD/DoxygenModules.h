/** \defgroup RADAPI RAD-API
\brief Methods availible for use by the user of RAD
*/

/** \defgroup GAMEOBJ GameObject
\ingroup RADAPI
\brief The base class for all of the user-created GameObjects.
*/

/** \defgroup AUTOEVENTS Base Events
\ingroup GAMEOBJ
\brief Events that the GameObject has by default. The user does not
have to register to receive the benefits of these events.
*/

/** \defgroup UPDATEABLE Updateable
\ingroup AUTOEVENTS
\brief Allows the GameObject class to have a connection to the Update loop. 
All derived classes of Updateable will be hookedbup to the Update loop as well.

*/

/** \defgroup DRAWABLE Drawable
\ingroup AUTOEVENTS
\brief Allows the GameObject class to have a connection to the Draw loop.
All derived classes of Drawable will be hooked up to the draw loop as well.

Inputs are the only way to get input from the keyboard. Once a class is derived from

*/

/** \defgroup INPUTABLE Inputable
\ingroup GAMEOBJ
\brief Allows the GameObject to register for and receive input from the keyboard.
Any class that derives from Inputable is able to receive input from the keyboard.
*/

/** \defgroup ALARMABLE Alarmable
\ingroup GAMEOBJ
\brief Hooks the GameObject class to the Alarm System. Any derived class gets to use
Alarms as well.

The Alarmable class gives you access to 1 of 5 alarms. The only way to set up alarms 
is to go through the AlarmManager.

Here is an example of setting up and using alarms:

	\code
	SpaceShip::SpaceShip()
	{
		// CODE TO SET UP CLASS

		AlarmManager::registerAlarm(this, ALARM_1, 2.0f); // Sets Alarm 1 to go off in 2 seconds
	}

	void SpaceShip::Alarm1()
	{
		// Code for Alarm 1
	}
	\endcode

 
*/

/** \defgroup COLLIDABLE Collidable
\ingroup GAMEOBJ
\brief This allows the GameObject to collide and be collided with. Any class that derives
from Collidable has the ability to collide as well.

To set up collisions with user-defined classes, you need to register through the CollisionManager.
You set each collision pair that you would like to test in the user-defined initialize() method
in the user's Scene.

Here is an example of registering collision pairs for a scene

	\code
	Level::initialize()
	{
		// Set up for the Scene

		CollisionManager::setCollisionPair<SpaceShip, Cottage>()
	}
	\endcode

Each Game Object needs to individually register with its respective 
Collidable Group plus setting up the collision model as well.

Here is an example of an individual Collidable object registering with its Collidable Group

	\code
	SpaceShip::SpaceShip()
	{
		// Class set up

		CollisionGroup<SpaceShip>::registerCollision(this); // Registers SpaceShip for collision
	}
	\endcode
*/

/** \defgroup DESTROYABLE Destroyable
\ingroup GAMEOBJ
\brief This class allows a GameObject to be destroyed or reused by the user. Any object that derives from 
Destroyable will have the ability to get destroyed in-game.

*/

/** \defgroup ASSETS Asset Management
\ingroup RADAPI
\brief External resources will be loaded and managed for the game
 */
 
 /** \defgroup SCENE Scene
 \ingroup RADAPI
 \brief The Scene class defines to space you see in the window. All GameObjects,
and all of the base classes of GameObject, will exist in a Scene. 

Anything you would like to be on the screen must derive from Scene. Any type of 
level, splash screen, menu, etc. will be derived from Scene. The only thing that
the dervied classes will have to implement is Scene::initialize. This method allows
the user to control the start of a Scene. Creating initial GameObjects as well as
registering collision pair testing is done inside this method.
*/

/** \mainpage The RAD Azul Derivation Engine

RAD is a basic 3D game engine in C++. RAD is an extension of DePaul University's Azul framework.

\section FEATURES Features
RAD provides its users with the following:
	- An asset management system for managing external textures and models
	- GameObject and Scene base classes for derviving levels and game objects
	- Multiple components that can be derived from to give user-specified objects
	specific, game-related behaviors
		* Through Updateable and Drawable, an object gains access to the 
		in-engine update and draw loop
		* Through Collidable, an object will be hooked up to the built-in
		pairwise collision system.
		* Through Alarmable, an object will be able to set its own time-based,
		alarm events
		* Through Inputable, an object gains access to input events through the 
		keyboard

The design of this engine is minimal in nature, but will grow as time goes by. New features will
be added as well as new systems.

*/
