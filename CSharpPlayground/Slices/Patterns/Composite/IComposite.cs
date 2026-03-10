namespace CSharpPlayground.Slices.Patterns.Composite
{
    public interface IComposite
    {
        void Select();
        void Deselect();
        IEnumerable<int> GetSelectedIds();
        bool IsSelected { get; }
    }
}

