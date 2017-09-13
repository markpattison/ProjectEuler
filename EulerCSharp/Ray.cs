using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    public struct Ray
    {
        // NB direction is guaranteed to be normalised

        // private members
        private Point origin;
        private Vector direction;

        // constructor
        public Ray(Point origin, Vector direction)
        {
            this.origin = origin;
            this.direction = direction.Normalised();
        }

        // accessors
        public Point Origin { get { return origin; } set { origin = value; } }
        public Vector Direction { get { return direction; } set { direction = value.Normalised(); } }

        // methods
        public Point Travel(double t)
        {
            return origin + t * direction;
        }
    }
}
