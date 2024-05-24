using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        string inputFilePath = "C:\\Users\\Бровко\\source\\repos\\modylee3\\modylee3\\bin\\Debug\\net8.0\\employees2.xml";
        string outputXmlFilePath = "sorted_employees.xml";
        string outputTxtFilePath = "employees.txt";

       
        XElement employeesXml = XElement.Load(inputFilePath);

       
        var employees = employeesXml.Elements("Employee")
            .Select(e => new Employee
            {
                Name = e.Element("Name").Value,
                Position = e.Element("Position").Value,
                HireDate = DateTime.Parse(e.Element("HireDate").Value)
            })
            .ToList();

       
        var sortedEmployees = employees.OrderBy(e => e.HireDate).ToList();

       
        XElement sortedEmployeesXml = new XElement("Employees",
            sortedEmployees.Select(e =>
                new XElement("Employee",
                    new XElement("Name", e.Name),
                    new XElement("Position", e.Position),
                    new XElement("HireDate", e.HireDate.ToString("yyyy-MM-dd"))
                )
            )
        );

        
        sortedEmployeesXml.Save(outputXmlFilePath);

        
        using (StreamWriter writer = new StreamWriter(outputTxtFilePath))
        {
            foreach (var employee in sortedEmployees)
            {
                writer.WriteLine($"Name: {employee.Name} Position: {employee.Position} HireDate: {employee.HireDate:yyyy-MM-dd}");
            }
        }
    }
}

class Employee
{
    public string Name { get; set; }
    public string Position { get; set; }
    public DateTime HireDate { get; set; }
}

