

#include "PCSNode.h"

PCSNode::PCSNode()
{
	parent = 0;
	child = 0;
	sibling = 0;
}

PCSNode::~PCSNode()
{
	parent = 0;
	delete child;
	child = 0;
	delete sibling;
	sibling = 0;
}

void PCSNode::setChild(PCSNode* const c)
{
	if(c != 0)
	{
		c->sibling = this->child;
		c->parent = this;
		this->child = c;
	}
}

PCSNode* PCSNode::getChild() const
{
	return child;
}

void PCSNode::setParent(PCSNode* const parent)
{
	this->parent = parent;
}

PCSNode* PCSNode::getParent() const
{
	return parent;
}

void PCSNode::setSibling(PCSNode* const sibling)
{
	this->sibling = sibling;
}

PCSNode* PCSNode::getSibling() const
{
	return sibling;
}