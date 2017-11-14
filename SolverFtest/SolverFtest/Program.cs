﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SolverFoundation.Services;
using Microsoft.SolverFoundation.Common;
using Microsoft.SolverFoundation.Solvers;
namespace SolverFtest
{
    class Program
    {
        public static List<MiembroFo> LLenarLista()
        {
            List<MiembroFo> x = new List<MiembroFo>();
            Console.WriteLine("ingrese el numero de variables");
            int n;
        
            n = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
           
            while (n-- != 0)
            {    MiembroFo var=new MiembroFo();
                Console.WriteLine("nombre :");
                var.Name = Console.ReadLine();
                Console.WriteLine("coef:");
                var.Coef = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                var._value = 0;
                x.Add(var);
            }
            return x;
        }
        public static List<double> LLenarListadoble()
        {
            List<double> x = new List<double>();
            Console.WriteLine("ingrese el numero de variables");
            int n;

            n = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            while (n-- != 0)
            {
                double u = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                x.Add(u);
            }
            return x;
        }
        public static void MostrarFo(List<MiembroFo>x)
        {
            for (int i = 0; i < x.Count; i++)
            {
                Console.WriteLine(x[i].Name + "  = " + x[i].Coef + "X" + i);
            }
        }

        public static Restriction LLenarRestriccion(int n)
        {
           
            Restriction aux = new Restriction();
            Console.WriteLine("ingrese el nombre de la restriccion");
            aux.Name = Console.ReadLine();
            int i = 0;
            while (n-- != 0)
            {
                Console.WriteLine("ingrese el coeficiente");
                double yus= double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

                aux.Coef.Add(yus);
            }
            Console.WriteLine("ingrese el signo");
            aux._sign = Signo.MayorIgualQue;
            Console.WriteLine("ingrese el lado B");
            aux.Bside= double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            return aux;
        }

        public static void MostrarRestriccion(Restriction x)
        {
            Console.WriteLine(x.Name);
            Console.WriteLine("el signo es:  " + x._sign);
            for (int i = 0; i < x.Coef.Count; i++)
            {
                Console.WriteLine(x.Coef[i]+"X"+i);
            }
            
            Console.WriteLine("El lado B es "+x.Bside);
                
        }

        public static List<Restriction> LlenarListaderestricciones(int p)
        {
            List<Restriction> aux = new List<Restriction>();
            Console.WriteLine("ingrese el numero de restricciones");
            int n = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            while (n--!=0)
            {
                Restriction x = new Restriction();
                x = LLenarRestriccion(p);
                aux.Add(x);
                MostrarRestriccion(x);
            }
            return aux;
        }
        static void Main(string[] args)
        {

            List<MiembroFo> x=new List<MiembroFo>();

            x=LLenarLista();

            MostrarFo(x);
            Restriction y = new Restriction();

            Simplex aurus = new Simplex(x, true);

            aurus.AddRestriction(LlenarListaderestricciones(x.Count));
            aurus.Solver.Solve(new SimplexSolverParams());
            Console.WriteLine(aurus.Solver.GetValue(aurus._z).ToDouble());

            Console.WriteLine(aurus.Solver.FactorCount+1);//CUANTAS iteraciones matriciales se realizo

            aurus.Solver.GetReport(new LinearSolverReportType());

            

            Console.ReadKey();
        }
    }
}
