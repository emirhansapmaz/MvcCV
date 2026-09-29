using System;
using System.Collections.Generic;

namespace MvcCV.Models;

public partial class TblIletisim
{
    public int Id { get; set; }

    public string? Kimden { get; set; }

    public string? Mail { get; set; }

    public string? Konu { get; set; }

    public string? Mesaj { get; set; }

    public DateOnly? Tarih { get; set; }
}
