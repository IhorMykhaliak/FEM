using System;
using System.Linq;
using Tao.FreeGlut;
using Tao.OpenGl;
using System.Windows.Forms;
using System.Collections.Generic;

namespace FEM
{
    public partial class MainWindow : Form
    {
        private double scale = 0.18;
        private List<CubeElement> cubeElements;
        private Cube Cube { get; set; }
        private bool showElements = false;
        private int selectedCubeIndex;
        private Point point;

        public MainWindow()
        {
            InitializeComponent();
            glWindow.InitializeContexts();
            Cube = new Cube();
            nudCubeIndex.Visible = false;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // инициализация Glut 
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);

            // отчитка окна 
            Gl.glClearColor(255, 255, 255, 1);

            // установка порта вывода в соответствии с размерами элемента anT 
            Gl.glViewport(0, 0, glWindow.Width, glWindow.Height);

            // настройка проекции 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(45, (float)glWindow.Width / (float)glWindow.Height, 0.1, 200);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            // настройка параметров OpenGL для визуализации 
            Gl.glEnable(Gl.GL_DEPTH_TEST);

            DrawFigure();
        }

        private Point CalculatePoint(Point point, double elementEdgeLength, int z_itr, int y_itr, int x_itr)
        {
            return new Point
            {
                X = x_itr * elementEdgeLength + point.X,
                Y = y_itr * elementEdgeLength + point.Y,
                Z = z_itr * elementEdgeLength + point.Z
            };
        }

        #region Drawing

        private void DrawFigure()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();
            Gl.glPushMatrix();
            Gl.glTranslated(0, 0, -6);
            Gl.glRotated(hsbAxisX.Value, 1.0f, 0.0f, 0.0f);
            Gl.glRotated(hsbAxisY.Value, 0.0f, 1.0f, 0.0f);
            Gl.glRotated(hsbAxisZ.Value, 0.0f, 0.0f, 1.0f);
            Gl.glScaled(scale, scale, scale);

            DrawTopPoints();

            DrawCube(Cube);

            if (showElements && cubeElements?.Count > 1)
            {
                DrawMultipleFigures();
            }

            Gl.glPopMatrix();
            Gl.glFlush();
            glWindow.Invalidate();
        }

        private void DrawSphere(Point point)
        {
            Gl.glColor3d(100, 0, 100);
            //Gl.glColor3d(point.X, point.Y, point.Z);
            Gl.glTranslated(point.X, point.Y, point.Z);
            Glut.glutSolidSphere(0.15f, 5, 5);
            Gl.glTranslated(-point.X, -point.Y, -point.Z);
        }

        private void DrawTopPoints()
        {
            var z = cubeElements?.Max(c => c.Point5.Z);
            if (z != null)
            {
                cubeElements.Where(e => e.ToEnumerable()
                            .Any(p => p.Z == z))
                            .ToList()
                            .ForEach(c => c.ToEnumerable()
                                           .Where(p => p.Z == z)
                                           .ToList()
                                           .ForEach(p => DrawSphere(p)));
            }
        }

        private void DrawMultipleFigures()
        {
            foreach (var cube in cubeElements)
            {
                Gl.glColor3d(0, 1, 0);

                if (selectedCubeIndex != cube.Index)
                {
                    DrawCube(cube, false);
                }
                else
                {
                    DrawCubeOld(cube);
                }

            }
        }

        private void DrawCube(Cube cube, bool setColor = true)
        {
            if (setColor) Gl.glColor3d(cube.Point1.X, cube.Point1.Y, cube.Point1.Z);

            Gl.glBegin(Gl.GL_LINES);
            // front edges
            Gl.glVertex3d(cube.Point1.X, cube.Point1.Y, cube.Point1.Z);
            Gl.glVertex3d(cube.Point2.X, cube.Point2.Y, cube.Point2.Z);

            Gl.glVertex3d(cube.Point1.X, cube.Point1.Y, cube.Point1.Z);
            Gl.glVertex3d(cube.Point4.X, cube.Point4.Y, cube.Point4.Z);

            Gl.glVertex3d(cube.Point3.X, cube.Point3.Y, cube.Point3.Z);
            Gl.glVertex3d(cube.Point4.X, cube.Point4.Y, cube.Point4.Z);

            Gl.glVertex3d(cube.Point3.X, cube.Point3.Y, cube.Point3.Z);
            Gl.glVertex3d(cube.Point2.X, cube.Point2.Y, cube.Point2.Z);

            // back edges
            Gl.glVertex3d(cube.Point5.X, cube.Point5.Y, cube.Point5.Z);
            Gl.glVertex3d(cube.Point6.X, cube.Point6.Y, cube.Point6.Z);

            Gl.glVertex3d(cube.Point5.X, cube.Point5.Y, cube.Point5.Z);
            Gl.glVertex3d(cube.Point8.X, cube.Point8.Y, cube.Point8.Z);

            Gl.glVertex3d(cube.Point7.X, cube.Point7.Y, cube.Point7.Z);
            Gl.glVertex3d(cube.Point8.X, cube.Point8.Y, cube.Point8.Z);

            Gl.glVertex3d(cube.Point7.X, cube.Point7.Y, cube.Point7.Z);
            Gl.glVertex3d(cube.Point6.X, cube.Point6.Y, cube.Point6.Z);

            // other edges
            Gl.glVertex3d(cube.Point1.X, cube.Point1.Y, cube.Point1.Z);
            Gl.glVertex3d(cube.Point5.X, cube.Point5.Y, cube.Point5.Z);

            Gl.glVertex3d(cube.Point4.X, cube.Point4.Y, cube.Point4.Z);
            Gl.glVertex3d(cube.Point8.X, cube.Point8.Y, cube.Point8.Z);

            Gl.glVertex3d(cube.Point3.X, cube.Point3.Y, cube.Point3.Z);
            Gl.glVertex3d(cube.Point7.X, cube.Point7.Y, cube.Point7.Z);

            Gl.glVertex3d(cube.Point2.X, cube.Point2.Y, cube.Point2.Z);
            Gl.glVertex3d(cube.Point6.X, cube.Point6.Y, cube.Point6.Z);

            Gl.glEnd();
        }

        private void DrawCubeOld(Cube cube)
        {
            Gl.glColor3d(0, 0, 1);

            Gl.glBegin(Gl.GL_POLYGON);
            // top
            //Gl.glColor3f(1.0f, 0.0f, 0.0f);
            //Gl.glNormal3f(0.0f, 1.0f, 0.0f);
            Gl.glVertex3d(cube.Point4.X, cube.Point4.Y, cube.Point4.Z);
            Gl.glVertex3d(cube.Point3.X, cube.Point3.Y, cube.Point3.Z);
            Gl.glVertex3d(cube.Point7.X, cube.Point7.Y, cube.Point7.Z);
            Gl.glVertex3d(cube.Point8.X, cube.Point8.Y, cube.Point8.Z);

            Gl.glEnd();

            Gl.glBegin(Gl.GL_POLYGON);
            // front
            //Gl.glColor3f(0.0f, 1.0f, 0.0f);
            //Gl.glNormal3f(0.0f, 0.0f, 1.0f);
            Gl.glVertex3d(cube.Point1.X, cube.Point1.Y, cube.Point1.Z);
            Gl.glVertex3d(cube.Point2.X, cube.Point2.Y, cube.Point2.Z);
            Gl.glVertex3d(cube.Point3.X, cube.Point3.Y, cube.Point3.Z);
            Gl.glVertex3d(cube.Point4.X, cube.Point4.Y, cube.Point4.Z);

            Gl.glEnd();

            Gl.glBegin(Gl.GL_POLYGON);
            // right
            //Gl.glColor3f(0.0f, 0.0f, 1.0f);
            //Gl.glNormal3f(1.0f, 0.0f, 0.0f);
            Gl.glVertex3d(cube.Point2.X, cube.Point2.Y, cube.Point2.Z);
            Gl.glVertex3d(cube.Point3.X, cube.Point3.Y, cube.Point3.Z);
            Gl.glVertex3d(cube.Point7.X, cube.Point7.Y, cube.Point7.Z);
            Gl.glVertex3d(cube.Point5.X, cube.Point5.Y, cube.Point5.Z);

            Gl.glEnd();

            Gl.glBegin(Gl.GL_POLYGON);
            // left
            //Gl.glColor3f(0.0f, 0.0f, 0.5f);
            //Gl.glNormal3f(-1.0f, 0.0f, 0.0f);
            Gl.glVertex3d(cube.Point1.X, cube.Point1.Y, cube.Point1.Z);
            Gl.glVertex3d(cube.Point4.X, cube.Point4.Y, cube.Point4.Z);
            Gl.glVertex3d(cube.Point8.X, cube.Point8.Y, cube.Point8.Z);
            Gl.glVertex3d(cube.Point5.X, cube.Point5.Y, cube.Point5.Z);

            //Gl.glEnd();

            Gl.glBegin(Gl.GL_POLYGON);
            // bottom
            //Gl.glColor3f(0.5f, 0.0f, 0.0f);
            //Gl.glNormal3f(0.0f, -1.0f, 0.0f);
            Gl.glVertex3d(cube.Point1.X, cube.Point1.Y, cube.Point1.Z);
            Gl.glVertex3d(cube.Point2.X, cube.Point2.Y, cube.Point2.Z);
            Gl.glVertex3d(cube.Point6.X, cube.Point6.Y, cube.Point6.Z);
            Gl.glVertex3d(cube.Point5.X, cube.Point5.Y, cube.Point5.Z);

            Gl.glEnd();


            Gl.glBegin(Gl.GL_POLYGON);
            // back
            //Gl.glColor3f(0.0f, 0.5f, 0.0f);
            //Gl.glNormal3f(0.0f, 0.0f, -1.0f);
            Gl.glVertex3d(cube.Point5.X, cube.Point5.Y, cube.Point5.Z);
            Gl.glVertex3d(cube.Point6.X, cube.Point6.Y, cube.Point6.Z);
            Gl.glVertex3d(cube.Point7.X, cube.Point7.Y, cube.Point7.Z);
            Gl.glVertex3d(cube.Point8.X, cube.Point8.Y, cube.Point8.Z);

            Gl.glEnd();
        }

        #endregion

        #region Event Handlers

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.Add)
            {
                scale += 0.02;
            }
            else if (e.KeyCode == Keys.Subtract)
            {
                scale -= 0.02;
            }

            DrawFigure();
        }

        private void ScrollBar_ValueChanged(object sender, EventArgs e)
        {
            DrawFigure();
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            rtb.Text = "";
            int parts = (int)nudParts.Value;
            int zparts = 2 * parts;
            double elementEdgeLength = Cube.EdgeLenght / parts;
            Point p1;

            cubeElements = new List<CubeElement>();
            var index = 0;
            for (int z_itr = 0; z_itr < zparts; z_itr++)
            {
                for (int y_itr = 0; y_itr < parts; y_itr++)
                {
                    for (int x_itr = 0; x_itr < parts; x_itr++)
                    {
                        index++;
                        p1 = CalculatePoint(Cube.Point1, elementEdgeLength, z_itr, y_itr, x_itr);
                        cubeElements.Add(new CubeElement(p1, elementEdgeLength) { Index = index });
                    }
                }
            }
            nudCubeIndex.Visible = true;
            nudCubeIndex.Maximum = cubeElements.Count;
            cbxShowElements.Checked = true;
            DrawFigure();

            //foreach (var cube in cubeElements)
            //{
            //    rtb.Text += cube.ToString()+"\n";
            //    rtb.Text += Environment.NewLine;
            //}
        }

        private void cbxShowElements_CheckedChanged(object sender, EventArgs e)
        {
            showElements = cbxShowElements.Checked;
            nudCubeIndex.Visible = showElements;
            DrawFigure();
        }

        private void nudCubeIndex_ValueChanged(object sender, EventArgs e)
        {
            selectedCubeIndex = (int)nudCubeIndex.Value;
            DrawFigure();
        }

        private void btnDrawPoint_Click(object sender, EventArgs e)
        {

        }

        private void btnDrawPoint_Click_1(object sender, EventArgs e)
        {
            var coords = txtPointCoord.Text.Split(new char[] { ',', ';', ' ' });
            point = new Point(double.Parse(coords?[0]), double.Parse(coords?[1]), double.Parse(coords?[2]));
            DrawFigure();
        }

        #endregion

    }
}
