namespace CSharpPlayground.Slices.Patterns.Composite
{
    public class GroupNode : IComposite
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<IComposite> ChildNode { get; } = new();

        public bool IsSelected => ChildNode.Any(child => child.IsSelected);

        public void Select()
        {
            foreach (var child in ChildNode)
            {
                child.Select();
            }
        }

        public void Deselect()
        {
            foreach (var child in ChildNode)
            {
                child.Deselect();
            }
        }

        public IEnumerable<int> GetSelectedIds()
        {
            return ChildNode.SelectMany(child => child.GetSelectedIds());
        }
    }
}

