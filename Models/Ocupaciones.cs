using System.ComponentModel.DataAnnotations;

public class Ocupaciones
{
    [Key]
    public int OcupacionId { get; set; }
    public string? Descripcion { get; set; } 
    public int Salario { get; set; }
}
