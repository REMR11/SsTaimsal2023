using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SsTaimsal2023.EL;

[Table("Machine")]
public partial class Machine
{
    [Key]
    public int IdMachine { get; set; }

    [StringLength(30, ErrorMessage = "Máximo de 30 caracteres")]
    [Unicode(false)]
    public string? NameMachine { get; set; }

    [Unicode(false)]
    public string? UrlImg { get; set; }

    [InverseProperty("IdMachineNavigation")]
    public virtual ICollection<Report> Reports { get; } = new List<Report>();
    [NotMapped]
    public int Top_Aux { get; set; }
}
