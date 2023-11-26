using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_Lab2
{
    internal interface ISearch
    {
        List<Material> Search(Material material, string path);
    }
}
