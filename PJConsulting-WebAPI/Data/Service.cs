using System;
using System.ComponentModel;

namespace PJConsulting_WebAPI.Data;

public class Service
{
    public int Id { get; set; }

    public required String Name { get; set; }

    public String? Description { get; set; }

    public int ConsultancyId { get; set; }

    public Consultancy? Consultancy { get; set; }
}
