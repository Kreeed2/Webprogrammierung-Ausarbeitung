using System;

namespace AusarbeitungASP.NET
{
    //https://github.com/stubbscroll/TCR/blob/master/routines-JAVA/newton-interpolation.java
    //Under GPL-3.0

    public class NewtonPolynom
    {
        static double EPS = 1e-8;
        double[] p;

        NewtonPolynom(double[] a)
        {
            p = (double[])a.Clone(); Reduce();
        }

        void Reduce()
        {
            int size;
            for (size = p.Length - 1; size > 0 && Math.Abs(p[size]) < EPS; size--) ;
            if (++size < p.Length)
            {
                double[] q = new double[size];
                for (int i = 0; i < size; i++) q[i] = p[i];
                p = q;
            }
        }

        NewtonPolynom Add(NewtonPolynom b)
        {
            int n = Math.Max(this.p.Length, b.p.Length);
            double[] q = new double[n];
            for (int i = 0; i < n; i++)
            {
                if (i < this.p.Length) q[i] += this.p[i];
                if (i < b.p.Length) q[i] += b.p[i];
            }
            return new NewtonPolynom(q);
        }
        NewtonPolynom Multiply(NewtonPolynom b)
        {
            double[] q = new double[this.p.Length + b.p.Length - 1];
            for (int i = 0; i < this.p.Length; i++) for (int j = 0; j < b.p.Length; j++)
                    q[i + j] += this.p[i] * b.p[j];
            return new NewtonPolynom(q);
        }

        /* newton's interpolation method: for n pairs (x,f(x)), return n-degree polynomial
               lowest degree earliest in returned array */
        public static double[] Newton(double[] f, double[] x)
        {
            NewtonPolynom r = new NewtonPolynom(new double[] { f[0] });
            int n = f.Length;
            double[,] a = new double[n, n];
            for (int i = 0; i < n; i++)
                a[0, i] = f[i];
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < n - i; j++)
                    a[i, j] = (a[i - 1, j + 1] - a[i - 1, j]) / (x[j + i] - x[j]);
                NewtonPolynom m = new NewtonPolynom(new double[] { a[i, 0] });
                for (int j = 0; j < i; j++)
                {
                    m = m.Multiply(new NewtonPolynom(new double[] { -x[j], 1 }));
                }
                r = r.Add(m);
            }
            return r.p;
        }
    }
}