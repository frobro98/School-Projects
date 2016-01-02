
#ifndef COLLIDABLE_H
#define COLLIDABLE_H

class Model;
class Matrix;
class Vect;
class CollisionVolume;
class BoundingSphere;

enum Sphere
{
	SPHERE
};

enum AxisAligned
{
	AABB
};

enum Oriented
{
	OBB
};

enum ColType
{
	COL_PRECISE,
	COL_REGULAR
};

class Collidable
{
public:
	Collidable();
	Collidable(Model* const model);
	virtual ~Collidable();

	/**
	 \brief This method acts as a default implementation of what happens when
	 there's a collision between two Collidable objects. 
	 
	 The user will have to define this in the derived classes of Collidable. 
	 They then can define their own collision method that takes specific
	 Collidable objects. Here's on example:
		\code
		void Ship::collision(Collidable* colObj)
		{
		}

		void Ship::collision(Asteroid* ast)
		{
			// Behavior of what happens when Ships and Asteroid collide
		}

	 \param cObj			Collidable object
	 */

	virtual void collision(Collidable* cObj){cObj;};

	const Vect getMaxAABBPoint() const;
	const Vect getMinAABBPoint() const;
	
	void calcColStats();
	static bool testCollisionPair(Collidable* cObj1, Collidable* cObj2);

protected:

	void showBoundingVolume() const;

	/**
	 \brief Sets up the data for the Collision model
	
	 To actually get collision working, the user needs to set up the model
	 that the Collidable will use. 

		\code
		Ship::Ship()
		{
			Model model = AssetManager::retrieveModel("ship");

			// More set up of Ship
			
			setupColModel(model);
		}

	 \param	model			Model used in the GameObject
	 \ingroup COLLIDABLE
	 */
	void setupCollision(Model* const model, Sphere bsEnum, ColType type, const int& level = 1);
	void setupCollision(Model* const model, AxisAligned aabbEnum, ColType type, const int& level = 1);
	void setupCollision(Model* const model, Oriented obbEnum, ColType type, const int& level = 1);

	void setupBoundingVolume(Model* const model, Sphere bsEnum);
	void setupBoundingVolume(Model* const model, AxisAligned aabbEnum);
	void setupBoundingVolume(Model* const model, Oriented obbEnum);

	static Collidable* instance;

	Model* colModel;
	Matrix* colWorld;
	

private:
	void setupAABBSphere(Model* const model);
	void setupPreciseCollision(Model* const model, const int& level);

	CollisionVolume* boundingVol;
	BoundingSphere* aabbSphere;

};

#endif // COLLIDABLE_H