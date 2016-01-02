
#ifndef UPDATEABLE_H
#define UPDATEABLE_H

class Updateable
{
public:

	/**
	 \brief Allows Updateable objects to be connected to the update loop.
	 The update loop gets called every frame.

	 \ingroup UPDATEABLE
	 */

	virtual void update() = 0;

protected:
	Updateable();
	virtual ~Updateable();
};

#endif //UPDATEABLE_H