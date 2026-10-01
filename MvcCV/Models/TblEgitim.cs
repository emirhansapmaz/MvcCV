using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcCV.Models;

public partial class TblEgitim
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Başlık alanı boş bırakılamaz.")]
    public string? Baslik { get; set; }

    public string? AltBaslik { get; set; }

    public string? AltBaslik2 { get; set; }

    public string? Gno { get; set; }

    public string? Tarih { get; set; }
}
