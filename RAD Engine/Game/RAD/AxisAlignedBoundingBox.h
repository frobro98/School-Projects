
#ifndef AXISALIGNEDBOUNDINGBOX_H
#define AXISALIGNEDBOUNDINGBOX_H

#include "Azul.h"
#include "BoundingBox.h"

class Model;

class AxisAlignedBoundingBox : public BoundingBox
{
public:
	AxisAlignedBoundingBox(Model* const mod);
	~AxisAlignedBoundingBox();

	bool collisionWithVolume(const CollisionVolume* const colVol) const override;

	bool visitSphere(const BoundingSphere* const sph) const override;
	bool visitAABB(const AxisAlignedBoundingBox* const aabb) const override;
	bool visitOBB(const OrientingBoundingBox* const obb) const override;
	bool visitPartialBB(const PartialBoundingBox* const pbb) const override;

	void showDebugVolume(const Matrix& world) const override;
	void calculateColStats(const Matrix& world) override;

	Vect getMinVect() const { return min; }
	Vect getMaxVect() const { return max; }

private:
	Vect max;
	Vect min;
};

#endif //AXISALIGNEDBOUNDINGBOX_H