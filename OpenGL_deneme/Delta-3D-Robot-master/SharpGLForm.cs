using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpGL;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;
using TwinCAT.Ads;
using System.Collections;

namespace SharpGLWinformsApplication1
{
    public partial class SharpGLForm : Form
    {
        public vec3 vRotAngle, vDrawOriginal;
        public static float fWorkMaxAngle = 81.92f;
        public static float fWorkMinAngle = -37.18f;

        public static float fWorkRadio = 250f;
        public static float fWorkMaxZ = -371f;
        public static float fWorkMinZ = -521f;

        //public static float fWork
        public float fFovy = 75f;
        public vec3 MovePlatePos = new vec3(0, 0, -340.51800f);
        ListViewItem.ListViewSubItem SelectedLSI;               //Object when select List view Gcode
        double[] ThetaMotor = new double[3];
  
        double[] PositionAbs = new double[3];
        double[] ThetaPassiveRx = new double[3];
        double[] ThetaPassiveRy = new double[3];

        float UnitFactor=1;
        InverseKinematic IK1 = new InverseKinematic();
        float StepSize=1;

        private TcAdsClient tcClient;
        private string[] plcVarNames;
        private int[] plcVarHandles;

        public int hVar;









        public SharpGLForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            vDrawOriginal = new vec3(-15, 5, -15);
            //initial list view Gcode

            timer1.Start();

           try
            {


                tcClient = new TcAdsClient();
                tcClient.Connect(851);

                plcVarNames = new string[]
                {
                "GVL_Axis.AxisM1PosValue",              //      [0]
                "GVL_Axis.AxisM2PosValue",              //      [1]
                "GVL_Axis.AxisM3PosValue",              //      [2]
                "GVL_Axis.AxisXVal",                   //      [3]
                "GVL_Axis.AxisYVal",                   //      [4]
                "GVL_Axis.AxisZVal",                   //      [5]
                "GVL_Process_Deneme.bSensor",           //[6]

                };


                hVar = tcClient.CreateVariableHandle("GVL_Process_Deneme.bCatch");

                plcVarHandles = new int[plcVarNames.Length];


                for (int i = 0; i < plcVarNames.Length; i++)
                {
                    plcVarHandles[i] = tcClient.CreateVariableHandle(plcVarNames[i]);
                }

            }
            catch (Exception err)
            {
                tcClient = null;
                MessageBox.Show(err.Message);
            }

        }
        private void SharpGLForm_Load(object sender, EventArgs e)
        {
            tbXCoor.Text = CoorX.ToString(); //Math.Round(MovePlatePos.x,4).ToString();
            tbYCoor.Text = CoorY.ToString(); //Math.Round(MovePlatePos.y,4).ToString();
            tbZCoor.Text = CoorZ.ToString(); //Math.Round(MovePlatePos.z,4).ToString();
            UpdateCoorRv();
   
        }
        public void openGLControl_OpenGLDraw(object sender, PaintEventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            gl.LoadIdentity();
            gl.Color(1, 1, 1);
            gl.Perspective(fFovy, (double)Width / (double)Height, 0.01, 400.0);
            gl.LookAt(vDrawOriginal.x, vDrawOriginal.y, vDrawOriginal.z, 0, 0, 0, 0, 1, 0);

            gl.Rotate(vRotAngle.x, 1.0f, 0.0f, 0.0f);
            gl.Rotate(vRotAngle.y, 0.0f, 1.0f, 0.0f);
            gl.Rotate(vRotAngle.z, 0.0f, 0.0f, 1.0f);
            
        //   drawGrid(gl);


            Delta_3_Robot D3R = new Delta_3_Robot(new vec3(MovePlatePos.x, MovePlatePos.y, MovePlatePos.z));
            D3R.DrawDelta3Robot(ref gl);
         
            Conv Conveyor = new Conv();

            Conveyor.DrawPlane(ref gl);
            Conveyor.DrawObj(ref gl,objx,objy,objz);
            Conveyor.DrawBox(ref gl);

            double[] ThetaMotor = new double[3];
            ThetaMotor[0] = PosM1;
            ThetaMotor[1] = PosM2;
            ThetaMotor[2] = PosM3;

            double[] ThetaPassiveRx = new double[3];
            double[] ThetaPassiveRy = new double[3];

            InverseKinematic IK = new InverseKinematic();

            IK.delta_calcInverse(MovePlatePos.x, MovePlatePos.y, MovePlatePos.z, ref ThetaMotor, ref ThetaPassiveRx, ref ThetaPassiveRy);

            /* label6.Text = "Leg1 Theta 1: " + ThetaMotor[0];
            label5.Text = "Leg2 Theta 1: " + ThetaMotor[1];
            label4.Text = "Leg3 Theta 1: " + ThetaMotor[2];

            label9.Text = "Leg1 Theta 2 Rx: " + ThetaPassiveRx[0];
            label8.Text = "Leg2 Theta 2 Rx: " + ThetaPassiveRx[1];
            label7.Text = "Leg3 Theta 2 Rx: " + ThetaPassiveRx[2];

            label12.Text = "Leg1 Theta 2 Ry: " + ThetaPassiveRy[0];
            label11.Text = "Leg2 Theta 2 Ry: " + ThetaPassiveRy[1];
            label10.Text = "Leg3 Theta 2 Ry: " + ThetaPassiveRy[2]; */



            tbXCoor.Text = PosX.ToString();
            tbYCoor.Text = PosY.ToString();
            tbZCoor.Text = PosZ.ToString();
            UpdateCoorRv();
            tbθ1Coor.Text = (ThetaMotor[0]).ToString();
            tbθ2Coor.Text = (ThetaMotor[1]).ToString();
            tbθ3Coor.Text = (ThetaMotor[2]).ToString();

        }





        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;
            gl.ClearColor(0, 0, 0, 0);
        }

        private void openGLControl_Resized(object sender, EventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();          
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }
    
        //测试例子
        public void rtest(ref OpenGL gl)
        {
            //RobotComponent rc = new RobotComponent();

            //rc.DrawGroundPlane(ref gl);
            //rc.DrawRobotArm(ref gl);
        }
        
        private void openGLControl_KeyDown(object sender, KeyEventArgs e)
        {
            int t = e.KeyValue;
            switch (e.KeyCode)
            {   
                case Keys.NumPad6:
                    vDrawOriginal.x += 5f;
                    break;
                case Keys.NumPad4:
                    vDrawOriginal.x -= 5f;
                    break;
                case Keys.NumPad2:
                    vDrawOriginal.y -= 5f;
                    break;
                case Keys.NumPad8:
                    vDrawOriginal.y += 5f;
                    break;
                case Keys.Q:
                    vRotAngle.x += 5;
                    break;
                case Keys.A:
                    vRotAngle.x -= 5;
                    break;
                case Keys.W:
                    vRotAngle.y += 5;
                    break;
                case Keys.S:
                    vRotAngle.y -= 5;
                    break;
                case Keys.E:
                    vRotAngle.z += 5;
                    break;
                case Keys.D:
                    vRotAngle.z -= 5;
                    break;
                case Keys.Space:
                    vRotAngle = new vec3(0, 0, 0);
                    break;
                default:
                    break;
            }
        }

        private void openGLControl_MouseWheel(object sender, MouseEventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;
            int tWheelCount = e.Delta / 120;
            if (tWheelCount > 0)
            {
                // Close
                fFovy -= 5f;
            }
            else if (tWheelCount < 0)
            {
                // Far
                fFovy += 5f;
            }
            
        }

   void drawGrid(OpenGL gl)
   {
       //绘制过程
       gl.PushAttrib(OpenGL.GL_CURRENT_BIT);  //保存当前属性
       gl.PushMatrix();                        //压入堆栈
       gl.Translate(0f, 0f, 0f);
       gl.Color(1.0f, 0f, 0f);
 
       //在X,Z平面上绘制网格
       for (float i = -50; i <= 50; i += 1)
       {
           //绘制线
           gl.Begin(OpenGL.GL_LINES);
           {
               if (i == 0)
                   gl.Color(0f, 0f, 0f);
               else
                   gl.Color(0f, 0f, 1f);
 
               //X轴方向
               gl.Vertex(-50f, 0f, i);
               gl.Vertex(50f, 0f, i);
               //Z轴方向 
               gl.Vertex(i, 0f, -50f);
               gl.Vertex(i, 0f, 50f);
 
           }
           gl.End();
       }
       gl.PopMatrix();
       gl.PopAttrib();
 }


        //start h

        private void btLoadGcodeFile_Click(object sender, EventArgs e)
        {
            ReadInTimeSheet();
        }

        private void ReadInTimeSheet()
        {
            var fileLines = File.ReadAllLines(@"IntersectionPoints1.ngc");
            string[] StringArray = new string[3];
            string line;
       

         
        }




        private void tbθ2Coor_TextChanged(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(tbθ2Coor.Text, out parsedValue))
            {
                tbθ2Coor.Text = "0";
            }
        }


        private void btIntBoard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Initial parameters for Motion Board successful.","Info"); //it will load C program to initial parameters for KFlop board
        }

      

      

        private void tbXCoor_TextChanged(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(tbXCoor.Text, out parsedValue))
            {
                tbXCoor.Text = "0";
            }
        }


        private void tbθ1Coor_TextChanged(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(tbθ1Coor.Text, out parsedValue))
            {
                tbθ1Coor.Text = "0";
            }
        }

        private void tbθ3Coor_TextChanged(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(tbθ3Coor.Text, out parsedValue))
            {
                tbθ3Coor.Text = "0";
            }
        }



      

        private void tbYCoor_TextChanged(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(tbYCoor.Text, out parsedValue))
            {
                tbYCoor.Text = "0";
            }
        }

        private void tbZCoor_TextChanged(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(tbZCoor.Text, out parsedValue))
            {
                tbZCoor.Text = "0";
            }
        }

        public void UpdateCoorRv()
        {
            int Status;

            Status = IK1.delta_calcForward(ThetaMotor[0], ThetaMotor[1], ThetaMotor[2], ref PositionAbs);

            if (Status == 0)
            {
                tbθ1Coor.Text = Math.Round(ThetaMotor[0], 4).ToString();
                tbθ2Coor.Text = Math.Round(ThetaMotor[1], 4).ToString();
                tbθ3Coor.Text = Math.Round(ThetaMotor[2], 4).ToString();
            }
            else
            {
                tbθ1Coor.Text = "NaN";
                tbθ2Coor.Text = "NaN";
                tbθ3Coor.Text = "NaN";
                
            }
            if ((tbθ1Coor.Text == "NaN") | (tbθ2Coor.Text == "NaN") | (tbθ3Coor.Text == "NaN"))
            {
                MessageBox.Show("Eror code xxx");
            }
        }

        public void UpdateCoorFw()
        {
   int Status = 0;

   Status = IK1.delta_calcForward(PosM1, PosM2,PosM3, ref PositionAbs);
   
   if (Status == 0)
   {
                tbXCoor.Text = CoorX.ToString();                 //   (Math.Round(PositionAbs[0],4) * UnitFactor).ToString();
                tbYCoor.Text = CoorY.ToString();                 //   (Math.Round(PositionAbs[1],4) * UnitFactor).ToString();
                tbZCoor.Text = CoorZ.ToString();                //   (Math.Round(PositionAbs[2],4) * UnitFactor).ToString();
            }
   else
   {
       tbXCoor.Text = "NaN";
       tbYCoor.Text = "NaN";
       tbZCoor.Text = "NaN";
   }
   if ((tbXCoor.Text == "NaN") | (tbXCoor.Text == "NaN" )| (tbXCoor.Text == "NaN"))
   {
       MessageBox.Show("Eror code xxx");
   }
        }


        #region Auto Thread Test

        //private Thread Thread_AutoRun;
        private object locker = new object();
        private CancellationTokenSource cts;
        private int iListIndex = 0;

        private List<vec3> list = new List<vec3>();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
  
        }
        
        private void AutoMove(CancellationToken token)
        {
           
                
        }

        public void PlateMove(object states, vec3 vDestination)
        {
          //  if (JudgementWorkspace(vDestination))
           //{
                var cts = states as CancellationTokenSource;
                float fUnit = 0;
                 vec3 unitMove = (vDestination - MovePlatePos).normalize();
                fUnit = unitMove.length();

                while (!MovePlatePos.Equals(vDestination) && !cts.IsCancellationRequested)
                {
                    //StepSize = ;

                    if ((MovePlatePos - vDestination).length() - fUnit > StepSize)
                        MovePlatePos += unitMove * StepSize;
                    else
                    {
                        MovePlatePos = vDestination;
                        //   PlateMove(new vDestination);
                     //   Thread.Sleep(1000);
                    }
                   // Thread.Sleep(50);
                }
          //  }
         //  else
         //  {
         //      MessageBox.Show(string.Format("the points:\r\nX:{0},Y:{1},Z:{2}\r\nis not in the workplace!!!", vDestination.x, vDestination.y, vDestination.z));
         //      return;
         //  }
           
        }

        public void PlateMove(vec3 vDestination)
        {
            if (JudgementWorkspace(vDestination))
            {
                float fUnit = 0;
                vec3 unitMove = (vDestination - MovePlatePos).normalize();
                fUnit = unitMove.length();
                while (!MovePlatePos.Equals(vDestination))
                {
                    if ((MovePlatePos - vDestination).length() - fUnit > StepSize)
                        MovePlatePos += unitMove * StepSize;
                    else
                    {
                        MovePlatePos = vDestination;
                        Thread.Sleep(1000);
                    }
                    Thread.Sleep(50);
                }

            }
            else
            {
                MessageBox.Show(string.Format("the points:\r\nX:{0},Y:{1},Z:{2}\r\nis not in the workplace!!!", vDestination.x,vDestination.y, vDestination.z));
                return;
            }
        }




        public bool JudgementWorkspace(vec3 p)      
        {
            bool bResult = true;

            if (p.z < -526f || p.z > -376)
            {
                bResult = false;
            }

            if (p.x * p.x + p.y * p.y > fWorkRadio * fWorkRadio)
            {
                bResult = false;
            }

            if (!bResult)
                MessageBox.Show("The Next Position will OVER WORKSPACE");

            return bResult;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        //Stop
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            cts.Cancel();
            iListIndex = 0;
            list.Clear();
            PlateMove(new vec3(0, 0, -340.51800f));
        }


      
        private void lvGcodeDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
          float PosX, PosY, PosZ;
         float PosM1, PosM2, PosM3;


        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
          
          
          
          

          

          



        }
        public float Val1, Val2, Val3, Val4;


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }


        int counterb1=0;

        private void button1_Click_2(object sender, EventArgs e)
        {
            counterb1 = counterb1 + 1;

            if (counterb1%2 ==   0)
            timer3.Start();

            else
            {
                timer3.Stop();
            }
        }

        float objx = -15.0f, objy = -0.45f, objz = -11.9f;

        private void button2_Click(object sender, EventArgs e)
        {

            objx = -15.0f;
            objy = -0.45f;
            objz = -11.9f;
            DrawControl = true;
            bSensor = false;

            tcClient.WriteAny(plcVarHandles[6], false);

        }

        private void lbθ1Coor_Click(object sender, EventArgs e)
        {

        }

        bool bSensor,DrawControl,deneme;
        int sdeneme;

        public void timer3_Tick(object sender, EventArgs e)
        {



            if (bMovementDone == false)
            {



                if (objx >= -1.0f)
                {
                    bSensor = true;

                    tcClient.WriteAny(plcVarHandles[6], true);


                }

                else if (objx < -1.0f)
                {
                    objx = objx + 0.2f;


                    tcClient.WriteAny(plcVarHandles[6], false);


                }
            }



     

             if (bDataComp ==  true   )        // && bMovementDone == true)
            {

                objx = -1;
                objy = +10.5f;                      //Malzeme 2. Konuma Bırakıldı.
                objz = -11.9f;

                 DrawControl = true;


                    tcClient.WriteAny(plcVarHandles[6], false);

            }

          else  if (DrawControl==true)
           {
               objx = -15;
               objy = -0.45f;                   // Yeni malzeme için konv hazır.
               objz = -11.9f;

                tcClient.WriteAny(plcVarHandles[6], false);

                bSensor = false;
                DrawControl = false;

            }




            textBox4.Text = objx.ToString();
            textBox5.Text = objy.ToString();
            textBox6.Text = objz.ToString();





        }

        private void timer2_Tick(object sender, EventArgs e)
        {
         //   CoorX = Convert.ToInt64(textBox4.Text);
         //   CoorY = Convert.ToInt64(textBox5.Text);
         //   CoorZ = Convert.ToInt64(textBox6.Text);
         //
         //   vec3 p = new vec3(CoorX, CoorY, CoorZ);      //  vec3 p = new vec3(0, 0, -376);  
         //
         //   CancellationTokenSource TmpCts = new CancellationTokenSource();
         //   ThreadPool.QueueUserWorkItem(state => PlateMove(TmpCts, p));

        }

        private void SharpGLForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
    
    }

        

        private void gbWorkSpace_Enter(object sender, EventArgs e)
        {

        }

        public bool bMovementDone, bDataComp;
        int hbool1,hbool2;
        public void PlcReadData()
        {
      


            if (tcClient != null)
            {


                PosM1 = Convert.ToInt64(tcClient.ReadAny(plcVarHandles[0], typeof(double)));            //Teta1
                PosM2 = Convert.ToInt64(tcClient.ReadAny(plcVarHandles[1], typeof(double)));
                PosM3 = Convert.ToInt64(tcClient.ReadAny(plcVarHandles[2], typeof(double)));



                PosX = Convert.ToInt64(tcClient.ReadAny(plcVarHandles[3], typeof(double)));     
                PosY = Convert.ToInt64(tcClient.ReadAny(plcVarHandles[4], typeof(double)));
                PosZ = Convert.ToInt64(tcClient.ReadAny(plcVarHandles[5], typeof(double)));


                hbool1 = tcClient.CreateVariableHandle("GVL_Process_Deneme.bMovementDone");

                bMovementDone = Convert.ToBoolean(tcClient.ReadAny(hbool1, typeof(Boolean)).ToString());


                hbool2 = tcClient.CreateVariableHandle("GVL_Process_Deneme.bDataComp");

                bDataComp = Convert.ToBoolean(tcClient.ReadAny(hbool2, typeof(Boolean)).ToString());



            }
        }

        float CoorX, CoorY, CoorZ;


        private void timer1_Tick(object sender, EventArgs e)
        {
         
            textBox1.Text = objx.ToString();



            PlcReadData();

            if (bMovementDone == true)
                sdeneme = sdeneme + 1;
            
            textBox3.Text = sdeneme.ToString();


         CoorX  =PosX;  //Convert.ToInt64(textBox1.Text);
         CoorY  =PosY;   //Convert.ToInt64(textBox2.Text);
         CoorZ  = PosZ;  //Convert.ToInt64(textBox3.Text);

         
         
         
         
         
         
                                                              
        vec3 p = new vec3(CoorX, CoorY, CoorZ);  

        CancellationTokenSource TmpCts = new CancellationTokenSource();
        ThreadPool.QueueUserWorkItem(state => PlateMove(TmpCts, p));

    


        }



        //Pause
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            cts.Cancel();
        }

        #endregion

    }

}
