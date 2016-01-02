
#ifndef DISPOSAlMANAGER_H
#define DISPOSALMANAGER_H

#include <list>

class Destroyable;

class DisposalManager
{
public:
	static void registerDest(Destroyable* const dObj);
	static void deregisterDest(Destroyable* const dObj);
	static void unused(Destroyable* const dObj);

private:
	DisposalManager(){};
	~DisposalManager();
	DisposalManager(const DisposalManager&);
	const DisposalManager& operator=(const DisposalManager&);

	typedef std::list<Destroyable*> ObjectList;
	ObjectList objList;

	static DisposalManager& instance();
	static DisposalManager* dmInstance;
	
	void dispose(const Destroyable* const dObj);

	friend class Scene;


};

#endif // DISPOSALMANAGER_H