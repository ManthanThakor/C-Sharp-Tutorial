﻿using Domain.CommonEntity;
using System;

namespace Domain.Models
{
    public class ItemImage : BaseEntity
    {
        public string ImageUrl { get; set; }

        public Guid ItemId { get; set; }
        public virtual Item Item { get; set; }
    }
}
