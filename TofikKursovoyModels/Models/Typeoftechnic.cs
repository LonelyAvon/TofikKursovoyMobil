﻿using System;
using System.Collections.Generic;

namespace TofikKursovoyModels;

public partial class Typeoftechnic
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
