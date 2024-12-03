namespace Paint.Figures;

internal interface IFigure {
    public Color LineColor { get; set; }
    public int BrushSize{  get; set; }
    public Color BackColor{ get; set; }
    public bool IsFilling {  get; set; }
    public void Draw(Graphics g);
    public void Hide(Graphics g);
    public void Dash(Graphics g);
    public void DrawSelection(Graphics g);
    public void ContainsPoint(Point point);

}
