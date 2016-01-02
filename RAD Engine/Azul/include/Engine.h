#ifndef ENGINE_H
#define ENGINE_H


//////////////////
// Engine
//		Abstract class that Azul Engine inherits from
// there are 5 abstract functions that Azul Engine must define:
//  --- Initialize, LoadContent, Update, Draw, UnLoadContent
//
// - Engine::Run()
//      This will run a game loop calling Initialize, LoadContent
//   (loop) Update and Draw, then upon exiting call UnloadContent
//
///////////////////
class Engine
{
public:
	Engine(const char * const WindowName, int screenWidth, int screenHeight);
	~Engine();

	// required overloading
	virtual void Initialize() = 0;
	virtual void LoadContent()= 0;
	virtual void Update()= 0;
	virtual void Draw()= 0;
	virtual void UnLoadContent()= 0;

	// optional overloading
	virtual bool UpdateTriggerFunc();
	virtual void ClearBufferFunc();
	virtual bool EscapeTriggerFunc();

	void Run();

protected:
	GLFWwindow	*window;
	bool		joystickActive;
	int			screenWidth;
	int			screenHeight;

private:
	// force to use the appropriate constructor
	Engine();

	// private methods:
	GLFWwindow* privCreateGraphicsWindow( const char* windowName, const int Width,const int Height );
	void privPostDraw();
	void privPostInitialize();
	void privPostUnload();
};


#endif