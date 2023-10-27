﻿using Common.FECore.Models;

namespace Common.FECore.Models
{
    public class ImageInfo : BaseEntity<Guid>
    {
        public string? Name { get; set; }
        public string? ClientName { get; set; }
        public string? Url { get; set; }
        public int? Size { get; set; }
    }
}
