using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace SsTaimsal2023.EL;

[Table("UserDev")]
[Index("IdRol", Name = "IX_UserDev_IdRol")]
public partial class UserDev
{
    [Key]
    public int IdUser { get; set; }
    [Required(ErrorMessage = "Rol es obligatorio")]
    [Display(Name ="Rol")]
    public int? IdRol { get; set; }
    [Required(ErrorMessage ="Nombre es obligatorio")]
    [StringLength(30, ErrorMessage ="Máximo 30 caracteres")]
    public string NameUser { get; set; } = null!;

    [Required(ErrorMessage ="Login es obligatorio")]
    [StringLength(30, ErrorMessage ="Máximo 25 caracteres")]
    [Unicode(false)]
    public string? Login { get; set; }
    [Required(ErrorMessage ="Contraseña es obligatoria")]
    [DataType(DataType.Password)]
    [StringLength(32, ErrorMessage ="Contraseña debe tener al menos 5 caracteres y máximo 32")]
    public string Password { get; set; } = null!;

    [Column("Status_User")]
    public byte StatusUser { get; set; }
    [Display(Name ="Dia registrado")]
    public DateTime RegistrationUser { get; set; }

    [ForeignKey("IdRol")]
    [InverseProperty("UserDevs")]
    public virtual Rol? IdRolNavigation { get; set; }

    [InverseProperty("IdUserNavigation")]
    public virtual ICollection<Report> Reports { get; } = new List<Report>();
    [NotMapped]
    public int Top_Aux { get; set; }
    [NotMapped]
    [Required(ErrorMessage ="Confirmar contraseña")]
    [StringLength(32, ErrorMessage = "Contraseña debe tener al menos 5 caracteres y máximo 32")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage ="La contraseña debe ser la misma")]
    public string ConfirmPassword_aux { get; set; }
}
public enum Status_User
{
    activo=1,
    inactivo=2
}