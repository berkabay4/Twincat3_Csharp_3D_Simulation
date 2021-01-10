using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Globalization;

namespace SharpGLWinformsApplication1
{
    [TypeConverter(typeof(StructTypeConverter<vec2>))]
    [StructLayout(LayoutKind.Explicit)]
    public struct vec2 : IEquatable<vec2>, ILoadFromString
    {
        /// <summary>
        /// x = r = s
        /// </summary>
        [FieldOffset(sizeof(float) * 0)]
        public float x;

        /// <summary>
        /// y = g = t
        /// </summary>
        [FieldOffset(sizeof(float) * 1)]
        public float y;

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        public vec2(float s)
        {
            x = y = s;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public vec2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="v"></param>
        public vec2(vec2 v)
        {
            this.x = v.x;
            this.y = v.y;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="v"></param>
        public vec2(vec3 v)
        {
            this.x = v.x;
            this.y = v.y;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="v"></param>
        public vec2(vec4 v)
        {
            this.x = v.x;
            this.y = v.y;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public float this[int index]
        {
            get
            {
                if (index == 0) return x;
                else if (index == 1) return y;
                else throw new Exception("Out of range.");
            }
            set
            {
                if (index == 0) x = value;
                else if (index == 1) y = value;
                else throw new Exception("Out of range.");
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <returns></returns>
        public static vec2 operator -(vec2 lhs)
        {
            return new vec2(-lhs.x, -lhs.y);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static vec2 operator -(vec2 lhs, vec2 rhs)
        {
            return new vec2(lhs.x - rhs.x, lhs.y - rhs.y);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static vec2 operator -(vec2 lhs, float rhs)
        {
            return new vec2(lhs.x - rhs, lhs.y - rhs);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator !=(vec2 lhs, vec2 rhs)
        {
            return (lhs.x != rhs.x || lhs.y != rhs.y);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="self"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static vec2 operator *(vec2 self, float s)
        {
            return new vec2(self.x * s, self.y * s);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static vec2 operator *(float lhs, vec2 rhs)
        {
            return new vec2(rhs.x * lhs, rhs.y * lhs);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static vec2 operator *(vec2 lhs, vec2 rhs)
        {
            return new vec2(rhs.x * lhs.x, rhs.y * lhs.y);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static vec2 operator /(vec2 lhs, float rhs)
        {
            return new vec2(lhs.x / rhs, lhs.y / rhs);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static vec2 operator +(vec2 lhs, vec2 rhs)
        {
            return new vec2(lhs.x + rhs.x, lhs.y + rhs.y);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static vec2 operator +(vec2 lhs, float rhs)
        {
            return new vec2(lhs.x + rhs, lhs.y + rhs);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator ==(vec2 lhs, vec2 rhs)
        {
            return (lhs.x == rhs.x && lhs.y == rhs.y);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public float dot(vec2 rhs)
        {
            var result = this.x * rhs.x + this.y * rhs.y;
            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (obj is vec2) && (this.Equals((vec2)obj));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(vec2 other)
        {
            return (this.x == other.x && this.y == other.y);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return string.Format("{0}#{1}", x, y).GetHashCode();
        }

        void ILoadFromString.Load(string value)
        {
            string[] parts = value.Split(VectorHelper.separator, StringSplitOptions.RemoveEmptyEntries);
            this.x = float.Parse(parts[0]);
            this.y = float.Parse(parts[1]);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public float length()
        {
            double result = Math.Sqrt(this.x * this.x + this.y * this.y);

            return (float)result;
        }

        /// <summary>
        /// 寥珨趙砃講
        /// </summary>
        /// <returns></returns>
        public vec2 normalize()
        {
            var frt = (float)Math.Sqrt(this.x * this.x + this.y * this.y);

            return new vec2(x / frt, y / frt);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public float[] ToArray()
        {
            return new[] { x, y };
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            //return string.Format("{0:0.00},{1:0.00}", x, y);
            return string.Format("{0}, {1}", x.ToString(), y.ToString());
        }

        internal static vec2 Parse(string value)
        {
            string[] parts = value.Split(VectorHelper.separator, StringSplitOptions.RemoveEmptyEntries);
            float x = float.Parse(parts[0]);
            float y = float.Parse(parts[1]);
            return new vec2(x, y);
        }
    }

    [TypeConverter(typeof(StructTypeConverter<vec3>))]
    [StructLayout(LayoutKind.Explicit)]
    public struct vec3 : IEquatable<vec3>, ILoadFromString
    {
        /// <summary>
        /// x = r = s
        /// </summary>
        [FieldOffset(sizeof(float) * 0)]
        public float x;

        /// <summary>
        /// y = g = t
        /// </summary>
        [FieldOffset(sizeof(float) * 1)]
        public float y;

        /// <summary>
        /// z = b = p
        /// </summary>
        [FieldOffset(sizeof(float) * 2)]
        public float z;

        private static readonly char[] separator = new char[] { ' ', ',' };

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        public vec3(float s)
        {
            x = y = z = s;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public vec3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="v"></param>
        public vec3(vec3 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="v"></param>
        public vec3(vec4 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="xy"></param>
        /// <param name="z"></param>
        public vec3(vec2 xy, float z)
        {
            this.x = xy.x;
            this.y = xy.y;
            this.z = z;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public float this[int index]
        {
            get
            {
                if (index == 0) return x;
                else if (index == 1) return y;
                else if (index == 2) return z;
                else throw new Exception("Out of range.");
            }
            set
            {
                if (index == 0) x = value;
                else if (index == 1) y = value;
                else if (index == 2) z = value;
                else throw new Exception("Out of range.");
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <returns></returns>
        public static vec3 operator -(vec3 lhs)
        {
            return new vec3(-lhs.x, -lhs.y, -lhs.z);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static vec3 operator -(vec3 lhs, vec3 rhs)
        {
            return new vec3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator !=(vec3 lhs, vec3 rhs)
        {
            return (lhs.x != rhs.x || lhs.y != rhs.y || lhs.z != rhs.z);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="self"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static vec3 operator *(vec3 self, float s)
        {
            return new vec3(self.x * s, self.y * s, self.z * s);
        }

        //public static vec3 operator +(vec3 lhs, float rhs)
        //{
        //    return new vec3(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs);
        //}
        //public static vec3 operator -(vec3 lhs, float rhs)
        //{
        //    return new vec3(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs);
        //}
        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static vec3 operator *(float lhs, vec3 rhs)
        {
            return new vec3(rhs.x * lhs, rhs.y * lhs, rhs.z * lhs);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static vec3 operator *(vec3 lhs, vec3 rhs)
        {
            return new vec3(rhs.x * lhs.x, rhs.y * lhs.y, rhs.z * lhs.z);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static vec3 operator /(vec3 lhs, float rhs)
        {
            return new vec3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static vec3 operator +(vec3 lhs, vec3 rhs)
        {
            return new vec3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator ==(vec3 lhs, vec3 rhs)
        {
            return (lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public vec3 cross(vec3 rhs)
        {
            return new vec3(
                this.y * rhs.z - rhs.y * this.z,
                this.z * rhs.x - rhs.z * this.x,
                this.x * rhs.y - rhs.x * this.y);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public float dot(vec3 rhs)
        {
            var result = this.x * rhs.x + this.y * rhs.y + this.z * rhs.z;
            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (obj is vec3) && (this.Equals((vec3)obj));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(vec3 other)
        {
            return (this.x == other.x && this.y == other.y && this.z == other.z);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return string.Format("{0}#{1}#{2}", x, y, z).GetHashCode();
        }

        void ILoadFromString.Load(string value)
        {
            string[] parts = value.Split(VectorHelper.separator, StringSplitOptions.RemoveEmptyEntries);
            this.x = float.Parse(parts[0]);
            this.y = float.Parse(parts[1]);
            this.z = float.Parse(parts[2]);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public float length()
        {
            double result = Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);

            return (float)result;
        }

        /// <summary>
        /// 寥珨趙砃講
        /// </summary>
        /// <returns></returns>
        public vec3 normalize()
        {
            float frt = (float)Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);
            if (frt == 0.0f)
            {
                //Debug.WriteLine("Zero vec3 being normalized!");

                return new vec3(0, 0, 0);
            }
            else
            {
                return new vec3(x / frt, y / frt, z / frt);
            }
        }

        /// <summary>
        /// max value of x, y, z.
        /// </summary>
        /// <returns></returns>
        public float max()
        {
            float value = x < y ? y : x;
            if (value < z) { value = z; }

            return value;
        }

        /// <summary>
        /// min value of x, y, z.
        /// </summary>
        /// <returns></returns>
        public float min()
        {
            float value = x < y ? x : y;
            if (z < value) { value = z; }

            return value;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public float[] ToArray()
        {
            return new[] { x, y, z };
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            //return string.Format("{0:0.00},{1:0.00},{2:0.00}", x, y, z);
            return string.Format("{0}, {1}, {2}", x.ToString(), y.ToString(), z.ToString());
        }

        internal static vec3 Parse(string value)
        {
            string[] parts = value.Split(VectorHelper.separator, StringSplitOptions.RemoveEmptyEntries);
            float x = float.Parse(parts[0]);
            float y = float.Parse(parts[1]);
            float z = float.Parse(parts[2]);
            return new vec3(x, y, z);
        }
    }

    [TypeConverter(typeof(StructTypeConverter<vec4>))]
    [StructLayout(LayoutKind.Explicit)]
    public struct vec4 : IEquatable<vec4>, ILoadFromString
    {
        /// <summary>
        /// x = r = s
        /// </summary>
        [FieldOffset(sizeof(float) * 0)]
        public float x;

        /// <summary>
        /// y = g = t
        /// </summary>
        [FieldOffset(sizeof(float) * 1)]
        public float y;

        /// <summary>
        /// z = b = p
        /// </summary>
        [FieldOffset(sizeof(float) * 2)]
        public float z;

        /// <summary>
        /// w = a = q
        /// </summary>
        [FieldOffset(sizeof(float) * 3)]
        public float w;

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        public vec4(float s)
        {
            x = y = z = w = s;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="w"></param>
        public vec4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="v"></param>
        public vec4(vec4 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.w = v.w;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="xyz"></param>
        /// <param name="w"></param>
        public vec4(vec3 xyz, float w)
        {
            this.x = xyz.x;
            this.y = xyz.y;
            this.z = xyz.z;
            this.w = w;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public float this[int index]
        {
            get
            {
                if (index == 0) return x;
                else if (index == 1) return y;
                else if (index == 2) return z;
                else if (index == 3) return w;
                else throw new Exception("Out of range.");
            }
            set
            {
                if (index == 0) x = value;
                else if (index == 1) y = value;
                else if (index == 2) z = value;
                else if (index == 3) w = value;
                else throw new Exception("Out of range.");
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <returns></returns>
        public static vec4 operator -(vec4 lhs)
        {
            return new vec4(-lhs.x, -lhs.y, -lhs.z, -lhs.w);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static vec4 operator -(vec4 lhs, vec4 rhs)
        {
            return new vec4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator !=(vec4 lhs, vec4 rhs)
        {
            return (lhs.x != rhs.x || lhs.y != rhs.y || lhs.z != rhs.z || lhs.w != rhs.w);
        }

        //public static vec4 operator -(vec4 lhs, float rhs)
        //{
        //    return new vec4(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs, lhs.w - rhs);
        //}
        /// <summary>
        ///
        /// </summary>
        /// <param name="self"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static vec4 operator *(vec4 self, float s)
        {
            return new vec4(self.x * s, self.y * s, self.z * s, self.w * s);
        }

        //public static vec4 operator +(vec4 lhs, float rhs)
        //{
        //    return new vec4(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs, lhs.w + rhs);
        //}
        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static vec4 operator *(float lhs, vec4 rhs)
        {
            return new vec4(rhs.x * lhs, rhs.y * lhs, rhs.z * lhs, rhs.w * lhs);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static vec4 operator *(vec4 lhs, vec4 rhs)
        {
            return new vec4(rhs.x * lhs.x, rhs.y * lhs.y, rhs.z * lhs.z, rhs.w * lhs.w);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static vec4 operator /(vec4 lhs, float rhs)
        {
            return new vec4(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs, lhs.w / rhs);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static vec4 operator +(vec4 lhs, vec4 rhs)
        {
            return new vec4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator ==(vec4 lhs, vec4 rhs)
        {
            return (lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z && lhs.w == rhs.w);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public float dot(vec4 rhs)
        {
            var result = this.x * rhs.x + this.y * rhs.y + this.z * rhs.z + this.w * rhs.w;
            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (obj is vec4) && (this.Equals((vec4)obj));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(vec4 other)
        {
            return (this.x == other.x && this.y == other.y && this.z == other.z && this.w == other.w);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return string.Format("{0}#{1}#{2}#{3}", x, y, z, w).GetHashCode();
        }

        void ILoadFromString.Load(string value)
        {
            string[] parts = value.Split(VectorHelper.separator, StringSplitOptions.RemoveEmptyEntries);
            this.x = float.Parse(parts[0]);
            this.y = float.Parse(parts[1]);
            this.z = float.Parse(parts[2]);
            this.w = float.Parse(parts[3]);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public float length()
        {
            double result = Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w);

            return (float)result;
        }

        /// <summary>
        /// 寥珨趙砃講
        /// </summary>
        /// <returns></returns>
        public vec4 normalize()
        {
            var frt = (float)Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w);

            return new vec4(x / frt, y / frt, z / frt, w / frt);
            ;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public float[] ToArray()
        {
            return new[] { x, y, z, w };
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            //return string.Format("{0:0.00},{1:0.00},{2:0.00},{3:0.00}", x, y, z, w);
            return string.Format("{0}, {1}, {2}, {3}", x.ToString(), y.ToString(), z.ToString(), w.ToString());
            //return base.ToString();
        }

        internal static vec4 Parse(string value)
        {
            string[] parts = value.Split(VectorHelper.separator, StringSplitOptions.RemoveEmptyEntries);
            float x = float.Parse(parts[0]);
            float y = float.Parse(parts[1]);
            float z = float.Parse(parts[2]);
            float w = float.Parse(parts[3]);
            return new vec4(x, y, z, w);
        }
    }

    public static class VectorHelper
    {
        /// <summary>
        /// separator
        /// </summary>
        internal static readonly char[] separator = new char[] { ' ', ',' };

        /// <summary>
        ///
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static vec3 Abs(this vec3 item)
        {
            vec3 result = new vec3(item.x, item.y, item.z);
            if (result.x < 0) { result.x = -result.x; }
            if (result.y < 0) { result.y = -result.y; }
            if (result.z < 0) { result.z = -result.z; }

            return result;
        }

        /// <summary>
        /// update maximum values.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="currentMax"></param>
        public static void UpdateMax(this vec3 item, ref vec3 currentMax)
        {
            if (currentMax.x < item.x) { currentMax.x = item.x; }
            if (currentMax.y < item.y) { currentMax.y = item.y; }
            if (currentMax.z < item.z) { currentMax.z = item.z; }
        }

        /// <summary>
        /// update minimum values.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="currentMin"></param>
        public static void UpdateMin(this vec3 item, ref vec3 currentMin)
        {
            if (item.x < currentMin.x) { currentMin.x = item.x; }
            if (item.y < currentMin.y) { currentMin.y = item.y; }
            if (item.z < currentMin.z) { currentMin.z = item.z; }
        }
    }

    internal class StructTypeConverter<T> : TypeConverter where T : struct, ILoadFromString
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(T);
        }

        public override object ConvertFrom(ITypeDescriptorContext context,
            CultureInfo culture, object value)
        {
            var result = default(T);
            result.Load(value as string);

            return result;
        }

        public override object ConvertTo(ITypeDescriptorContext context,
            CultureInfo culture, object value, Type destinationType)
        {
            object result;
            if (destinationType == typeof(string))
            {
                result = value.ToString();
            }
            else
            {
                result = base.ConvertTo(context, culture, value, destinationType);
            }
            return result;
        }
    }

    public interface ILoadFromString
    {
        /// <summary>
        /// Load values for this instance from a string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        void Load(string value);
    }
}
