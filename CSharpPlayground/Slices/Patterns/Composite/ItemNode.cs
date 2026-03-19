namespace CSharpPlayground.Slices.Patterns.Composite
{
    public class ItemNode : IComposite
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int GroupId { get; set; }

        public bool IsSelected { get; private set; }

        public void Select()
        {
            IsSelected = true;
        }

        public void Deselect()
        {
            IsSelected = false;
        }

        public IEnumerable<int> GetSelectedIds()
        {
            return IsSelected ? new[] { Id } : Array.Empty<int>();
        }
    }
}

