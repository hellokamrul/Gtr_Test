using System;
using System.Collections.Generic;

namespace DemoTest.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public string Qty { get; set; } = null!;

    public virtual Oder? Oder { get; set; }
}
