using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Securit
{
    interface IRule
    {
        string Title { get; }
        bool Effective { get; }
        void Scan();
        void Apply();
    }
}
