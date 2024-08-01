using System;
using System.Collections.Generic;

namespace testmid.Models.Data;

public partial class Sale
{
    public int Id { get; set; }

    public int? CarId { get; set; }

    public int? CustomerId { get; set; }

    public double Discount { get; set; }

    public virtual Car? Car { get; set; }

    public virtual Customer? Customer { get; set; }
}
