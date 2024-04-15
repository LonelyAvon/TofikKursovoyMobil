using System;
using System.Collections.Generic;

namespace TofikKursovoyModels;

public partial class Discount
{
    public int Id { get; set; }

    public int? IdProduct { get; set; }

    public int? DiscountCost { get; set; }

    public virtual Product? IdProductNavigation { get; set; }
}
