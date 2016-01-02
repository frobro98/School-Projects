
#ifndef COLLISIONVOLUME_H
#define COLLISIONVOLUME_H

#include "Vect.h"
#include "Matrix.h"
#include "PCSNode.h"

class Model;
class BoundingSphere;
class AxisAlignedBoundingBox;
class OrientingBoundingBox;
class PartialBoundingBox;

class CollisionVolume : public PCSNode
{
public:
	virtual ~CollisionVolume();

	virtual bool collisionWithVolume(const CollisionVolume* const colVol) const = 0;
	virtual void calculateColStats(const Matrix& world) = 0;

	virtual bool visitSphere(const BoundingSphere* const sph) const{sph; return false;}
	virtual bool visitAABB(const AxisAlignedBoundingBox* const aabb) const {aabb; return false;}
	virtual bool visitOBB(const OrientingBoundingBox* const obb) const {obb; return false;}
	virtual bool visitPartialBB(const PartialBoundingBox* const pbb) const {pbb; return false;}

	virtual void showDebugVolume(const Matrix& world) const = 0;

	Matrix getWorld() const { return world; }

protected:
	CollisionVolume(Model* const model);
	CollisionVolume(){colModel = 0;}

	Matrix baseTrans;
	Matrix world;
	Model* colModel;

};

#endif // COLLISIONVOLUME_H