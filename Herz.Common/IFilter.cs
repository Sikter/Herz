using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Herz.Common
{
    public interface IFilter<T>
    {
        IEnumerable<T> Execute(IEnumerable<T> input);

        int GetDelay();
    }
}
