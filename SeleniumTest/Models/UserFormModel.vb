Imports System.ComponentModel.DataAnnotations


Public Class UserFormModel
    <Required(ErrorMessage:="Name is required")>
    Public Property Name As String
    Public Property Gender As String

    <RegularExpression("^True", ErrorMessage:="Please accept the terms and conditions")>
    Public Property TermsAndConditions As Boolean

End Class