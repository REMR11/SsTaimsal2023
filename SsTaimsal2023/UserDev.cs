using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SsTaimsal2023.EL;

[Table("UserDev")]
[Index("IdRol", Name = "IX_UserDev_IdRol")]
public partial class UserDev
{
    [Key]
    public int IdUser { get; set; }

    public int? IdRol { get; set; }

    [StringLength(30)]
    public string NameUser { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string? Login { get; set; }

    [StringLength(32)]
    public string Password { get; set; } = null!;

    [Column("Status_User")]
    public byte StatusUser { get; set; }

    public DateTime RegistrationUser { get; set; }

    [ForeignKey("IdRol")]
    [InverseProperty("UserDevs")]
    public virtual Rol? IdRolNavigation { get; set; }

    [InverseProperty("IdUserNavigation")]
    public virtual ICollection<Report> Reports { get; } = new List<Report>();
}
