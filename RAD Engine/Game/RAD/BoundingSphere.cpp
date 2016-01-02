
#include <assert.h>

#include "BoundingSphere.h"
#include "AxisAlignedBoundingBox.h"
#include "OrientingBoundingBox.h"
#include "PartialBoundingBox.h"
#include "AssetManager.h"
#include "Azul.h"
#include "OctreeIterator.h"
#include "CollisionTools.h"
#include "Tools.h"

BoundingSphere::BoundingSphere(Model* const mod)
	: CollisionVolume(mod)
{
	this->center = new Vect();
	this->radius = 0.f;
}

BoundingSphere::BoundingSphere(Model* const mod, Vect& cen, const float& rad)
	: CollisionVolume(mod), center(new Vect(cen)), radius(rad)
{
}

BoundingSphere::~BoundingSphere()
{
	delete center;
}

bool BoundingSphere::collisionWithVolume(const CollisionVolume* const colVol) const
{
	assert(colVol != 0);
	return colVol->visitSphere(this);
}

bool BoundingSphere::visitSphere(const BoundingSphere* const sph) const
{
	assert(sph != 0);
	bool result = false;
	if(CollisionTools::SPHvSPH(this, sph))
	{
		if(this->child)
		{
			OctreeIterator oIt(child);
			while(!oIt.atEnd())
			{
				if(((CollisionVolume*)oIt.current())->collisionWithVolume((CollisionVolume*)sph))
				{
					result = true;
					break;
				}
				oIt.next();
			}
		}
		else if(sph->getChild())
		{
			OctreeIterator oIt(sph->getChild());
			while(!oIt.atEnd())
			{
				if(((CollisionVolume*)oIt.current())->collisionWithVolume((CollisionVolume*)this))
				{
					result = true;
					break;
				}
				oIt.next();
			}
		}
		else
		{
			result = true;
		}
	}
	return result;
}

bool BoundingSphere::visitAABB(const AxisAlignedBoundingBox* const aabb) const
{
	bool result = false;
	if(CollisionTools::SPHvAABB(this, aabb))
	{
		if(this->child)
		{
			OctreeIterator oIt(child);
			while(!oIt.atEnd())
			{
				if(((CollisionVolume*)oIt.current())->collisionWithVolume((CollisionVolume*)aabb))
				{
					result = true;
					break;
				}
				oIt.next();
			}
		}
		else if(aabb->getChild())
		{
			OctreeIterator oIt(aabb->getChild());
			while(!oIt.atEnd())
			{
				if(((CollisionVolume*)oIt.current())->collisionWithVolume((CollisionVolume*)this))
				{
					result = true;
					break;
				}
				oIt.next();
			}
		}
		else
		{
			result = true;
		}
	}
	return result;
}

bool BoundingSphere::visitOBB(const OrientingBoundingBox* const obb) const 
{
	bool result = false;
	if(CollisionTools::SPHvOBB(this, obb))
	{
		if(this->child)
		{
			OctreeIterator oIt(child);
			while(!oIt.atEnd())
			{
				if(((CollisionVolume*)oIt.current())->collisionWithVolume((CollisionVolume*)obb))
				{
					result = true;
					break;
				}
				oIt.next();
			}
		}
		else if(obb->getChild())
		{
			OctreeIterator oIt(obb->getChild());
			while(!oIt.atEnd())
			{
				if(((CollisionVolume*)oIt.current())->collisionWithVolume((CollisionVolume*)this))
				{
					result = true;
					break;
				}
				oIt.next();
			}
		}
		else
		{
			result = true;
		}
	}
	return result;
}

bool BoundingSphere::visitPartialBB(const PartialBoundingBox* const pbb) const
{
	float distance = ((*this->center) - (pbb->getCenter())).mag();

	return distance < (this->radius + pbb->getRadius());
}

void BoundingSphere::calculateColStats(const Matrix& world)
{
	Vect origCenter = Vect(0, 0, 0);
	Vect origRad(0.f, 0.f, 1.f, 0.f);

	Vect vecTrans = origRad * world;

	float mag = (vecTrans - origCenter).mag();
	radius = (colModel->radius * mag);

	*center = origCenter * baseTrans * world;

	this->world = world;
}

void BoundingSphere::showDebugVolume(const Matrix& world) const
{
	GraphicsObjectWireFrame *sphere = new GraphicsObjectWireFrame(AssetManager::retrieveModel("sphere"));

	Matrix base = baseTrans * world;

	sphere->setWorld(base);

	sphere->Render();

}