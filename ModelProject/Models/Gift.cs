﻿using System;
using System.Collections.Generic;

namespace ModelProject.Models
{
    public partial class Gift
    {
        public int GiftId { get; set; }
        public string ProductId { get; set; } = null!;
        public string GiftProduct { get; set; } = null!;
        public int GiftStatus { get; set; }

        public virtual ProductVersion GiftProductNavigation { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
