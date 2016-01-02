
#include <stdio.h>
#include <stdlib.h>


#include "Debug.h"

void Debug::writeError(const char*  const mess, const char* const file, const int &line)
{
	printf("%s, file:%s, line:%d", mess, file, line);
	exit(1);
}