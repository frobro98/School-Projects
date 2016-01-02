
#ifndef ITERATOR_H
#define ITERATOR_H

class PCSNode;

class Iterator
{
public:
	virtual ~Iterator(){}

	virtual PCSNode* first() = 0;
	virtual void next() = 0;
	virtual PCSNode* current() const = 0;
	virtual bool atEnd() = 0;

	virtual PCSNode* operator++(int) = 0;

};

#endif // ITERATOR_H