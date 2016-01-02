
#include "SpaceShip.h"
#include "..\RAD\RAD.h"
#include "Bullet.h"
#include "BulletFactory.h"


SpaceShip::SpaceShip(Model* const mod, Texture* const tex)
{
	scale.set( SCALE, 1.f, 1.f, 1.f);
	rot.set(ROT_XYZ, 0.f, 90.f, 0.f);
	pos.set(-75.f, 10.f, 0.f);
	*this->world = scale * rot * Matrix( TRANS, pos);

	rotAngle = .05f;
	
	gObj = new GraphicsObjectFlatTexture(mod, tex);

	this->gObj->setWorld(*world);
	setupCollision(mod, OBB, COL_REGULAR);

	InputManager::registerInput(this, SPACE_KEY, PRESSED);
	InputManager::registerInput(this, W_KEY, PRESSED);
	InputManager::registerInput(this, S_KEY, PRESSED);
	InputManager::registerInput(this, D_KEY, PRESSED);
	InputManager::registerInput(this, A_KEY, PRESSED);

	CollisionGroup<SpaceShip>::registerCollision(this);

	/*AlarmManager::registerAlarm(this, ALARM_0, 50.0f);
	AlarmManager::registerAlarm(this, ALARM_1, 2.5f);*/
	/*AlarmManager::registerAlarm(this, ALARM_2, 10.0f);*/

}

SpaceShip::SpaceShip(const Vect& pos, const Vect& rot)
{
	this->pos = pos;
	this->rot = Matrix(ROT_XYZ,rot[x], rot[y], rot[z]);
	this->scale = Matrix(SCALE, .5, .5, .5);
	*this->world = scale*this->rot*Matrix(TRANS, pos);

	Model* mod = AssetManager::retrieveModel("ship");
	Texture* tex = AssetManager::retrieveTexture("shipTex");

	this->gObj = new GraphicsObjectFlatTexture(mod, tex);
	gObj->setWorld(*world);

	//setupBoundingVolume(mod, OBB);
	setupCollision(mod, OBB, COL_REGULAR);

	CollisionGroup<SpaceShip>::registerCollision(this);

}

SpaceShip::~SpaceShip()
{
	delete this->gObj;
	gObj = 0;
}

void SpaceShip::collision(Collidable* c)
{
	c;
	printf("SpaceShip collided with Collidable\n");
}

void SpaceShip::collision(Cottage* ws)
{
	ws;
	printf("SpaceShip on Cottage!!\n");
}

void SpaceShip::Alarm0()
{
	printf("ALARM_0 is off!! Hurray!!\n");

	//AlarmManager::registerAlarm(this, ALARM_0, 5.0f);
}

void SpaceShip::Alarm1()
{
	AlarmManager::changeAlarmTime(this, 1.f, ALARM_0);
	printf("ALARM_1 is off!! Hurray!!\n");
}

void SpaceShip::Alarm2()
{
	printf("ALARM_2 is off!! Hurray!!\n");

	AlarmManager::registerAlarm(this, ALARM_2, 10.0f);

}

void SpaceShip::keyPressed(Inputs i, bool shiftKey, bool altKey, bool ctrlKey)
{
	shiftKey; altKey; ctrlKey;
	if(i == SPACE_KEY)
	{
		BulletFactory::create(this);
	}
}

void SpaceShip::keyDown(Inputs i, bool shiftKey, bool altKey, bool ctrlKey)
{
	UNUSED_VARS(shiftKey, altKey, ctrlKey);
	if(i == W_KEY)
	{
		pos += Vect(0.f, 0.f, 1.f) * rot;
	}
	else if(i == S_KEY)
	{
		pos += Vect(0.f, 0.f, -1.f) * rot;
	}
		
	if(i == A_KEY)
	{
		rot *= Matrix(ROT_Y, rotAngle);
	}
	else if(i == D_KEY)
	{
		rot *= Matrix(ROT_Y, -rotAngle);
	}
}

void SpaceShip::update()
{
		Matrix Trans;

		scale.set( SCALE, 0.5f, 0.5f, 0.5f);
		Trans.set( TRANS, pos);
		*world = scale * rot* Trans;
		this->gObj->setWorld(*world);

		//this->setWorld(world);

}

void SpaceShip::draw()
{

	showBoundingVolume();

	this->gObj->Render();
}

void SpaceShip::destroy()
{
	CollisionGroup<SpaceShip>::deregisterCollision(this);
	InputManager::deregisterInput(this, Inputs::SPACE_KEY, PRESSED);
	printf("SpaceShip is dead\n");
}