﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5
{
    public interface C
    {
        void mC();
        int fC();
    }

    public class E : C
    {
        private int e;
        public E()
        {
            Console.WriteLine("   create E()");
            this.e = 10;
        }
        public E(int e)
        {
            Console.WriteLine("   create E(int e) ");
            this.e = e;
        }
        public int fE() { return this.e; }

        public void mC() {
            this.e = 0;
        }
        public int fC() { return this.e * 10; }
    }

    public interface J : C
    {
        int fJ();
        void mJ();
    }

    public class K : E, J
    {
        private int a = 0;
        public K() {
            Console.WriteLine("   create K() ");
            this.a = this.fC() + this.fE(); 
        }

        public K(int e) : base(e)
        {
            Console.WriteLine("   create K(int e) ");
            this.a = this.fE()+1;
        }
        public int fJ() { return this.a; }
        public void mJ() {
            Console.WriteLine("K  k.mj()");
            this.a = this.fC() + this.fJ(); 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            C c = null;
            c = new E();
            Console.WriteLine("E  c.fC() = {0}", c.fC());
            E e = new E(1);
            Console.WriteLine("E  e.fC() = {0}", e.fC());
            Console.WriteLine("E  e.fE() = {0}", e.fE());

            J j = null;
            j = new K();
            Console.WriteLine("K  j.fC() = {0}", j.fC());
            Console.WriteLine("K  j.fj() = {0}", j.fJ());
            j = new K(30);
            Console.WriteLine("K  j.fC() = {0}", j.fC());

            c = new K();
            Console.WriteLine("K  c.fC() = {0}", c.fC());

            c = new K(99);
            Console.WriteLine("K  c.fC() = {0}", c.fC());

            K k = new K();
            Console.WriteLine("K  k.fj() = {0}", k.fJ());
            k.mJ();
            Console.WriteLine("K  k.fj() = {0}", k.fJ());

            Console.ReadKey();
        }
    }
}