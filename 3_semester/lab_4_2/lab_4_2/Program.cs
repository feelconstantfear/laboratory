﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4_2
{
    public interface A{
        void mA();
        int fA();
    }

    public interface B{
        int fB();
        void mB();
    }

    public class C{
        public C() { this.v_1 = 33; }
        public int v_1 { set; get; }
        public int f()
        {
            Console.WriteLine("class C f() ");
            return 1;
        }
    }

    public class D : C, A, B{
        public D() { this.v_2 = 1; this.v_3 = 2; }
        protected int v_2 { set; get; }
        public int v_3 { set; get; }

        public void mA() { this.v_2 = this.v_3 + this.v_1; }
        public int fA() { return this.v_3 * 10; }

        public int fB() { return this.v_3 * (10-this.v_1); }
        public void mB() { this.v_2 = this.v_1*this.v_3+100; }
    }
    internal class Program{
        static void Main(string[] args)
        {
            A a = null;
            a = new D();
            a.mA();
            Console.WriteLine("    Комбинирование");
            Console.WriteLine($"a.fa() = {a.fA()}");
            Console.WriteLine($"((A)b).f() =  {((D)a).f()}");

            C c = new C();
            c.f();
            c = new D();

            Console.ReadKey();

        }
    }
}
