using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseRentApi.Models;

/// <summary>
/// Представляет собой базовый интерфейс 
/// </summary>
public interface IEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set;}
    public Guid Guid { get; set;}
}