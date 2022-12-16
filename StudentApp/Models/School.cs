using System;
namespace StudentApp.Models;

public sealed class School : BaseClass
{
    public string Name { get; set; } = "";
    public string Address { get; set; } = "";
    public int YearEstablished { get; set; }
}