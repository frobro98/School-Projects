#include "Azul.h"
#include "PyramidCreateModel.h"
#include "SphereModel.h"
#include "BoxModel.h"


//------------------------------------------------------------------
// Engine::Run()
//		This is the internal game loop that the engine runs on.
//------------------------------------------------------------------
void Engine::Run()
{
	Initialize();
	this->privPostInitialize();

	LoadContent();


	// close if 1 
	while( !glfwWindowShouldClose(window) && !EscapeTriggerFunc() )
	{
		if( UpdateTriggerFunc() )
		{
			Update();
		}

		ClearBufferFunc();
		Draw();
		this->privPostDraw();
	}

	UnLoadContent();
	this->privPostUnload();
}

//------------------------------------------------------------------
// Engine::privPostUnload()
//		
//------------------------------------------------------------------
void Engine::privPostUnload()
{
	GpuTexture::Unload();
	GpuModel::Unload();

}

//------------------------------------------------------------------
// Engine::privPreInitialize()
//		
//------------------------------------------------------------------
void Engine::privPostInitialize()
{
	// Internal model load (do not touch)
	pyramidCreateModel();
	sphereCreateModel();
	boxCreateModel();

	// Following can be overloaded in game;
	glClearColor(0.7f, 0.7f, 0.9f, 1.0f );
	glEnable(GL_DEPTH_TEST);
    glEnable(GL_CULL_FACE);
    glCullFace(GL_BACK);
	this->ClearBufferFunc();

}

//------------------------------------------------------------------
// Engine::UpdateTriggerFunc()
// This function is intended for users to control the update function
// for specialized debugging, such as freeze frame controlled by an 
// input key
//------------------------------------------------------------------
bool Engine::UpdateTriggerFunc()
{
	return true;
}

//------------------------------------------------------------------
// Engine::UpdateTriggerFunc()
// This function is intended for users to control the update function
// for specialized debugging, such as freeze frame controlled by an 
// input key
//------------------------------------------------------------------
bool Engine::EscapeTriggerFunc()
{
	Keyboard *key = InputMan::GetKeyboard();

	bool value = false;

	if( key->GetKeyState( AZUL_KEY::KEY_ESCAPE ) )
	{
		value = true;
	}

	return value;
}

//------------------------------------------------------------------
// Engine::ClearBufferFunc()
// Allows user to change the way the clear buffer function works
//------------------------------------------------------------------
void Engine::ClearBufferFunc()
{
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT | GL_STENCIL_BUFFER_BIT);
}

//------------------------------------------------------------------
// Engine::privPostDraw()
//		
//------------------------------------------------------------------
void Engine::privPostDraw()
{
	glfwSwapBuffers(window);
	glfwPollEvents();
}

//------------------------------------------------------------------
// Engine::Engine( windowName, screenWidth, screenHeight)
//		
//------------------------------------------------------------------
Engine::Engine(const char * const windowName, int _screenWidth, int _screenHeight)
	: screenWidth(_screenWidth), screenHeight(_screenHeight)
{
	this->window = privCreateGraphicsWindow( windowName, this->screenWidth, this->screenHeight );
	initInputInterface(this->window);	
	ShaderMan::Instance()->InitializeStockShaders();
}

//------------------------------------------------------------------
// Engine::~Engine( )
//		destructor
//------------------------------------------------------------------
Engine::~Engine()
{
	glfwDestroyWindow(window);
	glfwTerminate();
}

//------------------------------------------------------------------
// Engine::privCreateGraphicsWindow()
//		private function that creates the window using the glfw calls
//------------------------------------------------------------------
GLFWwindow* Engine::privCreateGraphicsWindow( const char* windowName, const int Width,const int Height )
{
	// Set the display mode
	if( !glfwInit() )
	{
		exit(EXIT_FAILURE);
	}

	// the first callback can be replaced by glfwGetPrimaryMonitor() which with some tweaks allows to choose monitor of display
	//creating locally but will pass it outside so no problem with this pointer creating a leak
	GLFWwindow* window = glfwCreateWindow(Width, Height, windowName , NULL, NULL);
	
	if (!window)
	{
		glfwTerminate();
		exit(EXIT_FAILURE);
	}

	glfwMakeContextCurrent(window);

	glewExperimental = GL_TRUE;
	//necessary goo of glfw
	GLenum err = glewInit();
	if (GLEW_OK != err)
	{
		fprintf(stderr, "GLEW Error: %s\n", glewGetErrorString(err));
		exit(EXIT_FAILURE);
		// return error
	}

	return window;
}


// End of Engine.cpp