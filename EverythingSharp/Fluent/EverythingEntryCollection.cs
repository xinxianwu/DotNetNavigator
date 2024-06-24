using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EverythingSharp.Fluent
{
    public class EverythingEntryCollection : IEnumerable<EverythingEntry>
    {
        private readonly List<EverythingEntry> _execute;

        public EverythingEntryCollection(List<EverythingEntry> execute)
        {
            _execute = execute;
        }

        public IEnumerator<EverythingEntry> GetEnumerator()
        {
            return _execute.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return $"{nameof(_execute)}: {string.Join(", ", _execute.Select(x => x.FullPath))}";
        }
    }
}