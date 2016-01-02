
#include <assert.h>

#include "CollisionTools.h"
#include "Tools.h"
#include "OrientingBoundingBox.h"
#include "AxisAlignedBoundingBox.h"
#include "PartialBoundingBox.h"
#include "BoundingSphere.h"


bool CollisionTools::SATCheck(const BoundingBox* const b1, const BoundingBox* const b2, const Vect& axis)
{
	const Vect* b1Points = b1->getBoxCorners();
	const Vect* b2Points = b2->getBoxCorners();
	
	const int len = 8;

	Vect minB1, maxB1, minB2, maxB2;
	minB1 = Vect(b1Points[0].dot(axis), b1Points[0].dot(axis), b1Points[0].dot(axis));
	maxB1 = Vect(b1Points[0].dot(axis), b1Points[0].dot(axis), b1Points[0].dot(axis));
	minB2 = Vect(b2Points[0].dot(axis), b2Points[0].dot(axis), b2Points[0].dot(axis));
	maxB2 = Vect(b2Points[0].dot(axis), b2Points[0].dot(axis), b2Points[0].dot(axis));

	for(int i = 1; i < len; ++i)
	{
		float dotB1 = b1Points[i].dot(axis);
		float dotB2 = b2Points[i].dot(axis);

		// Box 1 intervals
		minB1[x] = Tools::min(dotB1, minB1[x]);
		minB1[y] = Tools::min(dotB1, minB1[y]);
		minB1[z] = Tools::min(dotB1, minB1[z]);

		maxB1[x] = Tools::max(dotB1, maxB1[x]);
		maxB1[y] = Tools::max(dotB1, maxB1[y]);
		maxB1[z] = Tools::max(dotB1, maxB1[z]);

		// Box 2 intervals
		minB2[x] = Tools::min(dotB2, minB2[x]);
		minB2[y] = Tools::min(dotB2, minB2[y]);
		minB2[z] = Tools::min(dotB2, minB2[z]);
			
		maxB2[x] = Tools::max(dotB2, maxB2[x]);
		maxB2[y] = Tools::max(dotB2, maxB2[y]);
		maxB2[z] = Tools::max(dotB2, maxB2[z]);
	}

	// Check if the intervals intersect
	return Tools::intervalIntersect(minB1[x], maxB1[x], minB2[x], maxB2[x]);
		   
}

bool CollisionTools::AABBvAABB(const AxisAlignedBoundingBox* const aabb1, const AxisAlignedBoundingBox* const aabb2)
{
	Vect min1 = aabb1->getMinVect();
	Vect max1 = aabb1->getMaxVect();
	Vect min2 = aabb2->getMinVect();
	Vect max2 = aabb2->getMaxVect();

	return	Tools::intervalIntersect(min1[x], max1[x], min2[x], max2[x]) &&
			Tools::intervalIntersect(min1[y], max1[y], min2[y], max2[y]) &&
			Tools::intervalIntersect(min1[z], max1[z], min2[z], max2[z]);
}

bool CollisionTools::SPHvSPH(const BoundingSphere* const sph1, const BoundingSphere* const sph2)
{
	float distance = ((sph1->getCenter()) - (sph2->getCenter())).mag();

	return distance < (sph1->getRadius() + sph2->getRadius());
}

bool CollisionTools::OBBvOBB(const OrientingBoundingBox* const obb1, const OrientingBoundingBox* const obb2)
{
	return SATCheck(obb1, obb2, obb1->leftAxis()) &&
		   SATCheck(obb1, obb2, obb1->upAxis()) &&
		   SATCheck(obb1, obb2, obb1->forwardAxis()) &&
		   SATCheck(obb1, obb2, obb2->leftAxis()) &&
		   SATCheck(obb1, obb2, obb2->upAxis()) &&
		   SATCheck(obb1, obb2, obb2->forwardAxis()) &&
		   SATCheck(obb1, obb2, obb1->leftAxis().cross(obb2->leftAxis())) &&
		   SATCheck(obb1, obb2, obb1->leftAxis().cross(obb2->upAxis())) &&
		   SATCheck(obb1, obb2, obb1->leftAxis().cross(obb2->forwardAxis())) &&
		   SATCheck(obb1, obb2, obb1->upAxis().cross(obb2->leftAxis())) &&
		   SATCheck(obb1, obb2, obb1->upAxis().cross(obb2->upAxis())) &&
		   SATCheck(obb1, obb2, obb1->upAxis().cross(obb2->forwardAxis())) &&
		   SATCheck(obb1, obb2, obb1->forwardAxis().cross(obb2->leftAxis())) &&
		   SATCheck(obb1, obb2, obb1->forwardAxis().cross(obb2->upAxis())) &&
		   SATCheck(obb1, obb2, obb1->forwardAxis().cross(obb2->forwardAxis()));
}

bool CollisionTools::AABBvOBB(const AxisAlignedBoundingBox* const aabb, const OrientingBoundingBox* const obb)
{
	return SATCheck(aabb, obb, aabb->leftAxis()) &&
		   SATCheck(aabb, obb, aabb->upAxis()) &&
		   SATCheck(aabb, obb, aabb->forwardAxis()) &&
		   SATCheck(aabb, obb, obb->leftAxis()) &&
		   SATCheck(aabb, obb, obb->upAxis()) &&
		   SATCheck(aabb, obb, obb->forwardAxis()) &&
		   SATCheck(aabb, obb, aabb->leftAxis().cross(obb->leftAxis())) &&
		   SATCheck(aabb, obb, aabb->leftAxis().cross(obb->upAxis())) &&
		   SATCheck(aabb, obb, aabb->leftAxis().cross(obb->forwardAxis())) &&
		   SATCheck(aabb, obb, aabb->upAxis().cross(obb->leftAxis())) &&
		   SATCheck(aabb, obb, aabb->upAxis().cross(obb->upAxis())) &&
		   SATCheck(aabb, obb, aabb->upAxis().cross(obb->forwardAxis())) &&
		   SATCheck(aabb, obb, aabb->forwardAxis().cross(obb->leftAxis())) &&
		   SATCheck(aabb, obb, aabb->forwardAxis().cross(obb->upAxis())) &&
		   SATCheck(aabb, obb, aabb->forwardAxis().cross(obb->forwardAxis()));
}

bool CollisionTools::SPHvOBB(const BoundingSphere* const sph, const OrientingBoundingBox* const obb)
{
	Vect center = sph->getCenter();
	float radius = sph->getRadius();

	Matrix obbWorld = obb->getWorld();

	Vect localPoint = center * obbWorld.getInv();
	Vect minAABB = obb->getMinAABB();
	Vect maxAABB = obb->getMaxAABB();

	float newX = Tools::clamp(localPoint[x], minAABB[x], maxAABB[x]);
	float newY = Tools::clamp(localPoint[y], minAABB[y], maxAABB[y]);
	float newZ = Tools::clamp(localPoint[z], minAABB[z], maxAABB[z]);

	Vect testPoint = Vect(newX, newY, newZ) * obbWorld;
	
	float dist = Tools::dist(center, testPoint);

	return dist < radius;
}

bool CollisionTools::SPHvAABB(const BoundingSphere* const sph, const AxisAlignedBoundingBox* const aabb)
{
	// AABB data
	const Vect vMax = aabb->getMaxVect();
	const Vect vMin = aabb->getMinVect();

	// Sphere data
	const Vect center = sph->getCenter();
	const float radius = sph->getRadius();

	const float newX = Tools::clamp(center[x], vMin[x], vMax[x]);
	const float newY = Tools::clamp(center[y], vMin[y], vMax[y]);
	const float newZ = Tools::clamp(center[z], vMin[z], vMax[z]);
	
	const Vect clmpSph(newX, newY, newZ);
	
	const float dist = Tools::dist(center, clmpSph);

	return dist < radius;
}

bool CollisionTools::PBBvAABB(const PartialBoundingBox* const pbb, const AxisAlignedBoundingBox* const aabb)
{
	// AABB data
	const Vect vMax = aabb->getMaxVect();
	const Vect vMin = aabb->getMinVect();

	// Sphere data
	const Vect center = pbb->getCenter();
	const float radius = pbb->getRadius();

	const float newX = Tools::clamp(center[x], vMin[x], vMax[x]);
	const float newY = Tools::clamp(center[y], vMin[y], vMax[y]);
	const float newZ = Tools::clamp(center[z], vMin[z], vMax[z]);

	const Vect clmpSph(newX, newY, newZ);

	const float dist = Tools::dist(center, clmpSph);

	return dist < radius;

}

bool CollisionTools::PBBvOBB(const PartialBoundingBox* const pbb, const OrientingBoundingBox* const obb)
{
	Vect center = pbb->getCenter();
	float radius = pbb->getRadius();

	Matrix obbWorld = obb->getWorld();

	Vect localPoint = center * obbWorld.getInv();
	Vect minAABB = obb->getMinAABB();
	Vect maxAABB = obb->getMaxAABB();

	float newX = Tools::clamp(localPoint[x], minAABB[x], maxAABB[x]);
	float newY = Tools::clamp(localPoint[y], minAABB[y], maxAABB[y]);
	float newZ = Tools::clamp(localPoint[z], minAABB[z], maxAABB[z]);

	Vect testPoint = Vect(newX, newY, newZ) * obbWorld;

	float dist = Tools::dist(center, testPoint);

	return dist < radius;
}