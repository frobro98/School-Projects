
#ifndef OCTREEITERATOR_H
#define OCTREEITERATOR_H

#include "Iterator.h"

class OctreeIterator : public Iterator
{
public:

	OctreeIterator(PCSNode* beginningNode);
	~OctreeIterator();

	// Iterator interface
	PCSNode* first() override;
	void next() override;
	PCSNode* current() const override;
	bool atEnd() override;

	PCSNode* operator++(int) override;

private:
	PCSNode* beginNode;
	PCSNode* currentNode;

	PCSNode* getNext(const PCSNode* const node, bool moveToChild = true);

	OctreeIterator();
};

#endif // OCTREEITERATOR_H