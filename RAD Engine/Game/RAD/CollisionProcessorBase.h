
#ifndef COLLISIONPROCESSORBASE_H
#define COLLISIONPROCESSORBASE_H

class CollisionProcessorBase
{
public:

	CollisionProcessorBase(){};
	virtual ~CollisionProcessorBase(){};

	virtual void testCollision() = 0;

};

#endif // COLLISIONPROCESSORBASE_H