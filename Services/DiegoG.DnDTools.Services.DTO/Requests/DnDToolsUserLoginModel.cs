using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoG.DnDTools.Services.Common.Requests;
public class DnDToolsUserLoginModel
{
    public string? UsernameOrEmail { get; set; }
    public string? Password { get; set; }
}
