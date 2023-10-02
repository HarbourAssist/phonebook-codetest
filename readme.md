# Project instructions #

Your task is to create a simple phone book application with CRUD operations. You must use Angular. For the back-end,please use C#, WebApi and Sql Server. Whilst Harbour Assist uses ServiceStack for REST, WebApi is more widespread so is what we have chosen here.

Your application should provide a form where you can enter in first name, last name, and phone number. You should then be able to perform 4 basic operations: create new entries in your database, read the entries,  update entries by editing any of the properties, and delete the entries.

There is a script that you need to run in SQL Management Studio that will create the db along with a couple of Phone  Book Entries. (phonebook-db.sql)

We have added the db context and the controller for you, along with the angular page, you may need to update the  connection string PhoneBookContext.cs file.

We would like to see examples of your unit tests in the PhoneBook.Tests project. These tests do no have to be related to the PhoneBook application but should demonstrate your understanding of unit tests and mocking. 