using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SsTaimsal2023.EL;

[Table("Report")]
[Index("IdClient", Name = "IX_Report_IdClient")]
[Index("IdMachine", Name = "IX_Report_IdMachine")]
[Index("IdProduct", Name = "IX_Report_IdProduct")]
[Index("IdUser", Name = "IX_Report_IdUser")]
public partial class Report
{
    [Key]
    public int IdReport { get; set; }

    public int IdUser { get; set; }

    public int? IdClient { get; set; }

    public int? IdProduct { get; set; }

    public int? IdMachine { get; set; }

    [ForeignKey("IdClient")]
    [InverseProperty("Reports")]
    public virtual Client? IdClientNavigation { get; set; }

    [ForeignKey("IdMachine")]
    [InverseProperty("Reports")]
    public virtual Machine? IdMachineNavigation { get; set; }

    [ForeignKey("IdProduct")]
    [InverseProperty("Reports")]
    public virtual Product? IdProductNavigation { get; set; }

    [ForeignKey("IdUser")]
    [InverseProperty("Reports")]
    public virtual UserDev IdUserNavigation { get; set; } = null!;
}
