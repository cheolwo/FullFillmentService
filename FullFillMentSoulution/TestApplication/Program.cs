using StackExchange.Redis;
using System;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using FluentValidation;

public class A
{
    public A()
    {
        OnModelCreating();
    }
    public virtual void OnModelCreating()
    {
        Console.WriteLine("A OnModelCreating");
    }
}
public class B : A
{
    public override void OnModelCreating()
    {
        base.OnModelCreating();
        Console.WriteLine("B OnModelCreating");
    }
}
public class C : B
{
    public override void OnModelCreating()
    {
        base.OnModelCreating();
        Console.WriteLine("C OnModelCreating");
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        C c = new C();

    }
}
