
#include "BoundingBox.h"

const Vect BoundingBox::leftAxis() const
{
	Vect xAxis = this->world.get(ROW_0).norm(); 
	return xAxis;
}

const Vect BoundingBox::upAxis() const
{
	Vect yAxis = this->world.get(ROW_1).norm();
	return yAxis;
}

const Vect BoundingBox::forwardAxis() const
{
	Vect zAxis = this->world.get(ROW_2).norm();
	return zAxis;
}