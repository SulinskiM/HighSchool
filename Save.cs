using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Save
    {
        public int whichSaves { get; set; }
        public int howMuchSaves { get; set; }

        private List<GraphOfFunction> saves;

        public Save()
        {
            whichSaves = 1;
            howMuchSaves = 0;
            saves = new List<GraphOfFunction>();
        }
        public void SaveGraph(GraphOfFunction fun)
        {
            saves.Add(fun);
            howMuchSaves++;
        }
        public GraphOfFunction ReturnSave()
        {
            return saves[whichSaves - 1];
        } 
    }
}
