using System;

namespace SpaceInvaders
{
    abstract class Command
    {

        protected Command()
        {
        }

        abstract public void execute(float time);
    }
}
