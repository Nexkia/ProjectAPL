using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public interface IFactory
    {
        string[] getDetail();
        int getValutazione();
        string getModello();
        string[] getMoreDetail();
        bool getCompatibility();
    }
}
