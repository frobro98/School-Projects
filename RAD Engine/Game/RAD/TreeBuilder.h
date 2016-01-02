
#ifndef TREEBUILDER_H
#define TREEBUILDER_H

#include "PartialBoundingBox.h"

class Model;
class BoundingSphere;

enum TreeType
{
	OCT,
	QUAD,
};

enum BoxQuadrent
{
	// Oct Tree
	TOP_FRONT_LEFT = 0,
	TOP_FRONT_RIGHT,
	BOTTOM_FRONT_LEFT,
	BOTTOM_FRONT_RIGHT,
	TOP_BACK_LEFT,
	TOP_BACK_RIGHT,
	BOTTOM_BACK_LEFT,
	BOTTOM_BACK_RIGHT,

	// Quad Tree
	FRONT_LEFT = 0,
	FRONT_RIGHT,
	BACK_LEFT,
	BACK_RIGHT,
};

class TreeBuilder
{
public:
	TreeBuilder(const TreeType &treeStructure, const int& level = 1);
	~TreeBuilder();

	CollisionVolume* constructTree(Model* const model, BoundingBox* const boundingBox);

private:
	TreeBuilder();
	TreeBuilder(const TreeBuilder&);
	const TreeBuilder operator=(const TreeBuilder&);

#pragma warning(disable : 4114)
	CollisionVolume* recConstructTree(Model* const model, BoundingBox* const box, int level);
	PartialBoundingBox* buildSubQuadrent(Model* const mod, const Vect* const points, BoxQuadrent boxType);
	bool triangleInSphere(Model* const model, const PartialBoundingBox* const parBox) const;
	BoundingSphere* boxToSphere(Model* const mod, const PartialBoundingBox& pb);

	TreeType type;
	const int level;
};

#endif // TREEBUILDER_H