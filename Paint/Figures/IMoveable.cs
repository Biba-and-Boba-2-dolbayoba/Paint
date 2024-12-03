using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Figures;
internal interface IMoveable {
    public bool CanMove(int dx, int dy, Size bounds);
    public void Move(int dx, int dy);


}
