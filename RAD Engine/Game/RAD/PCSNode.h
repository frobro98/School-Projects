
#ifndef PCSNODE_H
#define PCSNODE_H

class CollisionVolume;

class PCSNode
{
public:
	PCSNode();
	virtual ~PCSNode();
	/*PCSNode(const PCSNode&){};
	const PCSNode operator=(const PCSNode&){};*/

	PCSNode(CollisionVolume* volume);

	PCSNode* getParent() const;
	PCSNode* getChild() const;
	PCSNode* getSibling() const;

	void setParent(PCSNode* const parNode);
	void setChild(PCSNode* const childNode);
	void setSibling(PCSNode* const sibNode);

protected:
	PCSNode* parent;
	PCSNode* child;
	PCSNode* sibling;
};

#endif // PCSNODE_H