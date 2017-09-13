using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    public struct Point
    {
        // private members
        private double x, y, z;

        // constructor
        public Point(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        // accessors
        public double X { get { return x; } set { x = value; } }
        public double Y { get { return y; } set { y = value; } }
        public double Z { get { return z; } set { z = value; } }

        // properties

        // methods
        public Vector ToVector()
        {
            return new Vector(x, y, x);
        }

        // operators
        public static Point operator +(Point p, Vector v)
        {
            return new Point(p.x + v.X, p.y + v.Y, p.z + v.Z);
        }

        public static Point operator -(Point p, Vector v)
        {
            return new Point(p.x - v.X, p.y - v.Y, p.z - v.Z);
        }

        public static Vector operator -(Point p1, Point p2)
        {
            return new Vector(p1.x - p2.x, p1.y - p2.y, p1.z - p2.z);
        }

        public static bool operator ==(Point p1, Point p2)
        {
            return (p1.x == p2.x && p1.y == p2.y && p1.z == p2.z);
        }

        public static bool operator !=(Point p1, Point p2)
        {
            return !(p1 == p2);
        }

        public override bool Equals(object obj)
        {
            try
            {
                return (bool)(this == (Point)obj);
            }
            catch
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return (String.Format("({0},{1},{2})", x, y, z));
        }
    }
}

