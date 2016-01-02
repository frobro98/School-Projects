

#include "OrientingBoundingBox.h"
#include "Azul.h"
#include "AssetManager.h"
#include "BoundingSphere.h"
#include "AxisAlignedBoundingBox.h"
#include "OrientingBoundingBox.h"
#include "PartialBoundingBox.h"
#include "OctreeIterator.h"
#include "CollisionTools.h"
#include "Tools.h"

OrientingBoundingBox::OrientingBoundingBox(Model* const mod)
	: BoundingBox(mod)
{
	
	Vect minAABB = colModel->minPointAABB;
	Vect maxAABB = colModel->maxPointAABB;
	localCorners[0] = maxAABB;
	localCorners[1] = minAABB;

	localCorners[2] = Vect(minAABB[x], minAABB[y], maxAABB[z]);
	localCorners[3] = Vect(minAABB[x], maxAABB[y], minAABB[z]);
	localCorners[4] = Vect(minAABB[x], maxAABB[y], maxAABB[z]);
	localCorners[5] = Vect(maxAABB[x], minAABB[y], maxAABB[z]);
	localCorners[6] = Vect(maxAABB[x], maxAABB[y], minAABB[z]);
	localCorners[7] = Vect(maxAABB[x], minAABB[y], minAABB[z]);

	world = Matrix(IDENTITY);
	
}

OrientingBoundingBox::~OrientingBoundingBox()
{

}

void OrientingBoundingBox::showDebugVolume(const Matrix& world) const
{
	Vect max = localCorners[0];
	Vect min = localCorners[1];

	Matrix scale = Matrix(SCALE, max-min);
	Matrix trans = Matrix(TRANS, (max+min)*.5f);

	Matrix obbWorld = scale*trans;

	GraphicsObjectWireFrame* box = new GraphicsObjectWireFrame(AssetManager::retrieveModel("box"));
	Matrix newWorld = obbWorld * world;
	box->setWorld(newWorld);

	box->Render();
}

void OrientingBoundingBox::calculateColStats(const Matrix& world)
{
	for(int i = 0; i < 8; ++i)
	{
		transformCorners[i] = localCorners[i] * world;
	}

	this->world = world;
}

bool OrientingBoundingBox::collisionWithVolume(const CollisionVolume* const colVol) const
{
	return colVol->visitOBB(this);
}

bool OrientingBoundingBox::visitAABB(const AxisAlignedBoundingBox* const aabb) const
{
	bool result = false;
	if(CollisionTools::AABBvOBB(aabb, this))
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

bool OrientingBoundingBox::visitOBB(const OrientingBoundingBox* const obb) const
{
	bool result = false;
	if(CollisionTools::OBBvOBB(this, obb))
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

bool OrientingBoundingBox::visitSphere(const BoundingSphere* const sph) const
{
	bool result = false;
	if(CollisionTools::SPHvOBB(sph, this))
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

bool OrientingBoundingBox::visitPartialBB(const PartialBoundingBox* const pbb) const
{
	return CollisionTools::PBBvOBB(pbb, this);
}