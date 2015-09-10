using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    interface Iterator
    {
        GameObject first();
        void moveNext();
        GameObject getCurrent();
        bool atEnd();
    }
}
