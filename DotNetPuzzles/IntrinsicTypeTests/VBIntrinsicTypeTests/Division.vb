Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()>
Public Class Division

  '<ExpectedException(GetType(Exception), AllowDerivedTypes:=True)>
  <TestMethod()>
  Public Sub Division()
    Dim maxDiscountPercent As Integer = 30
    Dim markupPercent As Integer = 20
    Dim niceFactor As Integer = 30
    Dim discount As Integer = maxDiscountPercent * (markupPercent / niceFactor)
    'Assert.IsTrue(0 = discount)
    'Assert.IsTrue(10 = discount)
    'Assert.IsTrue(20 = discount)
    'Assert.IsTrue(30 = discount)
    Dim discount2 As Integer = maxDiscountPercent * (markupPercent \ niceFactor)
    'Assert.IsTrue(0 = discount2)
    'Assert.IsTrue(10 = discount2)
    'Assert.IsTrue(20 = discount2)
    'Assert.IsTrue(30 = discount2)
  End Sub

End Class