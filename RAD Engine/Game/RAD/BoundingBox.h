
#ifndef BOUNDINGBOX_H
#define BOUNDINGBOX_H

#include <string.h>

#include "CollisionVolume.h"

class BoundingBox : public CollisionVolume
{
public:
	virtual ~BoundingBox(){}

	const Vect leftAxis() const;
	const Vect upAxis() const;
	const Vect forwardAxis() const;

	const Vect* const getLocalCorners()const { return localCorners; }
	const Vect* const getBoxCorners() const { return transformCorners; }

	virtual void showDebugVolume(const Matrix& world) const = 0;
	virtual void calculateColStats(const Matrix& world) = 0;

protected:
	BoundingBox() {}
	BoundingBox(Model* const m)
		: CollisionVolume(m)
	{}

	Vect localCorners[8];
	Vect transformCorners[8];

};

#endif // BOUNDINGBOX_H