﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;



namespace Math.Structures
{
    #pragma warning disable CS0660 
    #pragma warning disable CS0661 

    class Fraction

    {
        private int _numerator, _denominator;

        public int Numerator { get => _numerator; set => _numerator = value; }
        public int Denominator { get => _denominator; set => _denominator = value; }

        public Fraction()
        {
            _numerator = 0; 
            _denominator = 1;
        }

        public Fraction(int numerator, int denominator = 1)
        {
            _numerator = numerator;
            _denominator = denominator;
            this.Simplify();
        }   

        public void Simplify()
        {
            int gcd = NumberOperation.GCD(_numerator, _denominator);
            _numerator /= gcd;
            _denominator /= gcd;

            if (_denominator < 0)
            {
                _numerator *= -1;
                _denominator *= -1;
            }
        }

        public void Invert()
        {
            int temp = _numerator;
            _numerator = _denominator;
            _denominator = temp;
        }

        public static Fraction operator + (Fraction first, Fraction second)
        {
            first.Simplify();
            second.Simplify();

            Fraction res = new Fraction();
            res.Numerator = first.Numerator * second.Denominator + second.Numerator * first.Denominator;
            res.Denominator = first.Denominator * second.Denominator;

            res.Simplify();   
            return res;
        }

        public static Fraction operator + (Fraction first, int second)
        {
            first.Simplify();

            Fraction res = new Fraction();
            res.Numerator = first.Numerator + second * first.Denominator;
            res.Denominator = first.Denominator;

            res.Simplify();
            return res;
        }

        public static Fraction operator + (int first, Fraction second) => second + first;

        public static Fraction operator - (Fraction first, Fraction second)
        {
            first.Simplify();
            second.Simplify();

            second.Numerator *= -1;

            return first + second;
        }

        public static Fraction operator - (Fraction first, int second)
        {
            first.Simplify();

            Fraction res = new Fraction();
            res.Numerator = first.Numerator - second * first.Denominator;
            res.Denominator = first.Denominator;

            res.Simplify();
            return res;
        }

        public static Fraction operator - (int first, Fraction second) => second - first;

        public static Fraction operator * (Fraction first, Fraction second)
        {
            Fraction res = new Fraction();
            res.Numerator = first.Numerator * second.Numerator;
            res.Denominator = first.Denominator * second.Denominator;

            res.Simplify();
            return res;
        }

        public static Fraction operator * (Fraction first, int second)
        {
            Fraction res = new Fraction();
            res.Numerator = first.Numerator * second;
            res.Denominator = first.Denominator;

            res.Simplify();
            return res;
        }

        public static Fraction operator * (int first, Fraction second) => second * first;

        public static Fraction operator / (Fraction first, Fraction second)
        {
            second.Invert();
            return first * second;
        }

        public static Fraction operator / (Fraction first, int second)
        {
            Fraction res = new Fraction();
            res.Numerator = first.Numerator;
            res.Denominator = first.Denominator * second;

            res.Simplify();
            return res;
        }

        public static Fraction operator / (int first, Fraction second) => second / first;

        public static bool operator == (Fraction first, Fraction second) => first.Numerator == second.Numerator && first.Denominator == second.Denominator;

        public static bool operator !=(Fraction first, Fraction second) =>  !(first == second);

        public static bool operator > (Fraction first, Fraction second) => first.ToDouble() > second.ToDouble();

        public static bool operator >= (Fraction first, Fraction second) => first.ToDouble() >= second.ToDouble();

        public static bool operator < (Fraction first, Fraction second) => !(first > second);

        public static bool operator <= (Fraction first, Fraction second) => !(first >= second);

        public static bool operator > (Fraction first, int second) => first.ToDouble() > second;

        public static bool operator >= (Fraction first, int second) => first.ToDouble() >= second;

        public static bool operator < (Fraction first, int second) => !(first > second);

        public static bool operator <= (Fraction first, int second) => !(first >= second);

        public static bool operator > (int first, Fraction second) => first > second.ToDouble();

        public static bool operator >= (int first, Fraction second) => first >= second.ToDouble();

        public static bool operator < (int first, Fraction second) => !(first > second);

        public static bool operator <= (int first, Fraction second) => !(first >= second);

        public static implicit operator double(Fraction val)
        {
            return val.ToDouble();
        }
        
        public static implicit operator Fraction(int val)
        {
            return new Fraction(val);
        }

        public double ToDouble() => (double)_numerator / (double)_denominator;

        public void Pow(int exponent)
        {
            _numerator = NumberOperation.Pow(_numerator, exponent);
            _denominator = NumberOperation.Pow(_denominator, exponent);
        }

    }

    #pragma warning restore CS0661
    #pragma warning restore CS0660

}
