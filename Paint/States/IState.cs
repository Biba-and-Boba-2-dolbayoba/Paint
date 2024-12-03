using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.States;
public interface IState {
    public void MouseUpHandler(object sender, MouseEventArgs e);
    public void MouseMoveHandler(object sender, MouseEventArgs e);
    public void MouseDownHandler(object sender, MouseEventArgs e);

}
