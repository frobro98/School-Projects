
#ifndef ORIENTINGBOUNDINGBOX_H
#define ORIENTINGBOUNDINGBOX_H

#include "BoundingBox.h"
#include "Vect.h"

class OrientingBoundingBox : public BoundingBox
{
public:
	OrientingBoundingBox(Model* const mod);
	~OrientingBoundingBox();

	bool collisionWithVolume(const CollisionVolume* const colVol) const override;

	bool visitOBB(const OrientingBoundingBox* const obb) const override;
	bool visitAABB(const AxisAlignedBoundingBox* const aabb) const override;
	bool visitSphere(const BoundingSphere* const sph) const override;
	bool visitPartialBB(const PartialBoundingBox* const pbb) const override;

	void showDebugVolume(const Matrix& world) const override;
	void calculateColStats(const Matrix& world) override;

	Vect getMaxAABB() const { return localCorners[0];}
	Vect getMinAABB() const { return localCorners[1];}

private:

};

#endif // ORIENTINGBOUNDINGBOX_H