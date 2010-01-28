using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringSet {
    public class StringSet {
        private IList<string> _items = new List<string>();

        public string Add(string item) {
            if (!_items.Contains(item))
                _items.Add(item);

            return item;
        }

        public int Count {
            get {
                return _items.Count;
            }
        }

        public bool Remove(string item) {
            return _items.Remove(item);
        }

        public void Clear() {
            _items.Clear();
        }

        public StringSet Union(StringSet second) {
            return this + second;
        }

        public StringSet Intersect(StringSet second) {
            return this - second;
        }

        public static StringSet operator +(StringSet first, StringSet second) {
            var result = new StringSet();

            CopyItems(first, result);
            CopyItems(second, result);

            return result;
        }

        public static StringSet operator -(StringSet first, StringSet second) {
            var result = new StringSet();

            foreach (var item in first._items) {
                if (second._items.Contains(item))
                    result.Add(item);
            }

            return result;
        }

        private static void CopyItems(StringSet source, StringSet destination) {
            foreach (var item in source._items) {
                destination.Add(item);
            }
        }
    }
}
