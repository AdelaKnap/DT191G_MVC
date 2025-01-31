using System.ComponentModel.DataAnnotations;

namespace DT191G_MVC.Models;

public class FormModel
{
    // Properties
    [Required(ErrorMessage = "Du måste ange hundens namn.")]
    [Display(Name = "Hundens namn:")]
    public string? DogName { get; set; }

    [Required(ErrorMessage = "Du måste ange ras.")]
    [Display(Name = "Ras:")]
    public string? BreedName { get; set; }

    [Required(ErrorMessage = "Du måste ange ålder.")]
    [Range(0, 30, ErrorMessage = "Åldern måste vara mellan 0 och 30.")]
    [Display(Name = "Ålder:")]
    public int? Age { get; set; }

    [Required(ErrorMessage = "Du måste välja om du är en hund-nörd eller inte.")]
    public bool? DogLover { get; set; }
}