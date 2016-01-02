
#ifndef DESTROYABLE_H
#define DESTROYABLE_H

#include "DisposalManager.h"

class DestroyableReceiver;

class Destroyable
{
public:
	Destroyable();
	virtual ~Destroyable(){};

	/**
	 \brief This method tells the system that the object is ready to be 
	 destroyed.
	 */
	void willDestroy();

	
	/**
	 \brief This method tells the system that they will manage their specific
	 Destroyable object.
	
	 \param	recyclingObj			A pointer to an object that will handle the current
									Destoryable object when it gets destroyed.

	 \ingroup DESTROYABLE
	 */
	void userWillManage(DestroyableReceiver* const recyclingObj);

	/**
	 \brief A method that will be called right before the correct destruction
	 of a Destroyable object. It is used for cleaning up the registrations of 
	 the object.

	 If the object registered for the InputManager, CollisionManager, or the
	 AlarmManager, it would be in this method to deregister from them.

	 \ingroup DESTROYABLE
	 */
	virtual void destroy() = 0;
	virtual void predestruction(){};

private:
	DestroyableReceiver* managingObj;

	bool remove;
	bool userManaged;

	friend void DisposalManager::unused(Destroyable* const dObj);
};

#endif // DESTROYABLE_H