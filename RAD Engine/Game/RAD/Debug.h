

#ifndef DEBUG_H
#define DEBUG_H

#include <string.h>

class Debug
{
public:
	// Writes error to window
	static void writeError(const char* const message, const char* const file, const int &line);

};

#endif // DEBUG_H