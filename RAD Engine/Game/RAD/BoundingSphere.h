
#ifndef BOUNDINGSPHERE_H
#define BOUNDINGSPHERE_H

#include "CollisionVolume.h"

class Vect;
class Model;

class BoundingSphere : public CollisionVolume
{
public:
	BoundingSphere(Model* const mod);
	BoundingSphere(Model* const model, Vect& centerPoint, const float& rad);
	~BoundingSphere();

	void calculateColStats(const Matrix& world) override;

	bool collisionWithVolume(const CollisionVolume* const colVol) const override;
	bool visitSphere(const BoundingSphere* const sphere) const override;
	bool visitAABB(const AxisAlignedBoundingBox* const aabb) const override;
	bool visitOBB(const OrientingBoundingBox* const obb) const override;
	bool visitPartialBB(const PartialBoundingBox* const pbb) const override;

	void showDebugVolume(const Matrix& world) const override;

	Vect& getCenter() const { return *center; }
	float getRadius() const { return radius; }


private:
	Vect* center;
	float radius;
};

#endif // BOUNDINGSPHERE_H