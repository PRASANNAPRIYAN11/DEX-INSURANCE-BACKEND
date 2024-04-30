using System;
using System.Collections.Generic;

namespace InsuranceApi.Models;

public partial class Credential
{
    public string UserName { get; set; } = null!;

    public int UserId { get; set; }

    public string Password { get; set; } = null!;
}


