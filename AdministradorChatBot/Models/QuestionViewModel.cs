using System.ComponentModel.DataAnnotations;

public class QuestionViewModel
{
    [Required]
    [StringLength(255)]
    public string Question { get; set; } = string.Empty;

    [Required]
    [MinLength(1), MaxLength(5)]
    public List<string> Answers { get; set; } = new() { "", "", "", "", "" };
}