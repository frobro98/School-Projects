
#pragma once

class Model;
class CollisionVolume;

struct ModelInfo
{
	Model* model;
	CollisionVolume* volumeChildren;
};

class ModelInfoCreator
{
public:
	ModelInfoCreator(){};

	ModelInfoCreator(Model* colModel) 
	{ 
		model = colModel; 
	}

	~ModelInfoCreator();

	ModelInfo createModelHierarchy(Model* const model) const;

	Model* getModel() const   { return model; }
	void setModel(Model* mod) { model = mod;  }

private:
	Model* model;
};