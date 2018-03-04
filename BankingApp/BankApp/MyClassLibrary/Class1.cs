using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class Magic
    {
        private int a;
        protected int b;
        internal int c;
        protected internal int d;
        public int e;
        //protected class Class2
        //{
            
        //}
        //protected Class2 createobj()
        //{
        //    Class2 obj= new Class2();
        //    return obj;
        //}
    }
    public class magic2
    {
        protected internal void myfun()
        {
            Magic obj = new Magic();
            obj.c = 1;
        }
    }
    //public class magic:Class1.Class2
    //{
    //    void myfun() {
    //        Class1 obj = new Class1();
    //        Class1.Class2 obj2 = obj.createobj();

    //    }
    //}
  
}
