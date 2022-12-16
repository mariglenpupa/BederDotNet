using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentApp.Models;

namespace StudentApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    // Temp database
    static List<Student> Students = new()
    {
       new Student
       {
           Id = 1,
           DateCreated = DateTime.Today,
           DateUpdted = DateTime.Today,
           DateOfBirth = DateTime.Today.AddYears(-70),
           FirstName = "Bill",
           LastName = "Gates",
           GraduationYear = 1990,
       },
       new Student
       {
           Id = 2,
           DateCreated = DateTime.Today,
           DateUpdted = DateTime.Today,
           DateOfBirth = DateTime.Today.AddYears(-50),
           FirstName = "Elon",
           LastName = "Musk",
           GraduationYear = 1990,
       }
    };


    [HttpPost]
    public IActionResult Post([FromBody] Student student)
    {
        student.Id = Students.Count + 1;
        student.DateCreated = DateTime.Today;

        Students.Add(student);
        return Ok("Student added");
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id) => Ok(Students.FirstOrDefault(s => s.Id == id)!);

    [HttpPut]
    public IActionResult Put([FromBody] Student student)
    {
        if (student.Id > Students.Count)
            return NotFound("Student not found!");

        if (student.DateUpdted != student.DateCreated)
            return NotFound("Student can't be updated");

        // Update
        student.DateUpdted = DateTime.Today;
        Students[student.Id - 1] = student;
        return Ok("Student updated");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var student = Students.FirstOrDefault(s => s.Id == id);
        if (student == default)
            return NotFound("Student not found");

        Students.Remove(student);
        return Ok($"Students left: {Students.Count}");
    }
}