﻿Imports System.ComponentModel.DataAnnotations


Public Class UserModel
    <Required(ErrorMessage:="Name is required")>
    Public Property Name As String
    Public Property Gender As String
    Public Property TermsAndConditions As Boolean

End Class
