#include <assert.h>
#include "Azul.h"


InputMan *InputMan::pInputMan = 0;

void InputMan::Create( GLFWwindow *_window )
{
	assert(_window);
	InputMan::privCreate( _window);
}

InputMan::InputMan(GLFWwindow *window )
{
	assert(window);
	this->pWindow = window;

	this->pKeyboard = new Keyboard( this->pWindow );
	assert(this->pKeyboard);

	this->pMouse = new Mouse( this->pWindow );
	assert(this->pMouse);
}

void InputMan::privCreate( GLFWwindow *_window  )
{
	InputMan::pInputMan = new InputMan( _window );
}

InputMan::~InputMan()
{
	delete this->pKeyboard;
}

Keyboard *InputMan::GetKeyboard()
{
	InputMan *pInputMan = InputMan::privInstance();
	return pInputMan->pKeyboard;
}

Mouse *InputMan::GetMouse()
{
	InputMan *pInputMan = InputMan::privInstance();
	return pInputMan->pMouse;
}


InputMan *InputMan::privInstance()
{
	assert( pInputMan );
	return pInputMan;
}

