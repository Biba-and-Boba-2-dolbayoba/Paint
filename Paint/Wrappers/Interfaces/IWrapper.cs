using Paint.Context.Interfaces;
using Paint.Components.Interfaces;

namespace Paint.Wrappers.Interfaces;

internal interface IWrapper {
    public IWrapperContext Context { get; set; }
    public IMovingComponent MovingComponent { get; set; }
    public IVisualComponent VisualComponent { get; set; }
}
