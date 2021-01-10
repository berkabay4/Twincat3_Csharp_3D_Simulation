using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL;

namespace SharpGLWinformsApplication1
{
    class RobotComponent
    {
        static vec3 baseTrans = new vec3(-0.5f, 0, 0);
        static float baseSpin = 0;

        public void DrawCircle(ref OpenGL gl/*, int numSegs, vec3 Pos*/)
        {
            gl.Begin(OpenGL.GL_TRIANGLE_FAN);
            gl.Vertex(0.0f, 0.0f, 0.0f);
            int i = 0;
            for (i = 0; i <= 390; i += 15)
            {
                float p = (float)(i * 3.14 / 180);
                gl.Vertex(Math.Sin(p), Math.Cos(p), 0.0f);
            }
            gl.End();
            gl.PopMatrix();
        }

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

        public void DrawUnitCylinder(ref OpenGL gl, vec3 vTop, vec3 vBottom)
        {
            int i;
            
            float[] Px = new float[390];
            float[] Py = new float[390];
            float[] Qx = new float[390];
            float[] Qy = new float[390];

            float AngIncr = (float)(2*Math.PI) / (float)390;
            float Ang = AngIncr;
            
            Px[0] = 0.5f + vTop.x;
            Py[0] = 0 + vTop.y;
            Qx[0] = 0.5f + vBottom.x;
            Qy[0] = 0 + vBottom.y;
            for (i = 1; i < 390; i++, Ang += AngIncr)
            {
                Px[i] = (float) Math.Cos(Ang)/2 + vTop.x;
                Py[i] = (float) Math.Sin(Ang)/2 + vTop.y;
                Qx[i] = (float)Math.Cos(Ang) / 2 + vBottom.x;
                Qy[i] = (float)Math.Sin(Ang) / 2 + vBottom.y;
            }

            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl.PushMatrix();
            {
                //gl.Translate(0.5f, 0.5f, 0.5f);
                //gl.Scale(0.5f, 0.5f, 0.5f);
                // Sides
                gl.Begin(OpenGL.GL_QUAD_STRIP);
                for (i = 0; i < 390; i++)
                {
                    //gl.Normal(Px[i]-Qx[i], 0, -(Py[i]-Qy[i]));
                    gl.Vertex(Px[i], vTop.z, -Py[i]);
                    gl.Vertex(Qx[i], vBottom.z, -Qy[i]);
                }
                //gl.Normal(Px[0], 0, -Py[0]);
                gl.Vertex(Px[0], vTop.z, -Py[0]);
                gl.Vertex(Qx[0], vBottom.z, -Qy[0]);
                gl.End();
            }
            gl.PopMatrix();

        }

        public void DrawUnitSphere(ref OpenGL gl, int numSegs, vec3 Pos, double dRadius, int iSegX, int iSegY)
        {
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl.PushMatrix();
            {
                gl.Translate(Pos.x, Pos.y, Pos.z);
                var sphere = gl.NewQuadric();
                gl.QuadricDrawStyle(sphere, OpenGL.GL_QUADS);
                gl.QuadricNormals(sphere, OpenGL.GLU_SMOOTH);
                gl.QuadricOrientation(sphere, (int)OpenGL.GLU_OUTSIDE);
                gl.QuadricTexture(sphere, (int)OpenGL.GL_FALSE);
                gl.Sphere(sphere, dRadius, iSegX, iSegY);
                gl.DeleteQuadric(sphere);
            }
            gl.PopMatrix();
        }

        public void DrawUnitCone(ref OpenGL gl)
        {
            //int i;
            //var P = new List<vec3>();
            //float AngIncr = (2.0f * PI) / (float)numSegs;
            //float Ang = AngIncr;
            //for (i = 0; i < numSegs; i++, Ang += AngIncr)
            //{
            //    P.Add(new vec3((float)Math.Cos(Ang),
            //                   (float)Math.Sin(Ang),
            //                   0));
            //}

            ////gl.MatrixMode(OpenGL.GL_MODELVIEW);
            //gl.PushMatrix();
            //gl.Translate(Pos.x, Pos.y, Pos.z);
            //gl.Normal(0, fHieght, 0);
            //gl.Begin(OpenGL.GL_TRIANGLE_FAN);
            //gl.Vertex(Pos.x, Pos.y + fHieght, Pos.z);
            //for (i = 0; i < numSegs; i++)
            //    gl.Vertex(fRadius*P[i].x, 0, -fRadius*P[i].y);
            //gl.Vertex(Pos.x,Pos.y,Pos.z);
            //gl.End();
            gl.Rotate(-90, 1, 0, 0);
            gl.Begin(OpenGL.GL_QUAD_STRIP);//连续填充四边形串
            int i = 0;
            for (i = 0; i <= 390; i++)
            {
                float p =(float)( i * 3.14 / 180);
                gl.Vertex(0, 0, 1.0f);
                gl.Vertex(Math.Sin(p), Math.Cos(p), 0.0f);
            }
            gl.End();
            DrawCircle(ref gl);

        }

        public void DrawJoint(ref OpenGL gl)        //Joints -- Col Ch Ab
        {
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl.PushMatrix();
            gl.Scale(1.5f, 1.5f, 1.2f);
            gl.Rotate(90, 1, 0, 0);
            gl.Translate(-0.5f, -0.5f, -0.5f);
            gl.Color(1.0f, 1.0f, 1);
            DrawUnitCylinder(ref gl);
            gl.PopMatrix();
        }

        public void DrawBase(ref OpenGL gl)
        {
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl.PushMatrix();
            {
                gl.Scale(2f, 0.2f, 2f);
                gl.Translate(-0.5f, 0, -0.5f);
                gl.Color(0,1f,1f);
                DrawUnitCylinder(ref gl);
            }

            gl.PopMatrix();
            gl.PushMatrix();
            {
                gl.Translate(-0.5f, 0, -0.5f);
                gl.Scale(1f, 4f, 1f);
                gl.Color(0.5f, 1.0f, 0.5f);//color arm 
                DrawUnitCylinder(ref gl);
            }
            gl.PopMatrix();

            gl.PushMatrix();
            { 
                gl.Translate(0f, 4f, 0);
                //gl.Scale(4f, 8f, 4f);
                DrawJoint(ref gl);
            }
            gl.PopMatrix();
        }

        public void DrawArmSegment(ref OpenGL gl)
        {
        // gl.MatrixMode(OpenGL.GL_MODELVIEW);
        // gl.PushMatrix();
        // gl.Translate(-0.5f, 0, -0.5f);
        // gl.Scale(1f, 5f, 1f);
        // gl.Color(1.0f, 1f, 1.0f);//color arm 
        // DrawUnitCylinder(ref gl);
        // gl.PopMatrix();
        //
        // gl.PushMatrix();
        // gl.Translate(0, 5.5f, 0);
        // DrawJoint(ref gl);
        // gl.PopMatrix();
        }

        public void DrawWrist(ref OpenGL gl)        //Usx
        {
       gl.MatrixMode(OpenGL.GL_MODELVIEW);
       gl.PushMatrix();
       {
           gl.Color(0f, 1f, 0f);
           gl.Translate(-0.4f, 0, -0.4f);
           gl.Scale(0.8f, 2f, 0.8f);
       
           DrawUnitCylinder(ref gl);
       }
       gl.PopMatrix();
       
       gl.PushMatrix();
       {
           gl.Translate(0, 0.2f, 0);
           //gl.Scale(1, 1.2f, 1.2f);
           gl.Translate(0f, 2f, 0f);
           gl.Color(1, 0, 1);
           DrawUnitSphere(ref gl, 128, new vec3(0,0,0), 0.8, 128, 128);
       }
       
       gl.PopMatrix();
        }

        public void DrawFingerBase(ref OpenGL gl)
        {
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl.PushMatrix();
            {
                gl.Translate(-0.25f, 0, -0.25f);
                gl.Scale(0.5f, 3f, 0.5f);
                gl.Color(1.0f ,1f, 1);
                DrawUnitCylinder(ref gl);
            }
            gl.PopMatrix();

            gl.PushMatrix();
            {
                gl.Translate(0, 0.3f, 0);
                //gl.Scale(0.08f, 0.08f, 0.08f);
                gl.Translate(0f, 3f, 0f);
                gl.Color(0.5, 0.5f, 0.5f);
                DrawUnitSphere(ref gl, 128, new vec3(0,0,0), 0.5, 128, 128);
            }
            gl.PopMatrix();
        }

        public void DrawFingerTip(ref OpenGL gl)
        {
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl.PushMatrix();
            {
                gl.Scale(0.25f, 2f, 0.25f);
                gl.Translate(-0.5f, 0, -0.5f);
                gl.Color(0,1f,0.5f);
                DrawUnitCone(ref gl);
            }
            gl.PopMatrix();
        }

        public void DrawRobotArm(ref OpenGL gl)
        {
          // gl.MatrixMode(OpenGL.GL_MODELVIEW);
          // gl.Translate(baseTrans.x, 0, baseTrans.z);
          // gl.Rotate(baseSpin, 0f, 360f, 0f);
          // DrawBase(ref gl);
          //
          // gl.Translate(0f, 4.0f, 0f);
          // gl.Rotate(15f, 0f, 0f, 90f);
          // DrawArmSegment(ref gl);
          //
          // gl.Translate(0, 5.5f, 0);
          // gl.Rotate(120f, 0f, 0f, 90f);
          // DrawArmSegment(ref gl);
          //
          // gl.Translate(0, 5.5f, 0);
          // gl.Rotate(-90.0f, 0f, 0f, 90f);
          // DrawWrist(ref gl);
          //
          // gl.Rotate(10, 0.0f, 180f, 0f);
          //
          // gl.PushMatrix();
          // {
          //     gl.Translate(0f, 2f, 0f);
          //     gl.Rotate(45, 0f, 0f, -180f);
          //     DrawFingerBase(ref gl);
          //     gl.Translate(0f, 3.25f, 0f);
          //     gl.Rotate(-90, 0f, 0f, -90f);
          //     DrawFingerTip(ref gl);
          // }
          // gl.PopMatrix();
          //
          // gl.PushMatrix();
          // {
          //     gl.Translate(0f, 2f, 0f);
          //     gl.Rotate(45, 0f, 0f, 90f);
          //     DrawFingerBase(ref gl);
          //     gl.Translate(0f, 3.25f, 0);
          //     gl.Rotate(-90, 0f, 0f, 90f);
          //     DrawFingerTip(ref gl);
          // }
          // gl.PopMatrix();
        }


    }
}
