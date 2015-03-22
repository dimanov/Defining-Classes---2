/* Problem 1. Structure
Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space.
Implement the ToString() to enable printing a 3D point.
*/
/*Problem 2. Static read-only field
Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}.
Add a static property to return the point O.
 */
using System.Linq;

namespace DefiningClasses
{
    using System;

    public struct Point3D
    {
        private double x;
        private double y;
        private double z;
        private static readonly Point3D o;

        public double X
        {
            get { return this.x; }
            private set { this.x = value; }
        }

        public double Y
        {
            get { return this.y; }
            private set { this.y = value; }
        }

        public double Z
        {
            get { return this.z; }
            private set { this.z = value; }
        }

        public Point3D(double xCoord, double yCoord, double zCoord) : this()
        {
            this.X = xCoord;
            this.Y = yCoord;
            this.Z = zCoord;
        }

        public override string ToString()
        {
            return string.Format("X = {0}; Y = {1}; Z = {2}", this.X, this.Y, this.Z);
        }

        public static Point3D O
        {
            get { return o; }
        }

        static Point3D()
        {
            o = new Point3D(0, 0, 0);
        }

        internal static Point3D Parse(string nextPointTxt)
        {
            throw new NotImplementedException();
        }
    }
}
