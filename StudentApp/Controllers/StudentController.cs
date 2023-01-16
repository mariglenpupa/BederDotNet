using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentApp.Data;
using StudentApp.Data.Models;

namespace StudentApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    readonly ApplicationDbContext _db;
    public StudentController(ApplicationDbContext db) => _db = db;


    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Student student)
    {
        student.DateCreated = DateTime.Today;
        await _db.Students.AddAsync(student);

        return Ok("Student added");
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id) => Ok(_db.Students.FirstOrDefault(s => s.Id == id)!);

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] Student student)
    {
        var _student = _db.Students.FirstOrDefault(s => s.Id == student.Id);
        if (_student == default)
            return NotFound("Student not found!");

        if (student.DateUpdted != student.DateCreated)
            return NotFound("Student can't be updated");

        // Update
        _student.DateUpdted = DateTime.Today;
        _db.Students.Update(_student);
        await _db.SaveChangesAsync();

        return Ok("Student updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var student = _db.Students.FirstOrDefault(s => s.Id == id);
        if (student == default)
            return NotFound("Student not found");

        _db.Students.Remove(student);
        await _db.SaveChangesAsync();
        return Ok($"Students left: {_db.Students.Count()}");
    }
}