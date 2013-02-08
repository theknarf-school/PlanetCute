using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetCute_ida
{
    class Animation
    {
        public float[] from;
        public float[] to;

        public int step  = 0;
        public int steps = 100;

        public Animation(int size)
        {
            this.from = new float[size];
            this.to =   new float[size];
        }

        public void next()
        {
            if(step<steps) step++;

            for (int i = 0; i < this.from.Length; i++)
            {
                this.from[i] = (this.to[i] - this.from[i]) * (this.steps - this.step);
            }
        }

    }
}
