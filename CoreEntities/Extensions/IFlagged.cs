using System;
using System.Collections.Generic;
using System.Text;

namespace CoreEntities
{
    public interface IFlagged
    {
        bool Flagged { get; set; }
    }
}
