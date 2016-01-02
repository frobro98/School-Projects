

#include "OctreeIterator.h"
#include "PCSNode.h"

OctreeIterator::OctreeIterator(PCSNode* begin)
	: beginNode(begin), currentNode(begin)
{
}

OctreeIterator::~OctreeIterator()
{
	// Do nothing. All data isn't owned by class
}

PCSNode* OctreeIterator::first()
{
	currentNode = beginNode;
	return beginNode;
}

void OctreeIterator::next()
{
	 currentNode = getNext(currentNode);
}

PCSNode* OctreeIterator::operator++(int)
{
	currentNode = getNext(currentNode);
	return currentNode;
}

PCSNode* OctreeIterator::getNext(const PCSNode* const node, bool moveChild)
{
	PCSNode* tmp = 0;
	PCSNode* child = 0;
	PCSNode* par = 0;
	PCSNode* sib = 0;
	if(node != 0)
	{
		child = node->getChild();
		par = node->getParent();
		sib = node->getSibling();
	}

	if(child && moveChild)
	{
		tmp = child;
	}
	else if(sib && !moveChild)
	{
		tmp = sib;
	}
	else if(!child && sib)
	{
		tmp = sib;
	}
	else if(par && par != this->beginNode)
	{
		tmp = getNext(par, false);
	}

	return tmp;
}

PCSNode* OctreeIterator::current() const 
{
	return currentNode;
}

bool OctreeIterator::atEnd()
{
	return currentNode == 0;
}