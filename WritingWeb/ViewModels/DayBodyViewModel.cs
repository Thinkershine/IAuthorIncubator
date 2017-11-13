﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WritingWeb.ViewModels
{
    public class DayBodyViewModel
    {
        public int Id { get; set; }
        [Required]
        public int DayId { get; set; }
        [Required]
        public int PathId { get; set; }
        [Required]
        public string WrittenText { get; set; }
        [Required]
        public int WrittenWords { get; set; }
        public string HiddenWisdom { get; set; }
        public IEnumerable<string> ExercisePrompts { get; set; }
    }
}