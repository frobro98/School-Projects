
#ifndef DESTROYABLERECEIVER_H
#define DESTROYABLERECEIVER_H

class Destroyable;

class DestroyableReceiver
{
public:
	virtual void receiveObject(Destroyable*) = 0;
};

#endif // DESTROYABLERECEIVER_H