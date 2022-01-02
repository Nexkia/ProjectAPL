using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Data;
namespace Client
{
    class ConcreteConstructorFabric : ComponentFactory
    {

        public override IFactory GetComponent(string Component)
        {
            switch (Component)
            {
                case "cpu":
                    return new Cpu();
                case "schedaVideo":
                    return new SchedaVideo();
                case "schedaMadre":
                    return new SchedaMadre();
                case "dissipatore":
                    return new Dissipatore();
                case "alimentatore":
                    return new Alimentatore();
                case "casepc":
                    return new CasePC();
                case "ram":
                    return new Ram();
                case "memoria":
                    return new Memoria();
                default:
                    return new Memoria();
            }
        }
    }
}
