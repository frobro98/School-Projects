
#include <assert.h>
#include <limits>

#include "AxisAlignedBoundingBox.h"
#include "OrientingBoundingBox.h"
#include "BoundingSphere.h"
#include "AssetManager.h"
#include "CollisionTools.h"
#include "OctreeIterator.h"
#include "Tools.h"


AxisAlignedBoundingBox::AxisAlignedBoundingBox(Model* const mod)
	: BoundingBox(mod)
{
	this->max = Vect();
	this->min = Vect();
	/**baseTrans = Matrix(SCALE, this->colModel->radius, this->colModel->radius, this->colModel->radius);
	*baseTrans *= Matrix(TRANS, this->colModel->center)*/;
}

AxisAlignedBoundingBox::~AxisAlignedBoundingBox()
{
	// Nothing to do
}

void AxisAlignedBoundingBox::calculateColStats(const Matrix& world)
{
	const Vect* const vectList = colModel->getVectList();
	/*Vect tmpMax(FLT_MIN, FLT_MIN, FLT_MIN);
	Vect tmpMin(FLT_MAX, FLT_MAX, FLT_MAX);*/
	float minX = FLT_MAX;
	float minY = FLT_MAX;
	float minZ = FLT_MAX;

	float maxX = -FLT_MAX;//vectList[0][x];//FLT_MAX;
	float maxY = -FLT_MAX;//vectList[0][y];//FLT_MAX;
	float maxZ = -FLT_MAX;//vectList[0][z];//FLT_MAX;
	for(int i = 0; i < colModel->numVerts; ++i)
	{
		Vect vect = vectList[i] * world;
	
		// Calculate max Vect
		maxX = Tools::max(vect[x], maxX);
		maxY = Tools::max(vect[y], maxY);
		maxZ = Tools::max(vect[z], maxZ);

		// Calculate min Vect
		minX = Tools::min(vect[x], minX);
		minY = Tools::min(vect[y], minY);
		minZ = Tools::min(vect[z], minZ);
	}

	this->min = Vect(minX, minY, minZ);
	this->max = Vect(maxX, maxY, maxZ);

	transformCorners[0] = this->max;
	transformCorners[1] = this->min;
	transformCorners[2] = Vect(this->min[x], this->min[y], this->max[z]);
	transformCorners[3] = Vect(this->min[x], this->max[y], this->min[z]);
	transformCorners[4] = Vect(this->min[x], this->max[y], this->max[z]);
	transformCorners[5] = Vect(this->max[x], this->min[y], this->max[z]);
	transformCorners[6] = Vect(this->max[x], this->max[y], this->min[z]);
	transformCorners[7] = Vect(this->max[x], this->min[y], this->min[z]);

	Matrix scale = Matrix(SCALE, (this->max)-(this->min));
	Matrix trans = Matrix(TRANS, (this->max+this->min)*.5f);
	this->world = scale*trans;

}

bool AxisAlignedBoundingBox::collisionWithVolume(const CollisionVolume* const colVol) const
{
	return colVol->visitAABB(this);
}

bool AxisAlignedBoundingBox::visitAABB(const AxisAlignedBoundingBox* const aabb) const
{
	bool result = false;
	if(CollisionTools::AABBvAABB(this, aabb))
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

bool AxisAlignedBoundingBox::visitOBB(const OrientingBoundingBox* const obb) const
{
	bool result = false;
	if(CollisionTools::AABBvOBB(this, obb))
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

bool AxisAlignedBoundingBox::visitSphere(const BoundingSphere* const sph) const
{
	bool result = false;
	if(CollisionTools::SPHvAABB(sph, this))
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

bool AxisAlignedBoundingBox::visitPartialBB(const PartialBoundingBox* const pbb) const
{
	return CollisionTools::PBBvAABB(pbb, this);
}

void AxisAlignedBoundingBox::showDebugVolume(const Matrix& world) const
{
	UNUSED_VAR(world);

	GraphicsObjectWireFrame* box = new GraphicsObjectWireFrame(AssetManager::retrieveModel("box"));
	Matrix boxWorld = this->world;
	box->setWorld(boxWorld);

	box->Render();
}