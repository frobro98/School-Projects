#include "Azul.h"
#include "AzulUnused.h"
#include "CameraMan.h"

//
//static void key_callback(GLFWwindow* window, int key, int scancode, int action, int mods)
//{
//	AZUL_UNUSED( scancode );
//	AZUL_UNUSED( mods );
//	KeyAction( window,  key,  action);
//}
//
//static void mouse_callback(GLFWwindow* window, int button, int action, int mods)
//{
//	AZUL_UNUSED( mods );
//	MouseAction( window,  button,  action);
//}
//
//static void cursor_callback(GLFWwindow* window, double x_pos, double y_pos)
//{
//	CursorPosition( window,  (float)x_pos,  (float)y_pos);
//}
//
//static void cursor_active_callback(GLFWwindow* window, int enter)
//{
//	CursorInView( window,  enter);
//}
//
//

//initialize the input callback system
void initInputInterface(GLFWwindow* window)
{
	//initializing keyboard
	glfwSetKeyCallback(window, 0);

	//initializing mouse
	glfwSetMouseButtonCallback(window, 0);
	glfwSetScrollCallback(window, 0);

	//init mouse cursor 
	glfwSetCursorPosCallback(window, 0);
	glfwSetCursorEnterCallback(window, 0);


	InputMan::Create( window );


}


void KeyAction(GLFWwindow* window, int key, int action)
{
	AZUL_UNUSED( window );
	AZUL_UNUSED( key );
	AZUL_UNUSED( action );
}

void MouseAction(GLFWwindow* window,int  button,int  action)
{
	AZUL_UNUSED( window );
	AZUL_UNUSED( button );
	AZUL_UNUSED( action );
}

void CursorPosition(GLFWwindow* window, float x_pos, float y_pos)
{
	AZUL_UNUSED( window );
	AZUL_UNUSED( x_pos );
	AZUL_UNUSED( y_pos );
}

void CursorInView(GLFWwindow* window, int enter)
{
	AZUL_UNUSED( window );
	AZUL_UNUSED( enter );
}



