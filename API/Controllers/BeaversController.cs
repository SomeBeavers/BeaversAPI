﻿using API.Converters;
using API.Models;
using BeaversDB;
using BeaversDB.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BeaversController(AnimalContext context) : ControllerBase
{
    // GET: api/Beavers
    [HttpGet]
    public ActionResult<IEnumerable<BeaverModel>> GetBeavers()
    {
        return context.Beavers.Select(b => b.ToModel()).ToList();
    }

    // GET: api/Beavers/5
    [HttpGet("{id}")]
    public async Task<ActionResult<BeaverModel>> GetBeaver(int id)
    {
        var beaver = await context.Beavers.FindAsync(id);
        if (beaver == null) return NotFound();
        return beaver.ToModel();
    }

    // PUT: api/Beavers/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBeaver(int id, BeaverModel beaverModel)
    {
        if (id != beaverModel.Id) return BadRequest();
        var beaver = await context.Beavers.FindAsync(id);
        if (beaver == null) return NotFound();
        beaver.Name = beaverModel.Name;
        beaver.Fluffiness = Enum.Parse<FluffinessEnum>(beaverModel.Fluffiness);
        beaver.Size = beaverModel.Size;
        // Update other properties
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BeaverExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // POST: api/Beavers
    [HttpPost]
    public async Task<ActionResult<BeaverModel>> PostBeaver(BeaverModel beaverModel)
    {
        var beaver = beaverModel.ToEntity();
        context.Beavers.Add(beaver);
        await context.SaveChangesAsync();
        return CreatedAtAction("GetBeaver", new { id = beaver.Id }, beaver.ToModel());
    }



    private bool BeaverExists(int id)
    {
        return context.Beavers.Any(e => e.Id == id);
    }
}