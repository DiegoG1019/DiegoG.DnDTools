using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoG.DnDTools.Services.Common.Requests.Filtering;

public sealed class DataSetFilter
{
    public IEnumerable<PropertyFilter>? PropertyFilters { get; set; }
    public OrderByProperty? OrderBy { get; set; }
    public int? PageSize { get; set; }
    public int? Skip { get; set; }
}
