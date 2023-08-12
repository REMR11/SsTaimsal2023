using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SsTaimsal2023.EL;

[Table("Client")]
public partial class Client
{
    [Key]
    public int IdClient { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string NameClient { get; set; } = null!;

    [StringLength(300)]
    [Unicode(false)]
    public string? InfoClient { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? UrlImg { get; set; }

    [InverseProperty("IdClientNavigation")]
    public virtual ICollection<Report> Reports { get; } = new List<Report>();
}
