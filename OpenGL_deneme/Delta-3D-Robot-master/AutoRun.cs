using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SharpGLWinformsApplication1
{
    class AutoRun
    {
        public delegate void ThreadStart();
        public delegate void ParameterizedThreadStart(Object obj);

        vec3 MovingPosition = new vec3(0,0,-350f);
        List<vec3> list = new List<vec3>();
        int iFlag = 0;
        public AutoRun(List<vec3> PathList, vec3 MovePlatePos)
        {
            //Auto Run Parameter
            MovingPosition = MovePlatePos;
            list = PathList;

        }

        public void Start()
        {
            Thread AutoRun = new Thread(new System.Threading.ThreadStart(AutoMove))
            {
                Name = "AutoRun Thread"
            };
        }

        private void AutoMove()
        {
            foreach (vec3 p in list)
            {
                MovingPosition = p;
                Thread.Sleep(1000);
            }
        }
        
        private void Pasue()
        {

        }

        private void Stop()
        {

        }

        private void Destroy()
        {

        }
    }
}
