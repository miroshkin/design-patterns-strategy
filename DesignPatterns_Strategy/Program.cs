using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns_Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Report report = new Report();

            List<int> data = new List<int>()
            {
                1,2,3,4,5,6,7,17,18,19,20,55,60,75,85,90
            };

            report.Algorithm = new OfficialData();
            Console.WriteLine($"Official data: {report.GetReportMessage(data)}");

            report.Algorithm = new RealData();;
            Console.WriteLine($"Real data: {report.GetReportMessage(data)}");
        }
    }

    class OfficialData : ICalculate
    {
        public double Calculate(List<int> data)
        {
            return data.Where(age => age > 18 & age < 65).Average();
        }
    }

    class RealData : ICalculate
    {
        public double Calculate(List<int> data)
        {
            return data.Average();
        }
    }

    class Report
    {
        public ICalculate Algorithm { get; set; }

        public string GetReportMessage(List<int> data)
        {
            return $"Average age of the population is {Algorithm.Calculate(data)}";
        }
    }

    interface ICalculate
    {
        double Calculate(List<int> data);
    }
}
