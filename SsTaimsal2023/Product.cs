using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SsTaimsal2023.EL;

[Table("Product")]
public partial class Product
{
    [Key]
    public int IdProduct { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string NameProduct { get; set; } = null!;

    [StringLength(300)]
    [Unicode(false)]
    public string? InfoProduct { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? UrlImg { get; set; }

    [InverseProperty("IdProductNavigation")]
    public virtual ICollection<Report> Reports { get; } = new List<Report>();
}
