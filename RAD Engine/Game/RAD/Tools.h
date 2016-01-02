
#ifndef TOOLS_H
#define TOOLS_H

#define UNUSED_VAR(x) (void)x
#define UNUSED_VARS(...) (void)__VA_ARGS__

class Vect;
class Model;
struct VertexStride_VUN;

#include <stdio.h>
#include <Windows.h>

#ifdef WIN32
	#undef max
	#undef min
	#undef out
#endif

namespace Tools
{
	// This is for a macro
	// DON'T EVER USE
	/*extern char buff[256];

	#define out(A, ...) sprintf_s(buff,A,##__VA_ARGS__);\
						OutputDebugString(buff);
*/
	const float dist(const Vect& vect1, const Vect& vect2);
	
	const Vect min(const Vect& v0, const Vect& v1);
	const VertexStride_VUN min(const VertexStride_VUN& v0, const VertexStride_VUN& v1);
	const Vect max(const Vect& v0, const Vect& v1);
	const VertexStride_VUN max(const VertexStride_VUN& v0, const VertexStride_VUN& v1);

	inline float min(const float& t0, const float& t1)
	{
		float minVal = (t0 < t1) ? t0 : t1;
		return minVal;
	}
	inline float max(const float& t0, const float& t1)
	{
		float maxVal = (t0 < t1) ? t1 : t0;
		return maxVal;
	}

	const float clamp(const float& val, const float& minVal, const float& maxVal);
	bool inInterval(const float& p, const float& interval0, const float& interval1);
	bool intervalIntersect(const float& min0, const float& max0, const float& min1, const float& max1);
	bool boxInteresction(const Vect& min0, const Vect& max0, const Vect& min1, const Vect& max1);

	int find1DIndex(int row, int col, int matrixLength);
};

#endif // TOOLS_H