

#ifndef INPUTMANAGER_H
#define INPUTMANAGER_H

#include <list>
#include <map>

#include "InputMan.h"

// forward declaration
class Inputable;
enum Inputs;


// Wrapper for the AZUL_KEY enum
// Wanted to have my own enums

// The 4 possible states for the Keyboard
enum KEY_STATES
{
	PRESSED,
	RELEASED,
	DOWN,
	UP
};




// Manages the registration of different keys
// and updates the state of those registered
// keys every frame
class InputManager
{
public:
	// ********* Make this private to restore the singleton *********************
	

	// ********************* MAKE STATIC FOR SINGLETON **************************
	static bool getKeyState(Inputs input);

	/**
	 \brief Registers Inputable objects for receiving requested input events
	 from specific keys on the keyboard.
	
	 \param inputObj				Inputable object.
	 \param	input					The input key.
	 \param	state					The state of the key.

	 \ingroup INPUTABLE
	 */
	static void registerInput(Inputable* inputObj, Inputs input, KEY_STATES state);

	/**
	 \brief Deregisters Inputable objects from receiving requested events from 
	 the key that the Inputable object was registered to.
	
	 \param inputObj				Inputable object.
	 \param	input					The input key.
	 \param	state					The state of the key.

	 \ingroup INPUTABLE
	 */
	static void deregisterInput(Inputable* inputObj, Inputs input, KEY_STATES state);

	void update();
	// **************************************************************************

private:
	InputManager();
	~InputManager();
	InputManager(const InputManager& im);
	const InputManager operator=(const InputManager& im);

// A key class that holds what key it is
// and its previous state
	class State
	{
	public:



		State(Inputable* in, Inputs input, KEY_STATES state)
		{
			regKey = input;
			prevState = false;
			if(state == KEY_STATES::PRESSED)
			{
				regPressed.push_back(in);
			}
			else if(state == KEY_STATES::RELEASED)
			{
				regReleased.push_back(in);
			}
		}

		~State()
		{
			regPressed.clear();
			regReleased.clear();
		}
		
		void registerInputable(Inputable* input, KEY_STATES state)
		{
			if(state == KEY_STATES::PRESSED)
				regPressed.push_back(input);
			else if(state == KEY_STATES::RELEASED)
				regReleased.push_back(input);
		}
		void deregisterInputable(Inputable* input, KEY_STATES state)
		{
			if(state == KEY_STATES::PRESSED)
				regPressed.remove(input);
			else if(state == KEY_STATES::RELEASED)
				regReleased.remove(input);
		}

		void update();

		Inputs regKey;
		std::list<Inputable*> regPressed;
		std::list<Inputable*> regReleased;
		bool prevState;
	
	};

	// Helper wrapper of Azul's GetKeyState(AZUL_KEY k)
	bool GetKeyState(Inputs input);

	// A pointer to the keyboard
	Keyboard* keyboard;
	// A list of registered key inputs
	std::map<Inputs, State*> inputs;

	//-------------------------------------

	// Registers input
	void RegisterInput(Inputable* in, Inputs input, KEY_STATES state);
	// Deregisters input
	void DeregisterInput(Inputable* in, Inputs input, KEY_STATES state);
	// Updates all of the registered inputs
	void Update();

	// returns the singleton instance of
	// InputManager
	static InputManager* imInstance;
	static InputManager& instance();

	friend class Scene;

};


#endif // INPUTMANAGER_H