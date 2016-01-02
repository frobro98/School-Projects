
#include <math.h>

#include "PartialBoundingBox.h"
#include "GraphicsObject_WireFrame.h"
#include "AssetManager.h"
#include "Visualizer.h"
#include "Tools.h"

PartialBoundingBox::PartialBoundingBox(Model* const mod, const Vect* const points)
	: BoundingBox(mod)
{
	boxRadius = Tools::max(abs((points[0][x] + points[1][x]) / 2.f), Tools::max(abs((points[0][y] + points[1][y]) / 2.f), abs((points[0][z] + points[1][z]) / 2.f)));
	this->boxCenter = Vect((points[0] + points[1])*.5f);
	
	this->localCorners[0] = points[0];
	this->localCorners[1] = points[1];
	this->localCorners[2] = points[2];
	this->localCorners[3] = points[3];
	this->localCorners[4] = points[4];
	this->localCorners[5] = points[5];
	this->localCorners[6] = points[6];
	this->localCorners[7] = points[7];
}

PartialBoundingBox::~PartialBoundingBox()
{
}

void PartialBoundingBox::calculateColStats(const Matrix& world)
{
	this->world = world;
	
}

bool PartialBoundingBox::collisionWithVolume(const CollisionVolume* const colVol) const
{
	return colVol->visitPartialBB(this);
}

void PartialBoundingBox::showDebugVolume(const Matrix& world) const
{
	Matrix scale(SCALE, boxRadius, boxRadius, boxRadius);
	
	Matrix newWorld = scale * world;
	GraphicsObjectWireFrame* sphere = new GraphicsObjectWireFrame( AssetManager::retrieveModel("sphere"));
	sphere->setWorld(newWorld);
	sphere->Render();
}