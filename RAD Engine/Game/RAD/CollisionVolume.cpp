
#include "CollisionVolume.h"
#include "Azul.h"

CollisionVolume::CollisionVolume(Model* const mod)
{
	colModel = mod;
	baseTrans = Matrix(SCALE, this->colModel->radius, this->colModel->radius, this->colModel->radius);
	baseTrans *= Matrix(TRANS, this->colModel->center);
}

CollisionVolume::~CollisionVolume()
{
	colModel = 0;
}
