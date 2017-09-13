using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.EulerCSharp._3D
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

    public struct Vector
    {
        // private members
        private double x, y, z;

        // constructor
        public Vector(double x, double y, double z)
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
        public double LengthSqd
        {
            get
            {
                return x * x + y * y + z * z;
            }
        }

        public double Length
        {
            get
            {
                return Math.Sqrt(x * x + y * y + z * z);
            }
        }

        // methods
        public Vector Normalised()
        {
            double l = Length;

            if (l > 0)
            {
                return new Vector(x / l, y / l, z / l);
            }
            else
            {
                throw new InvalidOperationException("Cannot normalise vector of length zero");
            }
        }

        public double Dot(Vector v2)
        {
            return x * v2.x + y * v2.y + z * v2.z;
        }

        public double PositiveDot(Vector v2)
        {
            return Math.Max(0.0, x * v2.x + y * v2.y + z * v2.z);
        }

        public Vector Cross(Vector v2)
        {
            return new Vector(y * v2.z - z * v2.y, z * v2.x - x * v2.z, x * v2.y - y * v2.x);
        }

        // operators
        public static Vector operator -(Vector v)
        {
            return new Vector(-v.x, -v.y, -v.z);
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static Vector operator *(Vector v, double d)
        {
            return new Vector(v.x * d, v.y * d, v.z * d);
        }

        public static Vector operator *(double d, Vector v)
        {
            return new Vector(v.x * d, v.y * d, v.z * d);
        }

        public static Vector operator /(Vector v, double d)
        {
            if (d != 0)
            {
                return new Vector(v.x / d, v.y / d, v.z / d);
            }
            else
            {
                throw new InvalidOperationException("Cannot divide vector by scalar value of zero");
            }
        }

        public static bool operator ==(Vector v1, Vector v2)
        {
            return (v1.x == v2.x && v1.y == v2.y && v1.z == v2.z);
        }

        public static bool operator !=(Vector v1, Vector v2)
        {
            return !(v1 == v2);
        }

        public override bool Equals(object obj)
        {
            try
            {
                return (bool)(this == (Vector)obj);
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
