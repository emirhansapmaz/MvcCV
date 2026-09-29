using System;
using System.Collections.Generic;

namespace MvcCV.Models;

public partial class TblDeneyim
{
    public int Id { get; set; }

    public string? Baslik { get; set; }

    public string? AltBaslik { get; set; }

    public string? Aciklama { get; set; }

    public string? Tarih { get; set; }
}
