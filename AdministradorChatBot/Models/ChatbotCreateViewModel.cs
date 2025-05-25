using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AdministradorChatBot.Models;

using System.ComponentModel.DataAnnotations;

public class ChatbotCreateViewModel
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(500)]
    public string Description { get; set; } = null!;

    [Required]
    [StringLength(255)]
    public string Question { get; set; } = null!;

    [Required]
    [MinLength(1)]
    public List<QuestionViewModel> Questions { get; set; } = new() { new QuestionViewModel() };

}