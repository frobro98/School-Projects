#include "Game.h"
#include "SceneManager.h"
#include "TimeManager.h"
#include "CameraController.h"
#include "Visualizer.h"

Game* Game::gmePtr = 0;


int Game::ScreenWidth()
{
	return gmePtr->screenWidth;
}

int Game::ScreenHeight()
{
	return gmePtr->screenHeight;
}

//-----------------------------------------------------------------------------
//  Game::Game()
//		Game Engine Constructor
//-----------------------------------------------------------------------------
Game::Game( const char * const windowName, int widthScreen, int heightScreen )
: Engine( windowName, widthScreen, heightScreen)
{
	printf("Game(): started\n");

	glfwSetWindowPos(this->window, 20, 30);

	gmePtr = this;
}

//-----------------------------------------------------------------------------
// Game::Initialize()
//		Allows the engine to perform any initialization it needs to before 
//      starting to run.  This is where it can query for any required services 
//      and load any non-graphic related content. 
//-----------------------------------------------------------------------------
void Game::Initialize()
{
	CameraController::initialize();
	initialize();
}

//-----------------------------------------------------------------------------
// Game::LoadContent()
//		Allows you to load all content needed for your engine,
//	    such as objects, graphics, etc.
//-----------------------------------------------------------------------------
void Game::LoadContent()
{
	loadUserContent();

	Visualizer::initialize();
}

//-----------------------------------------------------------------------------
// Game::Update()
//      Called once per frame, update data, tranformations, etc
//      Use this function to control process order
//      Input, AI, Physics, Animation, and Graphics
//-----------------------------------------------------------------------------
void Game::Update()
{
	SceneManager::Update();
	CameraController::updateCurrentCamera();
	TimeManager::update();	
}

//-----------------------------------------------------------------------------
// Game::Draw()
//		This function is called once per frame
//	    Use this for draw graphics to the screen.
//      Only do rendering here
//-----------------------------------------------------------------------------
void Game::Draw()
{ 
	Visualizer::render();
	SceneManager::Draw();
}

//-----------------------------------------------------------------------------
// Game::UnLoadContent()
//       unload content (resources loaded above)
//       unload all content that was loaded before the Engine Loop started
//       (also used to clean up whatever was created in Game::Initialize()  )
//-----------------------------------------------------------------------------
void Game::UnLoadContent()
{
	unloadUserContent();
	terminate();
}

// End of Game.cpp
