using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SsTaimsal2023.EL;

[Table("Rol")]
public partial class Rol
{
    [Key]
    public int IdRol { get; set; }
    [Required(ErrorMessage ="Nombre es obligatorio")]
    [Column("Name_Rol")]
    [StringLength(30, ErrorMessage ="Máximo de 30 caracteres")]
    [Unicode(false)]
    public string NameRol { get; set; } = null!;

    [InverseProperty("IdRolNavigation")]
    public virtual ICollection<UserDev> UserDevs { get; } = new List<UserDev>();
    [NotMapped]
    public int Top_Aux { get; set; }
}
