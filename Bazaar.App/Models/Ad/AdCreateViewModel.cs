﻿using System.ComponentModel.DataAnnotations;
using Bazaar.BL.Dtos.Tag;

namespace Bazaar.App.Models
{
    public class AdCreateViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Description { get; set; }

        public bool IsPremium { get; set; } = false;

        public bool IsValid { get; set; } = true;

        public bool IsOffer { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Price must be a positive number")]
        public int Price { get; set; }
        public Guid UserId { get; set; }
        public IEnumerable<Guid>? TagIds { get; set; } = new List<Guid>();

        public List<TagDto>? AllTags { get; set; }
        public IEnumerable<IFormFile>? Files { get; set; }

    }
}
