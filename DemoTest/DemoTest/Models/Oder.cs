using System;
using System.Collections.Generic;

namespace DemoTest.Models;

public partial class Oder
{
    public int Id { get; set; }

    public string Orders { get; set; } = null!;

    public virtual Product IdNavigation { get; set; } = null!;
}
