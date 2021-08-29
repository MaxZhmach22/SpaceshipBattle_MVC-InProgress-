using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellicopterGame
{
    public class FactoryMerger
    {
        List<IFactory> _factories = new List<IFactory>();

        public void AddFactory(IFactory factory)
        {
            _factories.Add(factory);
        }

        public void CreateObj(UnitList unitList)
        {
            foreach (var unit in unitList.unit) 
            {
                foreach (var factory in _factories)
                {
                    if (factory.Name == unit.type)
                    {
                        factory.Create(unit);
                    }
                }
            }
        }
    }
}
