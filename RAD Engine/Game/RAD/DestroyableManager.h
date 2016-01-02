
#ifndef TERMINATABLEMANAGER_H
#define TERMINATABLEMANAGER_H

#include <list>
#include "DestroyableReceiver.h"

class Destroyable;

class DestroyableManager : public DestroyableReceiver
{
public:

	void receiveObject(Destroyable* toDestroy) override;

	static DestroyableManager& instance();

private:
	DestroyableManager(){};
	~DestroyableManager();

	void terminateObjs();
	void managerDeregister();

	static DestroyableManager* dmInstance;

	typedef std::list<Destroyable*> destroyList;
	destroyList dList;

	friend class Scene;
};

#endif //TERMINATABLEMANAGER_H