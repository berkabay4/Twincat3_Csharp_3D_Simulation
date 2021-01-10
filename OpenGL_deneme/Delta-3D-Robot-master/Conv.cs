using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL;

namespace SharpGLWinformsApplication1
{

    
    class Conv
    {

 public void DrawUnitCylinder(ref OpenGL gl/*, int numSegs, vec3 Pos, float fHieght, float fRadius*/)
 {
     int i;
     float[] Px = new float[390];
     float[] Py = new float[390];
     float AngIncr = (2.0f * 3.1415927f) / (float)390;
     float Ang = AngIncr;
     Px[0] = 1;
     Py[0] = 0;
     for (i = 1; i < 390; i++, Ang += AngIncr)
     {
         Px[i] = (float)Math.Cos(Ang);
         Py[i] = (float)Math.Sin(Ang);
     }
     gl.MatrixMode(OpenGL.GL_MODELVIEW);
     gl.PushMatrix();
     {
         gl.Translate(0.5f, 0.5f, 0.5f);
         gl.Scale(0.5f, 0.5f, 0.5f);
         gl.Normal(0, 1, 0);
         gl.Begin(OpenGL.GL_TRIANGLE_FAN);
         gl.Vertex(0, 1, 0);
         for (i = 0; i < 390; i++)
             gl.Vertex(Px[i], 1, -Py[i]);
         gl.Vertex(Px[0], 1, -Py[0]);
         gl.End();
         // Bottom
         gl.Normal(0, -1, 0);
         gl.Begin(OpenGL.GL_TRIANGLE_FAN);
         gl.Vertex(0, -1, 0);
         for (i = 0; i < 390; i++)
             gl.Vertex(Px[i], -1, Py[i]);
         gl.Vertex(Px[0], -1, Py[0]);
         gl.End();
         // Sides
         gl.Begin(OpenGL.GL_QUAD_STRIP);
         for (i = 0; i < 390; i++)
         {
             gl.Normal(Px[i], 0, -Py[i]);
             gl.Vertex(Px[i], 1, -Py[i]);
             gl.Vertex(Px[i], -1, -Py[i]);
         }
         gl.Normal(Px[0], 0, -Py[0]);
         gl.Vertex(Px[0], 1, -Py[0]);
         gl.Vertex(Px[0], -1, -Py[0]);
         gl.End();
     }
     gl.PopMatrix();

 }


        public void DrawObj(ref OpenGL gl,float ObjPosX, float ObjPosY, float ObjPosZ)
        {
       

            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl.PushMatrix();
            {
                gl.Translate(ObjPosY, ObjPosZ, ObjPosX);
                gl.Scale(1, 0.3f, 1);
                gl.Color(0f, 1f, 0f);
                DrawUnitCylinder(ref gl);
            }
            gl.PopMatrix();

            gl.End();
        }


        public   void DrawLine(ref OpenGL gl)
        {

            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(100.0f, 100.0f, 0.0f); // origin of the line
            gl.Vertex(200.0f, 140.0f, 5.0f); // ending point of the line
            gl.End();
    
        }

           public void DrawPlane(ref OpenGL gl/*, int numSegs, vec3 Pos*/)
           {
               gl.Color(0.7f, 0.7f, 0.7f);
               gl.Begin(OpenGL.GL_QUADS);
                gl.PushMatrix();

               gl.Vertex(-5,  -12f, 15);
               gl.Vertex(5,   -12f, 15);
               gl.Vertex(5,   -12f, -15);
               gl.Vertex(-5,  -12f, -15);

              gl.End();
              gl.PopMatrix();

        }


        public void DrawBox(ref OpenGL gl/*, int numSegs, vec3 Pos*/)
        {
            gl.Color(0.2f, 0.1f, 0.4f);
            gl.Begin(OpenGL.GL_QUADS);
            gl.PushMatrix();

            gl.Vertex(12, -12f, 5);
            gl.Vertex(8, -12f, 5);
            gl.Vertex(8, -12f, -5);
            gl.Vertex(12, -12f, -5);

            gl.End();
            gl.PopMatrix();

        }



    }
}
