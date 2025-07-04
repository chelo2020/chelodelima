using System;
using System.Collections.Generic;

// Clase base
class Empleado
{
    private string nombre;
    private int edad;
    private double salario;

    public Empleado(string nombre, int edad, double salario)
    {
        this.nombre = nombre;
        this.edad = edad;
        this.salario = salario;
    }

    public virtual double CalcularBono()
    {
        return salario * 0.10;
    }

    public virtual void MostrarInformacion()
    {
        Console.WriteLine($"Empleado: {nombre}, Edad: {edad}, Bono: {CalcularBono():C2}");
    }
}

// Clase derivada: Gerente
class Gerente : Empleado
{
    public Gerente(string nombre, int edad, double salario) : base(nombre, edad, salario) { }

    public override double CalcularBono()
    {
        return base.CalcularBono() * 2.5; // 25%
    }

    public override void MostrarInformacion()
    {
        Console.WriteLine("Tipo: Gerente");
        base.MostrarInformacion();
    }
}

// Clase derivada: Vendedor
class Vendedor : Empleado
{
    private double ventasMensuales;

    public Vendedor(string nombre, int edad, double salario, double ventasMensuales)
        : base(nombre, edad, salario)
    {
        this.ventasMensuales = ventasMensuales;
    }

    public override double CalcularBono()
    {
        double porcentaje = ventasMensuales > 10000 ? 0.20 : 0.10;
        return base.CalcularBono() * (porcentaje / 0.10); // ajusta el bono base
    }

    public override void MostrarInformacion()
    {
        Console.WriteLine("Tipo: Vendedor");
        base.MostrarInformacion();
    }
}

// Programa principal
class Program
{
    static void Main()
    {
        List<Empleado> empleados = new List<Empleado>
        {
            new Gerente("Ana", 45, 5000),
            new Vendedor("Luis", 30, 3000, 12000),
            new Vendedor("Marta", 28, 3000, 8000)
        };

        foreach (Empleado emp in empleados)
        {
            emp.MostrarInformacion();
            Console.WriteLine("-----------------------");
        }
    }
}