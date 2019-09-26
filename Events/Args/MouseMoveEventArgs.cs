using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKHook5.Events.Args
{
    public class MouseMoveEventArgs
    {
        private float oldX;
        private float newX;

        private float oldY;
        private float newY;


        public MouseMoveEventArgs(float oldX, float newX, float oldY, float newY)
        {
            this.oldX = oldX;
            this.newX = newX;

            this.oldY = oldY;
            this.newY = newY;
        }
        public float getOldX()
        {
            return oldX;
        }
        public float getNewX()
        {
            return newX;
        }

        public float getOldY()
        {
            return oldY;
        }
        public float getNewY()
        {
            return newY;
        }
    }
}
