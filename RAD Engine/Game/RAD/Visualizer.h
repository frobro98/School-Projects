
#ifndef VISUALIZER_H
#define VISUALIZER_H

#include <stack>
#include <queue>

#include "Vect.h"
#include "Matrix.h"

#define DEFAULT Vect(1.f, 0.f, 0.f)

class GraphicsObjectWireFrame;

class Visualizer
{
	friend class Game;
public:
	static void initialize();
	static void showSphere(const Vect& center, const float& radius, const Vect& color = DEFAULT);
	static void showAABB(const Vect& min, const Vect& max, const Vect& color = DEFAULT);
	static void showMarker(const Vect& pos, const Vect& color = DEFAULT, const float& radius = 1);

private:
	static Visualizer& instance();

	struct VisualData
	{
		VisualData() { visModel = 0; world = Matrix(IDENTITY); }

		GraphicsObjectWireFrame* visModel;
		Matrix world;
		Vect color;
	};

	typedef std::stack<VisualData*> RecycledVisStructs;
	typedef std::queue<VisualData*> CurrVisData;

	CurrVisData willRender;
	RecycledVisStructs recyclying;

	static void render();
	void recycleData(VisualData* const rData);

	GraphicsObjectWireFrame* unitBox;
	GraphicsObjectWireFrame* unitSphere;
};


#endif // VISUALIZER_H