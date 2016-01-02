
#include <math.h>
#include <assert.h>

#include "Vect.h"
#include "GpuModel.h"
#include "GPUverts.h"
#include "Tools.h"
#include "Enum.h"

const float Tools::dist(const Vect& v1, const Vect& v2)
{
	float xPos = (v1)[x] - (v2)[x];
	float yPos = (v1)[y] - (v2)[y];
	float zPos = (v1)[z] - (v2)[z];

	float distance = xPos*xPos + yPos*yPos + zPos*zPos;

	return sqrt(distance);
}

const Vect Tools::min(const Vect& t0, const Vect& t1)
{
	Vect min;
	min[x] = Tools::min(t0[x], t1[x]);
	min[y] = Tools::min(t0[y], t1[y]);
	min[z] = Tools::min(t0[z], t1[z]);
	return min;
}

const VertexStride_VUN Tools::min(const VertexStride_VUN& v0, const VertexStride_VUN& v1)
{
	VertexStride_VUN min;
	min.x = Tools::min(v0.x, v1.x);
	min.y = Tools::min(v0.y, v1.y);
	min.z = Tools::min(v0.z, v1.z);
	return min;
}

const Vect Tools::max(const Vect& t0, const Vect& t1)
{
	Vect max;
	max[x] = Tools::max(t0[x], t1[x]);
	max[y] = Tools::max(t0[y], t1[y]);
	max[z] = Tools::max(t0[z], t1[z]);
	return max;
}

bool Tools::intervalIntersect(const float& min0, const float& max0, const float& min1, const float& max1)
{
	return max0 >= min1 && min0 <= max1;
}

const VertexStride_VUN Tools::max(const VertexStride_VUN& v0, const VertexStride_VUN& v1)
{
	VertexStride_VUN max;
	max.x = Tools::max(v0.x, v1.x);
	max.y = Tools::max(v0.y, v1.y);
	max.z = Tools::max(v0.z, v1.z);
	return max;
}

const float Tools::clamp(const float& val, const float& minVal, const float& maxVal)
{
	float retVal;
	if(val < minVal)
	{
		retVal = minVal;
	}
	else if(val > maxVal)
	{
		retVal = maxVal;
	}
	else
	{
		retVal = val;
	}

	return retVal;
}

bool Tools::boxInteresction(const Vect& min0, const Vect& max0, const Vect& min1, const Vect& max1)
{
	return Tools::intervalIntersect(min0[x], max0[x], min1[x], max1[x]) &&
		   Tools::intervalIntersect(min0[y], max0[y], min1[y], max1[y]) &&
		   Tools::intervalIntersect(min0[z], max0[z], min1[z], max1[z]);
}

int Tools::find1DIndex(int row, int col, int matrixLength)
{
	return (int)(row * matrixLength + col);
}
