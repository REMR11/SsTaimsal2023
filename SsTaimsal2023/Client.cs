using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Azure;
using Microsoft.EntityFrameworkCore;

namespace SsTaimsal2023.EL;

[Table("Client")]
public partial class Client
{
    [Key]
    public int IdClient { get; set; }
    [Required(ErrorMessage = "Nombre de Cliente es obligatorio")]
    [StringLength(30, ErrorMessage ="Máximo de 30 caracteres")]
    [Unicode(false)]
    public string NameClient { get; set; } = null!;

    [StringLength(300, ErrorMessage = "Máximo de 300 caracteres")]
    [Unicode(false)]
    public string? InfoClient { get; set; }

    [Unicode(false)]
    public string? UrlImg { get; set; }

    [InverseProperty("IdClientNavigation")]
    public virtual ICollection<Report> Reports { get; } = new List<Report>();
    [NotMapped]
    public int Top_Aux { get; set; }
}
