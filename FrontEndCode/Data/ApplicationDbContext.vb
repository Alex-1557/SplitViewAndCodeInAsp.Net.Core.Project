Imports Microsoft.AspNetCore.Identity.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore

Namespace Data
    Public Class ApplicationDbContext
        Inherits IdentityDbContext

        Public Sub New(options As DbContextOptions(Of ApplicationDbContext))
            MyBase.New(options)
        End Sub
    End Class
End Namespace
