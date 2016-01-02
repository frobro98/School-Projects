
#ifndef SCENE_H
#define SCENE_H

class AlarmManager;
class CollisionManager;
class DestroyableManager;
class InputManager;
class DrawableManager;
class DisposalManager;
class UpdateableManager;


class Scene
{
public:
	Scene();
	virtual ~Scene();

	/**
	 \brief Initializes the Scene with the initial GameObjects and sets up any 
	 collision pairs that will be tested.

	 Any derived class of Scene implements initialize. Here is an example of code
	 that creates 24 Asteroids, a Shield, and Ships. It also sets up Collisions between
	 Asteroids, Shields, and Ships.
		\code
		void SpaceScene::initialize()
		{
			new Ship(); // Ship will start at 0,0,0
			new Shield(); // Shield will spawn at 0, 0, 30

			for(int i = 0; i < 24; i++)
			{
				new Asteroid() // Astroids will have a random posion
			}

			CollisionManager::setCollisionPair<Ship, Shield>();
			CollisionManager::setCollisionPair<Ship, Asteroid>();
			CollisionManager::setCollisionPair<Asteroid, Shield>()
		}
	
	 \ingroup SCENE
	 */
	virtual void initialize() = 0;

	void hookupManagers();

	AlarmManager* const getAlarmManager() const {return aMan;}
	CollisionManager* const getCollisionManager() const {return cMan;}
	InputManager* const getInputManager() const {return iMan;}
	DrawableManager* const getDrawManager() const{return drawMan;}
	DestroyableManager* const getDestroyManager() const {return destMan;}
	UpdateableManager* const getUpdateManager() const {return uMan;}

	void update() const;
	void draw() const;

private:
	AlarmManager* aMan;
	CollisionManager* cMan;
	DestroyableManager* destMan;
	InputManager* iMan;
	DrawableManager* drawMan;
	UpdateableManager* uMan;
	DisposalManager* disMan;
};

#endif // SCENE_H