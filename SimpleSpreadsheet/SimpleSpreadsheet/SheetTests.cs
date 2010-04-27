/*

Test-First Challenge:
    
    This is a (super-) simple spreadsheet.
    http://xp123.com/xplor/xp0201/ 
 
*/

using System;
using NUnit.Framework;

namespace SimpleSpreadsheet {
    public class SheetTests {
        private Sheet _sheet;

        [SetUp]
        public void Setup()
        {
            _sheet = new Sheet();
        }

        [TestCase("A1")]
        [TestCase("ZX347")]
        public void Get_CellsAreEmpty_ReturnDefaultValue(string cell)
        {
            var value = _sheet.Get(cell);

            Assert.That(value, Is.Empty);
        }

        [TestCase(" 123 ")]
        [TestCase(" A string")]
        public void GetLiteral_ReturnLiterralValueForEditing(string value) {
            var theCell = "A21";
            
            Verify_PutAndGetLiteral_FromTheCell(theCell, value);
        }

        [TestCase("A string")]
        [TestCase(" A string")]
        public void Get_ReturnTextCellsAreStored(string value)
        {
            var theCell = "A21";

            Verify_PutAndGet_FromTheCell(theCell, value, value);
        }

        [Test]
        public void Get_ReturnBlankNumericValue() {
            var theCell = "A21";
            var value = " 123 ";
            var expectedResult = "123";

            Verify_PutAndGet_FromTheCell(theCell, value, expectedResult);
        }

        [Test]
        public void Put_UpdateTextOnExistingCell() {
            var theCell = "A21";
            var value = "A string";
            var anotherValue = "Another String";

            Verify_PutAndGet_FromTheCell(theCell, value, value);
            Verify_PutAndGet_FromTheCell(theCell, anotherValue, anotherValue);
        }

        [Test]
        public void Put_MultipleCells()
        {
            Verify_PutAndGet_FromTheCell("A1", "First", "First");
            Verify_PutAndGet_FromTheCell("AB1", "Second", "Second");
        }

        [Test]
        public void Get_FormulaSpec()
        {
            var theCell = "B1";
            var value = " =7";

            Verify_PutAndGet_FromTheCell(theCell, value, value);
        }

        [Test]
        public void GetLiteral_FormulaSpec() {
            var theCell = "B1";
            var value = " =7";

            Verify_PutAndGetLiteral_FromTheCell(theCell, value);
        }

        [Test]
        public void Get_ConstantFormula_ReturnTheContant()
        {
            var theCell = "A1";
            var formula = "=7";

            Verify_PutAndGet_FromTheCell(theCell, formula, "7");
        }

        [Test]
        public void GetLiteral_ConstantFormula_ReturnTheLiteralValue() {
            var theCell = "A1";
            var formula = "=7";

            Verify_PutAndGetLiteral_FromTheCell(theCell, formula);
        }

        [Ignore]
        [Test]
        public void Get_ArithmaticFormula_ReturnTheResultOfArithmatic()
        {
            var theCell = "A1";
            var formula = "=2*3";
            var expectedResult = "5";

            Verify_PutAndGet_FromTheCell(theCell, formula, expectedResult);
        }

        private void Verify_PutAndGet_FromTheCell(string cell, string value, string expectedResult)
        {
            _sheet.Put(cell, value);

            var cellValue = _sheet.Get(cell);

            Assert.That(cellValue, Is.EqualTo(expectedResult));
        }

        private void Verify_PutAndGetLiteral_FromTheCell(string cell, string value) 
        {
            _sheet.Put(cell, value);

            var cellValue = _sheet.GetLiteral(cell);

            Assert.That(cellValue, Is.EqualTo(value));
        }
    }
}
