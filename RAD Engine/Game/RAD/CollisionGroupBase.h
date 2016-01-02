
#ifndef COLLISIONGROUPBASE_H
#define COLLISIONGROUPBASE_H

class CollisionGroupBase
{
public:
	virtual ~CollisionGroupBase(){}
	virtual void calcGroupStats() = 0;
};

#endif // COLLISIONGROUPBASE_H