using System;

namespace SpaceInvaders
{
    interface State
    {
        void handle(Context context);
    }
}
