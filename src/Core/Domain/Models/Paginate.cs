
namespace LMS.Core.Domain.Models
{
    public class Paginate<T>
    {
        public int Index { get; }
        public int Size { get; }
        public IList<T> Items { get; }
        public int TotalSize { get; }
        public int Total 
        {
            get { return (int)Math.Ceiling(TotalSize / (double)Size); }
        }
        public bool HasPrevious 
        {
            get { return Index > 0; }
        } 
        public bool HasNext 
        { 
            get { return Index < Total; }        
        }

        public Paginate(int index, int size, int totalSize, IList<T> items)
        {
            Index = index;
            Size = size;
            TotalSize = totalSize;
            Items = items;
        }

        public Paginate<TOther> ConvertItems<TOther>(Converter<T, TOther> converter)
        {
            var otherList = Items.ToList().ConvertAll(converter);
            return new Paginate<TOther>(Index, Size, TotalSize, otherList);
        }
    }
}
