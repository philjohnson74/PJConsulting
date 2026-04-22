using System;
using System.ComponentModel;

namespace PJConsulting_WebAPI.Data;

public class Consultancy
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public IList<Service> Services { get; set; } = [];
}