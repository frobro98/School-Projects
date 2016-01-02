
#ifndef COLLISONTOOLS_H
#define COLLISIONTOOLS_H

#include "Vect.h"

class BoundingBox;
class BoundingSphere;
class OrientingBoundingBox;
class AxisAlignedBoundingBox;
class PartialBoundingBox;

namespace CollisionTools
{
	bool SATCheck(const BoundingBox* const box1, const BoundingBox* const box2, const Vect& axis);

	bool AABBvOBB(const AxisAlignedBoundingBox* const aabb, const OrientingBoundingBox* const obb);
	
	bool OBBvOBB(const OrientingBoundingBox* const obb1, const OrientingBoundingBox* const obb2);
	bool AABBvAABB(const AxisAlignedBoundingBox* const aabb1, const AxisAlignedBoundingBox* const aabb2);
	bool SPHvSPH(const BoundingSphere* const sph1, const BoundingSphere* const sph2);

	bool SPHvOBB(const BoundingSphere* const sph, const OrientingBoundingBox* const obb);
	bool SPHvAABB(const BoundingSphere* const sph, const AxisAlignedBoundingBox* const aabb);
	bool PBBvAABB(const PartialBoundingBox* const pbb, const AxisAlignedBoundingBox* const aabb);
	bool PBBvOBB(const PartialBoundingBox* const pbb, const OrientingBoundingBox* const obb);

};

#endif // COLLISIONTOOLS_H