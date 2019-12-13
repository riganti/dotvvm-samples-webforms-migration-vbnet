Imports System.Data.Entity

Public Class AppDbInitializer
    Inherits CreateDatabaseIfNotExists(of AppDbContext)

    Protected Overrides Sub Seed(context As AppDbContext)
        context.Customers.AddRange({
                new Customer() With 
                {
                    .FirstName = "Dani",
                    .LastName = "Michele"
                }, 
                new Customer() with
                {
                    .FirstName = "Elissa",
                    .LastName = "Malone"
                }, 
                new Customer() with
                {
                    .FirstName = "Raine",
                    .LastName = "Damian"
                },
                new Customer() with
                {
                    .FirstName = "Gerrard",
                    .LastName = "Petra"
                }, 
                new Customer() with
                {
                    .FirstName = "Clement",
                    .LastName = "Ernie"
                }, 
                new Customer() with
                {
                    .FirstName = "Rod",
                    .LastName = "Fred"
                },
                new Customer() with
                {
                    .FirstName = "Oliver",
                    .LastName = "Carr"
                }, 
                new Customer() with
                {
                    .FirstName = "Jackson",
                    .LastName = "James"
                }, 
                new Customer() with
                {
                    .FirstName = "Dexter",
                    .LastName = "Nicholson"
                },
                new Customer() with
                {
                    .FirstName = "Jamie",
                    .LastName = "Rees"
                }, 
                new Customer() with
                {
                    .FirstName = "Jackson",
                    .LastName = "Ross"
                }, 
                new Customer() with
                {
                    .FirstName = "Alonso",
                    .LastName = "Sims"
                },
                new Customer() with
                {
                    .FirstName = "Zander",
                    .LastName = "Britt"
                }, 
                new Customer() with
                {
                    .FirstName = "Isaias",
                    .LastName = "Ford"
                }, 
                new Customer() with
                {
                    .FirstName = "Braden",
                    .LastName = "Huffman"
                },
                new Customer() with
                {
                    .FirstName = "Frederick",
                    .LastName = "Simpson"
                },
                new Customer() with
                {
                    .FirstName = "Charlie",
                    .LastName = "Andrews"
                },
                new Customer() with
                {
                    .FirstName = "Reuben",
                    .LastName = "Byrne"
                }
            })

        MyBase.Seed(context)
    End Sub
End Class
