using System;
using System.Collections;
using System.Collections.Generic;

namespace FEM
{
    public class Cube
    {
        /// <summary>
        /// Front bottom left point
        /// </summary>
        public Point Point1 { get; set; } = new Point(-5, -5, -10);
        /// <summary>
        /// Front bottom right point
        /// </summary>
        public Point Point2 { get; set; } = new Point(5, -5, -10);
        /// <summary>
        /// Front top right point
        /// </summary>
        public Point Point3 { get; set; } = new Point(5, 5, -10);
        /// <summary>
        /// Front top left point
        /// </summary>
        public Point Point4 { get; set; } = new Point(-5, 5, -10);
        /// <summary>
        /// Back bottom left point
        /// </summary>
        public Point Point5 { get; set; } = new Point(-5, -5, 10);
        /// <summary>
        /// Back bottom right point
        /// </summary>
        public Point Point6 { get; set; } = new Point(5, -5, 10);
        /// <summary>
        /// Back top right point
        /// </summary>
        public Point Point7 { get; set; } = new Point(5, 5, 10);
        /// <summary>
        /// Back top left point
        /// </summary>
        public Point Point8 { get; set; } = new Point(-5, 5, 10);

        public double EdgeLenght { get; set; } = 10;

        public Cube()
        {

        }

        public Cube(Point FbL, Point FbR, Point FtR, Point FtL, Point BbL, Point BbR, Point BtR, Point BtL)
        {
            this.Point1 = FbL;
            this.Point2 = FbR;
            this.Point3 = FtR;
            this.Point4 = FtL;
            this.Point5 = BbL;
            this.Point6 = BbR;
            this.Point7 = BtR;
            this.Point8 = BtL;
        }

        public override string ToString()
        {
            string res = "";
            res += string.Format("Point1- {0}\n", Point1.ToString());
            res += string.Format("Point2- {0}\n", Point2.ToString());
            res += string.Format("Point3- {0}\n", Point3.ToString());
            res += string.Format("Point4- {0}\n", Point4.ToString());
            res += string.Format("Point5- {0}\n", Point5.ToString());
            res += string.Format("Point6- {0}\n", Point6.ToString());
            res += string.Format("Point7- {0}\n", Point7.ToString());
            res += string.Format("Point8- {0}\n", Point8.ToString());
            res += string.Format("Edge- {0}", EdgeLenght);
            return res;
        }
    }

    public class CubeElement : Cube
    {
        public int Index { get; set; }

        public Point MiddlePoint9 { get { return GetMiddle(Point1, Point2); } }
        public Point MiddlePoint10 { get; }
        public Point MiddlePoint11 { get; }
        public Point MiddlePoint12 { get; }
        public Point MiddlePoint13 { get; }
        public Point MiddlePoint14 { get; }
        public Point MiddlePoint15 { get; }
        public Point MiddlePoint16 { get; }
        public Point MiddlePoint17 { get; }
        public Point MiddlePoint18 { get; }
        public Point MiddlePoint19 { get; }
        public Point MiddlePoint20 { get; }

        public CubeElement(Point p1, Point p2, Point p3, Point p4, Point p5, Point p6, Point p7, Point p8)
            : base(p1, p2, p3, p4, p5, p6, p7, p8)
        {

        }

        public CubeElement(Point FbL, double edgeLength)
        {
            Point1 = FbL;
            EdgeLenght = edgeLength;
            CalculatePoints();
        }

        private Point GetMiddle(Point fir, Point sec)
        {
            return new Point((fir.X + sec.X) / 2, (fir.Y + sec.Y) / 2, (fir.Z + sec.Z) / 2);
        }

        private void CalculatePoints()
        {
            Point2 = new Point(Point1); Point2.X += EdgeLenght;
            Point3 = new Point(Point2); Point3.Y += EdgeLenght;
            Point4 = new Point(Point3); Point4.X -= EdgeLenght;
            Point5 = new Point(Point1); Point5.Z += EdgeLenght;
            Point6 = new Point(Point2); Point6.Z += EdgeLenght;
            Point7 = new Point(Point3); Point7.Z += EdgeLenght;
            Point8 = new Point(Point4); Point8.Z += EdgeLenght;
        }

        public IEnumerable<Point> ToEnumerable()
        {
            yield return Point1;
            yield return Point2;
            yield return Point3;
            yield return Point4;
            yield return Point5;
            yield return Point6;
            yield return Point7;
            yield return Point8;
        }
    }

    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point() { }

        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point (Point p)
        {
            X = p.X;
            Y = p.Y;
            Z = p.Z;
        }

        public override string ToString()
        {
            return string.Format("X:{0},Y:{1},Z:{2}", X, Y, Z);
        }
    }

}