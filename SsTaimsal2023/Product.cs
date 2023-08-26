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
    [Required(ErrorMessage = "Nombre de producto requerido")]
    [StringLength(30, ErrorMessage ="Máximo de 30 caracteres")]
    [Unicode(false)]
    public string NameProduct { get; set; } = null!;

    [StringLength(300, ErrorMessage="Máximo de 300")]
    [Unicode(false)]
    public string? InfoProduct { get; set; }
    [StringLength(100, ErrorMessage ="Excedes el maximo de capacidad de la capacidad del sistema")]
    public int? Stock { get; set; }
    [Column(TypeName ="decimal(18, 2)")]
    public decimal Price { get; set; }
    [StringLength(1)]
    [Unicode(false)]
    public string? UrlImg { get; set; }

    [InverseProperty("IdProductNavigation")]
    public virtual ICollection<Report> Reports { get; } = new List<Report>();
    [NotMapped]
    public int Top_aux { get; set; }
}
