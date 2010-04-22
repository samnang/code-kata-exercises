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
            _sheet.Put(theCell, value);
            
            var literalValue = _sheet.GetLiteral(theCell);

            Assert.That(literalValue, Is.EqualTo(value));
        }

        [TestCase("A string")]
        [TestCase(" A string")]
        public void Get_ReturnTextCellsAreStored(string value)
        {
            var theCell = "A21";

            Verify_PutAndGet_FromTheCell(theCell, value);
        }

        [Test]
        public void Get_ReturnBlankNumericValue() {
            var theCell = "A21";
            var value = " 123 ";
            var expectedResult = "123";

            _sheet.Put(theCell, value);
            var cellValue = _sheet.Get(theCell);

            Assert.That(cellValue, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Put_UpdateTextOnExistingCell() {
            var theCell = "A21";
            var value = "A string";
            var anotherValue = "Another String";

            Verify_PutAndGet_FromTheCell(theCell, value);

            Verify_PutAndGet_FromTheCell(theCell, anotherValue);
        }

        [Test]
        public void Put_MultipleCells()
        {
            Verify_PutAndGet_FromTheCell("A1", "First");
            Verify_PutAndGet_FromTheCell("AB1", "Second");
        }

        [Test]
        public void Put_FormulaSpec()
        {
            var theCell = "B1";
            var value = " =7";

            _sheet.Put(theCell, " =7");

            Verify_PutAndGet_FromTheCell(theCell, value);
            Verify_PutAndGetLiteral_FromTheCell(theCell, value);

        }

        private void Verify_PutAndGet_FromTheCell(string cell, string value)
        {
            VerifyCellValue(cell, value, _sheet.Get);
        }

        private void Verify_PutAndGetLiteral_FromTheCell(string cell, string value) {
            VerifyCellValue(cell, value, _sheet.GetLiteral);
        }

        private void VerifyCellValue(string cell, string value, Func<string, string> getResult)
        {
            _sheet.Put(cell, value);
            var cellValue = getResult(cell);

            Assert.That(cellValue, Is.EqualTo(value));
        }
    }
}
