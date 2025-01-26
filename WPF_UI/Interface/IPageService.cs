using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro_WPF.Interface
{
    public interface IPageService
    {
        Type GetPageType(string key);
    }
}
