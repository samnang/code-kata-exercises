using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using NUnit.Framework;

namespace SimpleSpreadsheet {
    class Sheet {
        private readonly StringDictionary _cells;
        private readonly string _defaultEmptyCellValue = string.Empty;

        public Sheet()
        {
            
            _cells = new StringDictionary();
        }

        public string Get(string cell)
        {
            var literalValue = GetLiteral(cell);
            if (IsFormula(literalValue))
                return literalValue.Substring(1); 

            return HandleNumericValue(literalValue); 
        }

        public string GetLiteral(string cell)
        {
            if (IsCellAlreadyHasValue(cell)) {
                return _cells[cell];
            }

            return _defaultEmptyCellValue;
        }

        public void Put(string cell, string value)
        {
            if (IsCellAlreadyHasValue(cell))
            {
                _cells[cell] = value;
            }
            else
            {
                _cells.Add(cell, value);   
            }
        }

        private bool IsFormula(string literalValue)
        {
            return literalValue.Length > 0 && literalValue[0] == '=';
        }

        private string HandleNumericValue(string value)
        {
            var tempNumericValue = 0.0;
            if (Double.TryParse(value.Trim(), out tempNumericValue))
            {
                value = value.Trim();   
            }
            return value;
        }

        private bool IsCellAlreadyHasValue(string cell)
        {
            return _cells.ContainsKey(cell);
        }
    }
}
