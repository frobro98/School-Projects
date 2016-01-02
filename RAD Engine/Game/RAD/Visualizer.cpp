

#include "Visualizer.h"
#include "AssetManager.h"
#include "Azul.h"

Visualizer& Visualizer::instance()
{
	static Visualizer vis;

	return vis;
}

void Visualizer::initialize()
{
	instance().unitBox = new GraphicsObjectWireFrame(AssetManager::retrieveModel("box"));
	instance().unitSphere = new GraphicsObjectWireFrame(AssetManager::retrieveModel("sphere"));
}

void Visualizer::showSphere(const Vect& center, const float& radius, const Vect& color)
{
	VisualData* data;

	if(!instance().recyclying.empty())
	{
		data = instance().recyclying.top();
		instance().recyclying.pop();
	}
	else
	{
		data = new VisualData();
	}

	Matrix scale(SCALE, radius, radius, radius);
	Matrix trans(TRANS, center[x], center[y], center[z]);
	Matrix world = scale * trans;

	data->color = color;
	data->visModel = instance().unitSphere;
	data->world = world;

	instance().willRender.push(data);
}

void Visualizer::showAABB(const Vect& min, const Vect& max, const Vect& color)
{
	VisualData* data;
	if(!instance().recyclying.empty())
	{
		data = instance().recyclying.top();
		instance().recyclying.pop();
	}
	else
	{
		data = new VisualData;
	}

	Matrix scale(SCALE, max - min);
	Matrix trans(TRANS, (max+min)*.5);
	Matrix world = scale * trans;

	data->color = color;
	data->visModel = instance().unitBox;
	data->world = world;

	instance().willRender.push(data);
}

void Visualizer::showMarker(const Vect& pos, const Vect& color, const float& radius)
{
	VisualData* data;
	if(!instance().recyclying.empty())
	{
		data = instance().recyclying.top();
		instance().recyclying.pop();
	}
	else
	{
		data = new VisualData;
	}

	Matrix scale(SCALE, radius, radius, radius);
	Matrix trans(TRANS, pos);
	data->world = scale * trans;
	data->visModel = instance().unitSphere;
	data->color = color;

	instance().willRender.push(data);
}

void Visualizer::recycleData(VisualData* const rData)
{
	recyclying.push(rData);
}

void Visualizer::render()
{
	while(!instance().willRender.empty())
	{
		VisualData* renderData = instance().willRender.front();
		renderData->visModel->color = renderData->color;
		renderData->visModel->setWorld(renderData->world);

		renderData->visModel->Render();

		instance().willRender.pop();
	}
}