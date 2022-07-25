Imports Microsoft.AspNetCore.Mvc
Imports System.Diagnostics
Imports FrontEndData.Models
Imports Microsoft.Extensions.Logging

Namespace Controllers
    Public Class HomeController
        Inherits Controller

        Private ReadOnly _logger As ILogger(Of HomeController)

        Public Sub New(ByVal logger As ILogger(Of HomeController))
            _logger = logger
        End Sub

        Public Function Index() As IActionResult
            Return View()
        End Function

        Public Function Privacy() As IActionResult
            Return View()
        End Function

        <ResponseCache(Duration:=0, Location:=ResponseCacheLocation.None, NoStore:=True)>
        Public Function [Error]() As IActionResult
            Return View(New ErrorViewModel With {
                .RequestId = If(Activity.Current?.Id, HttpContext.TraceIdentifier)
            })
        End Function
    End Class
End Namespace

