Public Class Form1
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Row As DataGridViewRow = Nothing
        Dim rowIndex As Integer 'index of the row
        Me.DataGridView1.Rows.Clear()

        For i As Integer = 0 To 10
            '/////Create a new row and get its index/////
            rowIndex = Me.DataGridView1.Rows.Add()

            '//////Get a reference to the new row ///////
            Row = Me.DataGridView1.Rows(rowIndex)

            With Row
                'This won't fail since the columns exist 
                .Cells("Column1").Value = "col1-" & rowIndex
                If i Mod 3 = 0 Then
                    .Cells("Column2").Value = "000"
                Else
                    .Cells("Column2").Value = "col2-" & (10 - rowIndex)
                End If

                If i Mod 4 = 0 Then
                    .Cells("Column3").Value = "111"
                Else
                    .Cells("Column3").Value = "col3-" & (10 * rowIndex)
                End If
                .Cells("Datetime").Value = Now.AddHours(rowIndex * 12.5)
            End With

            '//// I think this line is not required 
            ' Me.ServiceOrdersDataGridView.Rows.Add() 
        Next
        'DataGridView1.Rows.Add(row)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DataGridView1.Sort(DataGridView1.Columns("Column1"), System.ComponentModel.ListSortDirection.Ascending)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DataGridView1.Sort(DataGridView1.Columns("Column2"), System.ComponentModel.ListSortDirection.Ascending)
    End Sub



    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        DataGridView1.Sort(New RowComparer)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        DataGridView1.Sort(DataGridView1.Columns(3), System.ComponentModel.ListSortDirection.Ascending)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        DataGridView1.Sort(New RowComparer2)
    End Sub
End Class
Public Class RowComparer
    Implements IComparer
    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
        Dim DataGridViewRow1 As DataGridViewRow = CType(x, DataGridViewRow)
        Dim DataGridViewRow2 As DataGridViewRow = CType(y, DataGridViewRow)
        Dim CompareResult As Integer = System.String.Compare(DataGridViewRow1.Cells(1).Value.ToString(), DataGridViewRow2.Cells(1).Value.ToString())
        If CompareResult = 0 Then
            CompareResult = System.String.Compare(DataGridViewRow1.Cells(0).Value.ToString(), DataGridViewRow2.Cells(0).Value.ToString())
        End If
        Return CompareResult
    End Function
End Class
Public Class RowComparer2
    Implements IComparer
    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
        Dim DataGridViewRow1 As DataGridViewRow = CType(x, DataGridViewRow)
        Dim DataGridViewRow2 As DataGridViewRow = CType(y, DataGridViewRow)
        Dim CompareResult As Integer = System.String.Compare(DataGridViewRow1.Cells(1).Value.ToString(), DataGridViewRow2.Cells(1).Value.ToString())
        If CompareResult = 0 Then
            CompareResult = System.DateTime.Compare(DataGridViewRow1.Cells(3).Value, DataGridViewRow2.Cells(3).Value)
        End If
        Return CompareResult
    End Function
End Class