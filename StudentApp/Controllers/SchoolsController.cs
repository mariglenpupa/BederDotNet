using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentApp.Models;

namespace StudentApp.Controllers;

[Route("api/[controller]")]
public class SchoolsController : Controller
{
    static List<School> Schools = new() 
    {
        new School
        {
            Id = 0,
            Name = "KU Beder",
            DateCreated = DateTime.Now.AddYears(-6),
            DateUpdted = DateTime.Now,
            Address = "Jordan Misja",
            YearEstablished = 2011
        },
        new School
        {
            Id = 1,
            Name = "School 1",
            DateCreated = DateTime.Now.AddYears(-6),
            DateUpdted = DateTime.Now,
            Address = "",
            YearEstablished = 2011
        }
    };

    [HttpGet("{id}")]
    public School GetById(int id) => Schools.FirstOrDefault(s => s.Id == id)!;

    [HttpDelete("Delete/{id}")]
    public int DeleteById(int id)
    {
        Schools.Remove(Schools.FirstOrDefault(s => s.Id == id)!);
        return Schools.Count;
    }
}

