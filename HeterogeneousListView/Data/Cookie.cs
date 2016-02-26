namespace HeterogeneousListView.Data
{
    class Cookie
    {
        public int Pieces { get; set; }
        public override string ToString()
        {
            return $"Cookie {Pieces}";
        }
    }
}
