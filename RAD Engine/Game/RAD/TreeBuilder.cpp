

#include "TreeBuilder.h"
#include "BoundingBox.h"
#include "PartialBoundingBox.h"
#include "BoundingSphere.h"
#include "GpuModel.h"
#include "Azul.h"
#include "Visualizer.h"
#include "Tools.h"

TreeBuilder::TreeBuilder(const TreeType& treeType, const int &treeHeight)
	: type(treeType), level(treeHeight)
{
}

TreeBuilder::~TreeBuilder()
{

}

CollisionVolume* TreeBuilder::constructTree(Model* const model, BoundingBox* const boundingBox)
{
	return recConstructTree(model, boundingBox, this->level);
}

CollisionVolume* TreeBuilder::recConstructTree(Model* const model, BoundingBox* const box, int level)
{
	if(level == 0)
	{
		return 0;
	}
	else
	{
		CollisionVolume* rootVolume = box;
		if(this->type == OCT)
		{
			for(int i = 0; i < 8; ++i)
			{
				BoxQuadrent loc = (BoxQuadrent)(TOP_FRONT_LEFT + i);
				PartialBoundingBox* subQuad = buildSubQuadrent(model, box->getLocalCorners(), loc);
				//Visualizer::showSphere(subQuad->getCenter(), subQuad->getRadius());
				if(triangleInSphere(model, subQuad))
				{
					//BoundingSphere* octSphere = boxToSphere(model, subQuad);
					rootVolume->setChild(subQuad);
					subQuad->setChild(recConstructTree(model, subQuad, level-1));
				}
			}
		}
		else if(this->type == QUAD)
		{
			

		}
		return (CollisionVolume*)rootVolume->getChild();
	}
}

bool TreeBuilder::triangleInSphere(Model* const model, const PartialBoundingBox* const parBox) const
{
	bool insideSphere = false;
	Vect* vList = model->getVectList();
	TriangleIndex* triIndex = model->getTriangleList();

	for(int i = 0; i < model->numTris; ++i)
	{
		
		Vect* v0 = &vList[triIndex[i].v0];
		Vect* v1 = &vList[triIndex[i].v1];
		Vect* v2 = &vList[triIndex[i].v2];
		float distance = Tools::dist(parBox->getCenter(), *v0);
		if(distance <= parBox->getRadius())
		{
			insideSphere = true;
			break;
		}

		distance = Tools::dist(parBox->getCenter(), *v1);
		if(distance <= parBox->getRadius())
		{
			insideSphere = true;
			break;
		}

		distance = Tools::dist(parBox->getCenter(), *v2);
		if(distance <= parBox->getRadius())
		{
			insideSphere = true;
			break;
		}
	}

	return insideSphere;
}

PartialBoundingBox* TreeBuilder::buildSubQuadrent(Model* const mod, const Vect* const points, BoxQuadrent boxType)
{
	// This will be done only at the beginning of the entire game
	Vect max = points[0];
	Vect min = points[1];
	Vect corners[8];
	float midX = (max[x] + min[x])/2.f;
	float midY = (max[y] + min[y])/2.f;
	float midZ = (max[z] + min[z])/2.f;
	PartialBoundingBox* pBox = 0;

	switch(this->type)
	{
	case OCT:
		if(boxType == BoxQuadrent::BOTTOM_BACK_LEFT)
		{
			corners[0] = Vect(max[x], midY, midZ); // Top front left
			corners[1] = Vect(midX, min[y], min[z]); // Bottom back right
			corners[2] = Vect(midX, midY, min[z]); // Top back right
			corners[3] = Vect(midX, midY, midZ); // Top front right
			corners[4] = Vect(midX, min[y], midZ); // Bottom front right
			corners[5] = Vect(max[x], min[y], midZ); // Bottom front left
			corners[6] = Vect(max[x], midY, min[z]); // Top back left
			corners[7] = Vect(max[x], min[y], min[z]); // Bottom back left

			pBox = new PartialBoundingBox(mod, corners);
			break;
		}
		else if(boxType == BoxQuadrent::BOTTOM_BACK_RIGHT)
		{
			corners[0] = Vect(midX, midY, midZ); // Top front left
			corners[1] = Vect(min[x], min[y], min[z]); // Bottom back right
			corners[2] = Vect(min[x], midY, min[z]); // Top back right
			corners[3] = Vect(min[x], midY, midZ); // Top front right
			corners[4] = Vect(min[x], min[y], midZ); // Bottom front right
			corners[5] = Vect(midX, min[y], midZ); // Bottom front left
			corners[6] = Vect(midX, midY, min[z]); // Top back left
			corners[7] = Vect(midX, min[y], min[z]); // Bottom back left

			pBox = new PartialBoundingBox(mod, corners);
			break;
		}
		else if(boxType == BoxQuadrent::BOTTOM_FRONT_LEFT)
		{
			corners[0] = Vect(max[x], midY, max[z]); // Top front left
			corners[1] = Vect(midX, min[y], midZ); // Bottom back right
			corners[2] = Vect(min[x], midY, min[z]); // Top back right
			corners[3] = Vect(min[x], midY, midZ); // Top front right
			corners[4] = Vect(min[x], min[y], midZ); // Bottom front right
			corners[5] = Vect(midX, min[y], midZ); // Bottom front left
			corners[6] = Vect(midX, midY, min[z]); // Top back left
			corners[7] = Vect(midX, min[y], min[z]); // Bottom back left

			pBox = new PartialBoundingBox(mod, corners);
			break;
		}
		else if(boxType == BoxQuadrent::BOTTOM_FRONT_RIGHT)
		{
			corners[0] = Vect(midX, midY, max[z]); // Top front left
			corners[1] = Vect(min[x], min[y], midZ); // Bottom back right
			corners[2] = Vect(min[x], midY, midZ); // Top back right
			corners[3] = Vect(min[x], midY, max[z]); // Top front right
			corners[4] = Vect(min[x], min[y], max[z]); // Bottom front right
			corners[5] = Vect(midX, min[y], max[z]); // Bottom front left
			corners[6] = Vect(midX, midY, midZ); // Top back left
			corners[7] = Vect(midX, min[y], midZ); // Bottom back left

			pBox = new PartialBoundingBox(mod, corners);
			break;
		}
		else if(boxType == BoxQuadrent::TOP_BACK_LEFT)
		{
			corners[0] = Vect(max[x], max[y], midZ); // Top front left
			corners[1] = Vect(midX, midY, min[z]); // Bottom back right
			corners[2] = Vect(midX, max[y], min[z]); // Top back right
			corners[3] = Vect(midX, max[y], midZ); // Top front right
			corners[4] = Vect(midX, midY, midZ); // Bottom front right
			corners[5] = Vect(max[x], midY, midZ); // Bottom front left
			corners[6] = Vect(max[x], max[y], min[z]); // Top back left
			corners[7] = Vect(max[x], midY, min[z]); // Bottom back left

			pBox = new PartialBoundingBox(mod, corners);
			break;
		}
		else if(boxType == BoxQuadrent::TOP_BACK_RIGHT)
		{
			corners[0] = Vect(midX, max[y], midZ); // Top front left
			corners[1] = Vect(min[x], midY, min[z]); // Bottom back right
			corners[2] = Vect(midX, max[y], min[z]); // Top back right
			corners[3] = Vect(min[x], max[y], midZ); // Top front right
			corners[4] = Vect(min[x], midY, midZ); // Bottom front right
			corners[5] = Vect(midX, midY, midZ); // Bottom front left
			corners[6] = Vect(min[x], max[y], min[z]); // Top back left
			corners[7] = Vect(midX, midY, min[z]); // Bottom back left

			pBox = new PartialBoundingBox(mod, corners);
			break;
		}
		else if(boxType == BoxQuadrent::TOP_FRONT_LEFT)
		{
			corners[0] = Vect(max[x], max[y], max[z]); // Top front left
			corners[1] = Vect(midX, midY, midZ); // Bottom back right
			corners[2] = Vect(min[x], max[y], min[z]); // Top back right
			corners[3] = Vect(min[x], max[y], midZ); // Top front right
			corners[4] = Vect(min[x], midY, midZ); // Bottom front right
			corners[5] = Vect(midX, midY, midZ); // Bottom front left
			corners[6] = Vect(midX, max[y], min[z]); // Top back left
			corners[7] = Vect(midX, midY, min[z]); // Bottom back left

			pBox = new PartialBoundingBox(mod, corners);
			break;
		}
		else if(boxType == BoxQuadrent::TOP_FRONT_RIGHT)
		{
			corners[0] = Vect(midX, max[y], max[z]); // Top front left
			corners[1] = Vect(min[x], midY, midZ); // Bottom back right
			corners[2] = Vect(min[x], max[y], midZ); // Top back right
			corners[3] = Vect(min[x], max[y], max[z]); // Top front right
			corners[4] = Vect(min[x], midY, max[z]); // Bottom front right
			corners[5] = Vect(midX, midY, max[z]); // Bottom front left
			corners[6] = Vect(midX, max[y], midZ); // Top back left
			corners[7] = Vect(midX, midY, midZ); // Bottom back left

			pBox = new PartialBoundingBox(mod, corners);
			break;
		}
		break;
	case QUAD:
		
		break;
	default:
		
		break;
	}

	return pBox;
}

BoundingSphere* TreeBuilder::boxToSphere(Model* const mod, const PartialBoundingBox& pb)
{
	float radius = pb.getRadius();
	Vect center = pb.getCenter();
	BoundingSphere* octSphere = new BoundingSphere(mod, center, radius);
	return octSphere;
}

