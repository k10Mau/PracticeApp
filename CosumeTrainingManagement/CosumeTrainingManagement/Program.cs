using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CosumeTrainingManagement
{
    interface isample
    {
        int a { get; set; }
    }

    class A : I1, I2
    {
        void I2.add()
        {
            throw new NotImplementedException();
        }

        void I1.add()
        {
            throw new NotImplementedException();
        }
    }
    class B:A
    {

    }
    interface I1
    {
        void add();
    }
    interface I2
    {
        void add();
    }
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            test1 t = new test1();
            B b = (B)a;
            //  objCourse.saveCourse();
            //TraningCourseServices.saveCourse().Wait();
            //TraningCourseServices.GetCourses().Wait();
            test1 obj3 = new test1(8, 8);
            test1 obj1 = new test1();
             var a = test1.a;

            test1 obj2 = new test1();
            var a2 = test1.a;
            
            // test1.show();
            // var b = test1.a;
            //  test1

            var temp = ConvertKelvinToImperial(272.63);
            
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double ConvertKelvinToMetric(double kelvin)
        {
            // Kelvin is celsius shifted 273.15 degrees
            return kelvin - 273.15;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double ConvertKelvinToImperial(double kelvin)
        {
            return ConvertKelvinToMetric(kelvin) * 1.8 + 32;
        }
    }
   

    class test1
    {
        public static int a;
        public int b;
        //private test1(int a)
        //{

        //}
       
        public test1()
        {
            a=5;
            b = 3;           
                                  
        }
        public test1(int x, int y)
        {
            a = x;
            b = y;

        }
        static test1()
        {
            a = 10;
        }
        public static void show()
        {
            a++;
        }
    }
}
