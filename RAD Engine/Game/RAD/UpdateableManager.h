
#ifndef UPDATEABLEMANAGER_H
#define UPDATEABLEMANAGER_H

#include <list>

class Updateable;

// WILL MAKE SINGLETON

class UpdateableManager
{
public:
	/**
	 \brief Registers Updateable objects. The GameObject class registers to the 
	 UpdateableManager automatically.
	
	 \param updateObj			Updateable object.
	 \ingroup UPDATEABLE
	 */
	static void registerUpdateable(Updateable* updateObj);

	/**
	 \brief Deregisters Updateable objects
	
	 \param updateObj			Updateable object
	 \ingroup UPDATEABLE
	 */
	static void deregisterUpdateable(Updateable* updateObj);

	void Update();

private:
	UpdateableManager(){};
	~UpdateableManager();
	UpdateableManager(const UpdateableManager&);
	const UpdateableManager& operator=(const UpdateableManager&);

	static UpdateableManager& instance()
	{
		if(umInstance == 0)
		{
			umInstance = new UpdateableManager();
		}

		return *umInstance;
	}

	typedef std::list<Updateable*> UpdateList;

	UpdateList uList;
	static UpdateableManager* umInstance;

	friend class Scene;
};


#endif // UPDATEABLEMANAGER_H