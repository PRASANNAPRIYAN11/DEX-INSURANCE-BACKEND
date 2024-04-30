using System;
using System.Collections.Generic;

namespace InsuranceApi.Models;

public partial class Cards
{
    public string UserName { get; set; } = null!;

    public int CardNumber { get; set; }

    public string Expiry { get; set; } = null!;
}


