using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL;

namespace SharpGLWinformsApplication1
{
    class RobotHuman
    {
        public vec3 vRotAngle, vDrawOriginal, vThiAng_1, vThiAng_2, vThiAng_3;

        public float angle;                  // The Rotate Angle of Robot View
        float[] legAngle = new float[2];	 // 腿的当前旋转角度
        float[] armAngle = new float[2];     // 胳膊的当前旋转角度

        bool leg1 = true;		            // 机器人腿的状态，true向前，flase向后
        bool leg2 = false;
        bool arm1 = true;
        bool arm2 = false;

        // 绘制头部
        void DrawHead(ref OpenGL Gl, float xPos, float yPos, float zPos)
        {
            Gl.PushMatrix();
            Gl.Color(1.0f, 1.0f, 1.0f);	// 白色 
            Gl.Translate(xPos, yPos, zPos);
            Gl.Scale(2.0f, 2.0f, 2.0f);		//头部是 2x2x2长方体
            DrawCube(ref Gl, 0.0f, 0.0f, 0.0f, false);
            Gl.PopMatrix();
        }

        // 绘制机器人的躯干 
        void DrawTorso(ref OpenGL Gl, float xPos, float yPos, float zPos)
        {
            Gl.PushMatrix();
            Gl.Color(0.0f, 0.0f, 1.0f);	 // 蓝色
            Gl.Translate(xPos, yPos, zPos);
            Gl.Scale(3.0f, 5.0f, 2.0f);	     // 躯干是3x5x2的长方体 
            DrawCube(ref Gl, 0.0f, 0.0f, 0.0f, false);
            Gl.PopMatrix();
        }

        // 绘制一个手臂 
        void DrawArm(ref OpenGL Gl, float xPos, float yPos, float zPos)
        {
            Gl.PushMatrix();
            Gl.Color(1.0f, 0.0f, 0.0f);    /**< 红色 */
            Gl.Translate(xPos, yPos, zPos);
            Gl.Scale(1.0f, 4.0f, 1.0f);	    /**< 手臂是1x4x1的立方体 */
            DrawCube(ref Gl, 0.0f, 0.0f, 0.0f, false);
            Gl.PopMatrix();
        }

        // 绘制一条腿 
        void DrawLeg(ref OpenGL Gl, float xPos, float yPos, float zPos)
        {
            Gl.PushMatrix();
            Gl.Color(1.0f, 1.0f, 0.0f);	/**< 黄色 */
            Gl.Translate(xPos, yPos, zPos);
            Gl.Scale(1.0f, 5.0f, 1.0f);		/**< 腿是1x5x1长方体 */
            DrawCube(ref Gl, 0.0f, 0.0f, 0.0f, false);
            Gl.PopMatrix();
        }

        internal void DrawCube(ref OpenGL Gl, float xPos, float yPos, float zPos, bool isLine)
        {
            Gl.PushMatrix();
            Gl.Translate(xPos, yPos, zPos);
            if (isLine)
                Gl.Begin(OpenGL.GL_LINE_STRIP);
            else
                Gl.Begin(OpenGL.GL_POLYGON);

            // 顶面
            Gl.Vertex(0.0f, 0.0f, 0.0f);
            Gl.Vertex(0.0f, 0.0f, -1.0f);
            Gl.Vertex(-1.0f, 0.0f, -1.0f);
            Gl.Vertex(-1.0f, 0.0f, 0.0f);

            // 前面
            Gl.Vertex(0.0f, 0.0f, 0.0f);
            Gl.Vertex(-1.0f, 0.0f, 0.0f);
            Gl.Vertex(-1.0f, -1.0f, 0.0f);
            Gl.Vertex(0.0f, -1.0f, 0.0f);

            // 右面
            Gl.Vertex(0.0f, 0.0f, 0.0f);
            Gl.Vertex(0.0f, -1.0f, 0.0f);
            Gl.Vertex(0.0f, -1.0f, -1.0f);
            Gl.Vertex(0.0f, 0.0f, -1.0f);

            // 左面
            Gl.Vertex(-1.0f, 0.0f, 0.0f);
            Gl.Vertex(-1.0f, 0.0f, -1.0f);
            Gl.Vertex(-1.0f, -1.0f, -1.0f);
            Gl.Vertex(-1.0f, -1.0f, 0.0f);

            // 底面 
            Gl.Vertex(0.0f, 0.0f, 0.0f);
            Gl.Vertex(0.0f, -1.0f, -1.0f);
            Gl.Vertex(-1.0f, -1.0f, -1.0f);
            Gl.Vertex(-1.0f, -1.0f, 0.0f);


            // 后面
            Gl.Vertex(0.0f, 0.0f, 0.0f);
            Gl.Vertex(-1.0f, 0.0f, -1.0f);
            Gl.Vertex(-1.0f, -1.0f, -1.0f);
            Gl.Vertex(0.0f, -1.0f, -1.0f);
            Gl.End();
            Gl.PopMatrix();
        }

        public void DrawRobot(ref OpenGL Gl, float xPos, float yPos, float zPos)
        {
            Gl.PushMatrix();
            {
                Gl.Translate(xPos, yPos, zPos);

                ///绘制各个部分
                //Gl.LoadIdentity();
                DrawHead(ref Gl, 1f, 2f, 0f);     // 绘制头部  2*2*2
                DrawTorso(ref Gl, 1.5f, 0.0f, 0.0f); //躯干,  3*5*2

                Gl.PushMatrix();
                {
                    ///如果胳膊正在向前运动，则递增角度，否则递减角度 
                    if (arm1)
                        armAngle[0] = armAngle[0] + 1f;
                    else
                        armAngle[0] = armAngle[0] - 1f;

                    ///如果胳膊达到其最大角度则改变其状态
                    if (armAngle[0] >= 15.0f)
                        arm1 = false;
                    if (armAngle[0] <= -15.0f)
                        arm1 = true;

                    ///平移并旋转后绘制胳膊
                    Gl.Translate(0.0f, -0.5f, 0.0f);
                    Gl.Rotate(armAngle[0], 1.0f, 0.0f, 0.0f);
                    DrawArm(ref Gl, 2.5f, 0.0f, -0.5f);  //胳膊1, 1*4*1  
                }
                Gl.PopMatrix();

                Gl.PushMatrix();
                {
                    if (arm2)
                        armAngle[1] = armAngle[1] + 1f;
                    else
                        armAngle[1] = armAngle[1] - 1f;


                    if (armAngle[1] >= 15.0f)
                        arm2 = false;
                    if (armAngle[1] <= -15.0f)
                        arm2 = true;


                    Gl.Translate(0.0f, -0.5f, 0.0f);
                    Gl.Rotate(armAngle[1], 1.0f, 0.0f, 0.0f);
                    DrawArm(ref Gl, -1.5f, 0.0f, -0.5f); //胳膊2, 1*4*1
                }
                Gl.PopMatrix();

                Gl.PushMatrix();
                {
                    ///如果腿正在向前运动，则递增角度，否则递减角度 
                    if (leg1)
                        legAngle[0] = legAngle[0] + 1f;
                    else
                        legAngle[0] = legAngle[0] - 1f;

                    ///如果腿达到其最大角度则改变其状态
                    if (legAngle[0] >= 15.0f)
                        leg1 = false;
                    if (legAngle[0] <= -15.0f)
                        leg1 = true;

                    ///平移并旋转后绘制胳膊
                    Gl.Translate(0.0f, -0.5f, 0.0f);
                    Gl.Rotate(legAngle[0], 1.0f, 0.0f, 0.0f);
                    DrawLeg(ref Gl, -0.5f, -5.0f, -0.5f); //腿部1,1*5*1 
                }
                Gl.PopMatrix();

                Gl.PushMatrix();
                {
                    if (leg2)
                        legAngle[1] = legAngle[1] + 1f;
                    else
                        legAngle[1] = legAngle[1] - 1f;

                    if (legAngle[1] >= 15.0f)
                        leg2 = false;
                    if (legAngle[1] <= -15.0f)
                        leg2 = true;

                    Gl.Translate(0.0f, -0.5f, 0.0f);
                    Gl.Rotate(legAngle[1], 1.0f, 0.0f, 0.0f);
                    DrawLeg(ref Gl, 1.5f, -5.0f, -0.5f); //腿部2, 1*5*1
                }
                Gl.PopMatrix();
            }
            Gl.PopMatrix();
        }
    }
}
