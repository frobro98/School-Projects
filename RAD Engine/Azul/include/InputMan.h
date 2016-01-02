#ifndef INPUT_MAN_H
#define INPUT_MAN_H

#include "Azul.h"

class InputMan
{
public:
	static void Create( GLFWwindow * );
	static Keyboard *GetKeyboard();
	static Mouse *GetMouse();

	~InputMan();

private:
	static InputMan *privInstance();
	static void privCreate(GLFWwindow *);
	InputMan(GLFWwindow	*);
	
	// Data
	static InputMan *pInputMan;
	GLFWwindow		*pWindow;
	Keyboard		*pKeyboard;
	Mouse			*pMouse;
};
#endif