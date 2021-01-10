using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpGLWinformsApplication1
{
    class InverseKinematic
    {
       // Delta robot geometry
       const double he = 49.959;        // distance from the joint to the center of the end-effector platform
       const double hf = 120.0;         // distance from the joint to the center of the fixed platform
       const double re = 500.0;         // the lower leg length
       const double rf = 180.0;         // the upper leg length
       const double pi = Math.PI;    // PI
       const double deg2rad = pi / 180.0;

        public int delta_calcForward(double theta1, double theta2, double theta3, ref double[] positionAbs)
        {
            //double t = (s_f - s_e)*tan30 / 2;
            double t = (hf - he);
            double deg2rad = pi / 180.0;

            theta1 *= deg2rad;      // convert theta1 from degree to radian
            theta2 *= deg2rad;
            theta3 *= deg2rad;

            double y1 = -(t + rf * Math.Cos(theta1));
            double z1 = -rf * Math.Sin(theta1);

            double y2 = (t + rf * Math.Cos(theta2)) * Math.Sin(30*Math.PI/180);
            double x2 = y2 * Math.Tan(60*Math.PI/180);
            double z2 = -rf * Math.Sin(theta2);

            double y3 = (t + rf * Math.Cos(theta3)) * Math.Sin(30 * Math.PI / 180);
            double x3 = -y3 * Math.Tan(60 * Math.PI / 180);
            double z3 = -rf * Math.Sin(theta3);

            double dnm = (y2 - y1) * x3 - (y3 - y1) * x2;

            double w1 = y1 * y1 + z1 * z1;
            double w2 = x2 * x2 + y2 * y2 + z2 * z2;
            double w3 = x3 * x3 + y3 * y3 + z3 * z3;

            // x = (a1*z + b1)/dnm
            double a1 = (z2 - z1) * (y3 - y1) - (z3 - z1) * (y2 - y1);
            double b1 = -((w2 - w1) * (y3 - y1) - (w3 - w1) * (y2 - y1)) / 2.0;

            // y = (a2*z + b2)/dnm;
            double a2 = -(z2 - z1) * x3 + (z3 - z1) * x2;
            double b2 = ((w2 - w1) * x3 - (w3 - w1) * x2) / 2.0;

            // a*z^2 + b*z + c = 0
            double a = a1 * a1 + a2 * a2 + dnm * dnm;
            double b = 2 * (a1 * b1 + a2 * (b2 - y1 * dnm) - z1 * dnm * dnm);
            double c = (b2 - y1 * dnm) * (b2 - y1 * dnm) + b1 * b1 + dnm * dnm * (z1 * z1 - re * re);

            // discriminant
            double d = b * b - (double)4.0 * a * c;
            if (d < 0) return -1; // non-existing point

            positionAbs[2] = -(double)0.5 * (b + Math.Sqrt(d)) / a;
            positionAbs[0] = (a1 * positionAbs[2] + b1) / dnm;
            positionAbs[1] = (a2 * positionAbs[2] + b2) / dnm;
            return 0;
        }

         int delta_calcAngleYZ(double x0, double y0, double z0, double rot, ref double theta, ref double ry_sectheta, ref double rz_sectheta, ref vec3 top_s, ref vec3 bot_s)
        {
            // shift center to edge on the fixed platform
            double x1 = 0.0f;
            double y1 = -hf;

            // change to rad
            rot *= deg2rad;

            // rotate the coordinate of the moving platform
            double x1_rot, y1_rot;
            x1_rot = y1_rot = 0.0f;


            x1_rot = x1 * Math.Cos(rot) - y1 * Math.Sin(rot);
            y1_rot = x1 * Math.Sin(rot) + y1 * Math.Cos(rot);

            // rotate the coordinate of the moving platform
            double x0_rot, y0_rot, z0_rot;
            x0_rot = y0_rot = z0_rot = 0.0f;

            // shift center to edge on the moving platform
            double x0_joint, y0_joint, x0_init, y0_init;
            x0_init = 0;
            y0_init = - he;

            x0_joint = x0_init * Math.Cos(rot) + y0_init * Math.Sin(rot) + x0;
            y0_joint = -x0_init * Math.Sin(rot) + y0_init * Math.Cos(rot) + y0;



            //y0_joint = y0_joint - he;

            x0_rot = x0 * Math.Cos(rot) - y0 * Math.Sin(rot);
            y0_rot = x0 * Math.Sin(rot) + y0 * Math.Cos(rot);
            z0_rot = z0;

            y0_rot -= he;
            // z = a + b*y
            double a = (x0_rot * x0_rot + y0_rot * y0_rot + z0_rot * z0_rot + rf * rf - re * re - y1 * y1) / (2 * z0_rot);
            double b = (y1 - y0_rot) / z0_rot;
            

            // discriminant
            double d = -(a + b * y1) * (a + b * y1) + rf * (b * b * rf + rf);
                        
            if (d < 0) return -1; // non-existing point
            double yj = (y1 - a * b - Math.Sqrt(d)) / (b * b + 1); // choosing outer point
            
            double zj = a + b * yj;

            theta = 180.0 * Math.Atan(-zj / (y1 - yj)) / pi + ((yj > y1) ? 180.0 : 0.0);

            //top_s.x = (float)x1_rot;
            top_s.x = (float)(x1 * Math.Cos(rot) - yj * Math.Sin(rot));
            //y1 = y1 - rf * Math.Cos(theta * deg2rad);
            top_s.y = (float)(x1 * Math.Sin(rot) + yj * Math.Cos(rot));
            //top_s.y = (float)(y1_rot + rf * Math.Cos(theta*deg2rad));
            top_s.z = (float)zj;

            
            
            // Calculate the secondary angle between the active swing-arm and the passive swing-arm
            double delta_z = Math.Abs(z0-zj);
            double temp_theta = 180 * Math.Asin(delta_z / re) / pi;
            ry_sectheta = 180 - (temp_theta + theta);

            //
            rz_sectheta = 180 * Math.Sin(x0_rot/ re) / pi;

            bot_s.x = (float)x0_joint;
            bot_s.y = (float)y0_joint;
            bot_s.z = (float)z0_rot;
            return 0;
        }

        // inverse kinematics: (x0, y0, z0) -> (theta1, theta2, theta3)
        // returned status: 0=OK, -1=non-existing position
        public int delta_calcInverse(double x0, double y0, double z0, ref double[] Theta, ref double[] Rx_SecTheta, ref double[] Ry_SecTheta)
        {
            vec3[] top = new vec3[3];
            vec3[] bottom = new vec3[3];
            int status = delta_calcAngleYZ(x0, y0, z0, 0, ref Theta[0], ref Rx_SecTheta[0], ref Ry_SecTheta[0], ref top[0], ref bottom[0]);
            
            if (status == 0)
            {
                status = delta_calcAngleYZ(x0, y0, z0, -120, ref Theta[1], ref Rx_SecTheta[1], ref Ry_SecTheta[1], ref top[1], ref bottom[1]);  // rotate coords to +120 deg

            }

            if (status == 0)
            {
                
                status = delta_calcAngleYZ(x0, y0, z0, 120, ref Theta[2], ref Rx_SecTheta[2], ref Ry_SecTheta[2], ref top[2], ref bottom[2]);  // rotate coords to -120 deg

            }
            return status;
        }

        public vec3[] kinv_TopPos(double x0, double y0, double z0)
        {
            vec3[] Top = new vec3[3];
            vec3[] Bot = new vec3[3];
            double[] theta = new double[3];
            double[] rx_sectheta = new double[3];
            double[] ry_sectheta = new double[3];

            int Status = delta_calcAngleYZ(x0, y0, z0, 0, ref theta[0], ref rx_sectheta[0], ref ry_sectheta[0], ref Top[0], ref Bot[0]);

            if (Status == 0)
            {
                Status = delta_calcAngleYZ(x0, y0, z0, -120, ref theta[1], ref rx_sectheta[1], ref ry_sectheta[1], ref Top[1], ref Bot[1]);  // rotate coords to +120 deg

            }

            if (Status == 0)
            {
                Status = delta_calcAngleYZ(x0, y0, z0, 120, ref theta[2], ref rx_sectheta[2], ref ry_sectheta[2], ref Top[2], ref Bot[2]);  // rotate coords to -120 deg

            }

            return Top;
        }

  public vec3[] kinv_BotPos(double x0, double y0, double z0)
  {
      vec3[] Top = new vec3[3];
      vec3[] Bot = new vec3[3];
      double[] theta = new double[3];
      double[] rx_sectheta = new double[3];
      double[] ry_sectheta = new double[3];

      int Status = delta_calcAngleYZ(x0, y0, z0, 0, ref theta[0], ref rx_sectheta[0], ref ry_sectheta[0], ref Top[0], ref Bot[0]);

      if (Status == 0)
      {
          Status = delta_calcAngleYZ(x0, y0, z0, -120, ref theta[1], ref rx_sectheta[1], ref ry_sectheta[1], ref Top[1], ref Bot[1]);  // rotate coords to +120 deg

      }

      if (Status == 0)
      {
          Status = delta_calcAngleYZ(x0, y0, z0, 120, ref theta[2], ref rx_sectheta[2], ref ry_sectheta[2], ref Top[2], ref Bot[2]);  // rotate coords to -120 deg

      }

      return Bot;
  }

    }
}
