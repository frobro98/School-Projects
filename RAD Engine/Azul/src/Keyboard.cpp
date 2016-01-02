#include <assert.h>
#include "Azul.h"

Keyboard::Keyboard(GLFWwindow	*_window)
	: window(_window)
{
	assert(_window);
}

// Use this to read keyboard
bool Keyboard::GetKeyState( AZUL_KEY key)
{
	bool value;

	if( glfwGetKey(this->window, key) == GLFW_PRESS )
	{
		value = true;
	}
	else
	{
		value = false;
	}
	return value;
}
