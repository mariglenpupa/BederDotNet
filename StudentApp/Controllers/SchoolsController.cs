using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentApp.Data;
using StudentApp.Data.Models;

namespace StudentApp.Controllers;

[Route("api/[controller]")]
public class SchoolsController : Controller
{
    readonly ApplicationDbContext _db;
    public SchoolsController(ApplicationDbContext db) => _db = db;

    [HttpGet("{id}")]
    public School GetById(int id) => _db.Schools.FirstOrDefault(s => s.Id == id)!;

    [HttpDelete("Delete/{id}")]
    public async Task<int> DeleteById(int id)
    {
        _db.Schools.Remove(_db.Schools.FirstOrDefault(s => s.Id == id)!);
        await _db.SaveChangesAsync();
        return _db.Schools.Count();
    }
}

