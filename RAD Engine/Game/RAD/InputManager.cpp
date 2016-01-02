
#include <algorithm>

#include "InputManager.h"
#include "Inputable.h"

InputManager* InputManager::imInstance = 0;

InputManager::InputManager()
{
	keyboard = InputMan::GetKeyboard();
}

InputManager::~InputManager()
{
	while(!inputs.empty())
	{
		State* state = inputs.begin()->second;
		delete state;
		inputs.erase(inputs.begin());
	}
}

InputManager& InputManager::instance()
{
	if(imInstance == 0)
	{
		imInstance = new InputManager();
	}

	return *imInstance;

}

//--------------------Key Update-------------------------
void InputManager::State::update()
{
	bool currState = InputManager::getKeyState(regKey);

	if(currState)
	{
		std::list<Inputable*>::const_iterator it = this->regPressed.cbegin();
		while(it != this->regPressed.cend())
		{
			(*it)->keyDown(this->regKey, InputManager::getKeyState(SHIFT_KEY), InputManager::getKeyState(ALT_KEY), InputManager::getKeyState(CTRL_KEY));

			it++;
		}
	}
	else
	{
		std::list<Inputable*>::const_iterator it = this->regPressed.cbegin();
		while(it != this->regPressed.cend())
		{
			(*it)->keyReleased(this->regKey, InputManager::getKeyState(SHIFT_KEY), InputManager::getKeyState(ALT_KEY), InputManager::getKeyState(CTRL_KEY));

			it++;
		}
	}

	// Key is Pressed
	if(!prevState && currState)
	{
		std::list<Inputable*>::const_iterator it = this->regPressed.cbegin();
		while(it != this->regPressed.cend())
		{
			(*it)->keyPressed(this->regKey, InputManager::getKeyState(SHIFT_KEY), InputManager::getKeyState(ALT_KEY), InputManager::getKeyState(CTRL_KEY));

			it++;
		}
	}
	// Key is Released
	else if(prevState && !currState)
	{
		std::list<Inputable*>::iterator it = this->regReleased.begin();
		while(it != this->regReleased.end())
		{
			(*it)->keyReleased(this->regKey, InputManager::getKeyState(SHIFT_KEY), InputManager::getKeyState(ALT_KEY), InputManager::getKeyState(CTRL_KEY));

			it++;
		}
	}

	prevState = currState;
}
//-------------------------------------------------------

void InputManager::update()
{
	instance().Update();
}

void InputManager::Update()
{
	std::map<Inputs, State*>::const_iterator it = inputs.cbegin();
	while(it != inputs.cend())
	{
		it->second->update();

		it++;
	}
	
}
//--------------------SINGLETON METHODS-----------------------
bool InputManager::getKeyState(Inputs i)
{
	return instance().GetKeyState(i);
}

bool InputManager::GetKeyState(Inputs i)
{
	return keyboard->GetKeyState((AZUL_KEY)i);
}

//bool InputManager::isKeyPressed(Inputs input)
//{
//	return instance().IsKeyPressed(input);
//}
//
//bool InputManager::isKeyReleased(Inputs input)
//{
//	return instance().IsKeyReleased(input);
//}
//
//bool InputManager::isKeyDown(Inputs input)
//{
//	return instance().IsKeyDown(input);
//}
//
//bool InputManager::isKeyUp(Inputs input)
//{
//	return instance().IsKeyUp(input);
//}
//
//bool InputManager::IsKeyPressed(Inputs input)
//{
//	const Key* k = inputs.find(input);
//	int elem = 0;
//	bool found = false;
//	bool pressed = false;
//
//	for(unsigned i = 0; i < k->states.size(); i++)
//	{
//		if(k->states[elem].state == KEY_STATES::PRESSED)
//		{
//			found = true;
//			break;
//		}
//		else
//		{
//			++elem;
//		}
//	}
//
//	if(found)
//	{
//		pressed = k->states[elem].active;
//	}
//
//	return pressed;
//}
//
//bool InputManager::IsKeyReleased(Inputs input)
//{
//	
//	const Key* k = inputs.find(input);
//	int elem = 0;
//	bool found = false;
//	bool released = false;
//
//	for(unsigned i = 0; i < k->states.size(); i++)
//	{
//		if(k->states[elem].state == KEY_STATES::RELEASED)
//		{
//			found = true;
//			break;
//		}
//		else
//		{
//			++elem;
//		}
//	}
//
//	if(found)
//	{
//		released = k->states[elem].active;
//	}
//
//	return released;
//}
//
//bool InputManager::IsKeyDown(Inputs input)
//{
//	input;
//	//return getKeyState(k->regKey);
//	return false;
//}
//
//bool InputManager::IsKeyUp(Inputs input)
//{
//	input;
//	//return !getKeyState(k->regKey);
//	return false;
//}

void InputManager::registerInput(Inputable* in, Inputs i, KEY_STATES state)
{
	instance().RegisterInput(in, i, state);
}

void InputManager::RegisterInput(Inputable* in, Inputs i, KEY_STATES state)
{
	std::map<Inputs, State*>::iterator it = inputs.find(i);
	if(it != inputs.end())
	{
		State* key = it->second;
		key->registerInputable(in, state);
	}
	else
	{
		State* key = new State(in, i, state);
		inputs[i] = key;
	}
}

void InputManager::deregisterInput(Inputable* in, Inputs i, KEY_STATES state)
{
	instance().DeregisterInput(in, i, state);
}

void InputManager::DeregisterInput(Inputable* in, Inputs i, KEY_STATES state)
{
	State* key = inputs[i];
	key->deregisterInputable(in, state);

}



