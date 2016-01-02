#ifndef GAME_H
#define GAME_H

#include "Azul.h"


class Game : public Engine
{

public:
	Game( const char * const windowName, int widthScreen, int heightScreen );

	static int ScreenWidth();
	static int ScreenHeight();

private:
	static Game* gmePtr;

	void Initialize() override;
	void LoadContent() override;
	void Update() override;
	void Draw() override;
	void UnLoadContent() override;

	// User-defined methods
	virtual void initialize();
	virtual void loadUserContent();
	virtual void unloadUserContent();
	virtual void terminate();

};



#endif 