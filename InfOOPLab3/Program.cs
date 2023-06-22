using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfOOPLab3
{
    public abstract class Pair
    {
        public abstract Pair Add(Pair other);
        public abstract Pair Subtract(Pair other);
        public abstract Pair Multiply(Pair other);
        public abstract Pair Divide(Pair other);
    }

    public class FuzzyNumber : Pair
    {
        public double Value { get; set; }

        public FuzzyNumber(double value)
        {
            Value = value;
        }

        public override Pair Add(Pair other)
        {
            if (other is FuzzyNumber fuzzyNumber)
            {
                double result = Value + fuzzyNumber.Value;
                return new FuzzyNumber(result);
            }
            throw new ArgumentException("Cannot add FuzzyNumber with a different type.");
        }

        public override Pair Subtract(Pair other)
        {
            if (other is FuzzyNumber fuzzyNumber)
            {
                double result = Value - fuzzyNumber.Value;
                return new FuzzyNumber(result);
            }
            throw new ArgumentException("Cannot subtract FuzzyNumber with a different type.");
        }

        public override Pair Multiply(Pair other)
        {
            if (other is FuzzyNumber fuzzyNumber)
            {
                double result = Value * fuzzyNumber.Value;
                return new FuzzyNumber(result);
            }
            throw new ArgumentException("Cannot multiply FuzzyNumber with a different type.");
        }

        public override Pair Divide(Pair other)
        {
            if (other is FuzzyNumber fuzzyNumber && fuzzyNumber.Value != 0)
            {
                double result = Value / fuzzyNumber.Value;
                return new FuzzyNumber(result);
            }
            throw new ArgumentException("Cannot divide FuzzyNumber with a different type or by zero.");
        }
    }

    public class Fraction : Pair
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public override Pair Add(Pair other)
        {
            if (other is Fraction fraction)
            {
                int newNumerator = Numerator * fraction.Denominator + fraction.Numerator * Denominator;
                int newDenominator = Denominator * fraction.Denominator;
                return new Fraction(newNumerator, newDenominator);
            }
            throw new ArgumentException("Cannot add Fraction with a different type.");
        }

        public override Pair Subtract(Pair other)
        {
            if (other is Fraction fraction)
            {
                int newNumerator = Numerator * fraction.Denominator - fraction.Numerator * Denominator;
                int newDenominator = Denominator * fraction.Denominator;
                return new Fraction(newNumerator, newDenominator);
            }
            throw new ArgumentException("Cannot subtract Fraction with a different type.");
        }

        public override Pair Multiply(Pair other)
        {
            if (other is Fraction fraction)
            {
                int newNumerator = Numerator * fraction.Numerator;
                int newDenominator = Denominator * fraction.Denominator;
                return new Fraction(newNumerator, newDenominator);
            }
            throw new ArgumentException("Cannot multiply Fraction with a different type.");
        }

        public override Pair Divide(Pair other)
        {
            if (other is Fraction fraction && fraction.Numerator != 0)
            {
                int newNumerator = Numerator * fraction.Denominator;
                int newDenominator = Denominator * fraction.Numerator;
                return new Fraction(newNumerator, newDenominator);
            }
            throw new ArgumentException("Cannot divide Fraction with a different type or by zero.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first value for FuzzyNumber:");
            double fuzzyValue1 = double.Parse(Console.ReadLine());
            FuzzyNumber fuzzyNumber1 = new FuzzyNumber(fuzzyValue1);

            Console.WriteLine("Enter second value for FuzzyNumber:");
            double fuzzyValue2 = double.Parse(Console.ReadLine());
            FuzzyNumber fuzzyNumber2 = new FuzzyNumber(fuzzyValue2);

            FuzzyNumber fuzzyAddition = (FuzzyNumber)fuzzyNumber1.Add(fuzzyNumber2);
            Console.WriteLine($"Fuzzy Addition: {fuzzyNumber1.Value} + {fuzzyNumber2.Value} = {fuzzyAddition.Value}");

            Console.WriteLine("Enter a value ('numerator/denominator') for first Fraction:");
            string fractionInput1 = Console.ReadLine();
            string[] fractionParts1 = fractionInput1.Split('/');
            int numerator1 = int.Parse(fractionParts1[0]);
            int denominator1 = int.Parse(fractionParts1[1]);
            Fraction fraction1 = new Fraction(numerator1, denominator1);

            Console.WriteLine("Enter a value('numerator/denominator') for second Fraction:");
            string fractionInput2 = Console.ReadLine();
            string[] fractionParts2 = fractionInput2.Split('/');
            int numerator2 = int.Parse(fractionParts2[0]);
            int denominator2 = int.Parse(fractionParts2[1]);
            Fraction fraction2 = new Fraction(numerator2, denominator2);

            Fraction fractionSubtraction = (Fraction)fraction1.Subtract(fraction2);
            Console.WriteLine($"Fraction Subtraction: {fraction1.Numerator}/{fraction1.Denominator} - {fraction2.Numerator}/{fraction2.Denominator} = {fractionSubtraction.Numerator}/{fractionSubtraction.Denominator}");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
