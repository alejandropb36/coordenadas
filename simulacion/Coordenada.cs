using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulacion
{
    class Coordenada
    {
        private float x;
        private float y;

        public void setX(float x)
        {
            this.x = x;
        }

        public void setY(float y)
        {
            this.y = y;
        }

        public float getX()
        {
            return x;
        }

        public float getY()
        {
            return y;
        }
    }
}
