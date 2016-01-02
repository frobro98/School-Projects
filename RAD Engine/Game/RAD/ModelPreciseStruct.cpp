
#include "ModelPreciseStruct.h"
#include "Vect.h"
#include "GpuModel.h"
#include "AxisAlignedBoundingBox.h"
#include "TreeBuilder.h"

ModelInfo ModelInfoCreator::createModelHierarchy(Model* const model) const
{
	AxisAlignedBoundingBox aabb(model);
	TreeBuilder builder(OCT);

	ModelInfo info;
	info.volumeChildren = builder.constructTree(model, &aabb);
	info.model = model;

	return info;
}