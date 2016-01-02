
#ifndef PARTIALBOUNDINGBOX_H
#define PARTIALBOUNDINGBOX_H

#include "BoundingBox.h"
#include "Tools.h"

// Used in building octree collision hierarchy
class PartialBoundingBox : public BoundingBox
{
public:
	PartialBoundingBox() { }
	PartialBoundingBox(Model* const mod, const Vect* const points);
	~PartialBoundingBox();

	float getRadius() const { return boxRadius; }
	Vect getCenter() const { return boxCenter; }

	// Unused because this is a temporary volume
	void showDebugVolume(const Matrix& world) const override;
	void calculateColStats(const Matrix& world) override;
	bool collisionWithVolume(const CollisionVolume* const colVol) const override;

private:
	Vect  boxCenter;
	float boxRadius;
};

#endif // PARTIALBOUNDINGBOX_H