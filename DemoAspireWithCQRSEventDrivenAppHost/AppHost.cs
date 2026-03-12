var builder = DistributedApplication.CreateBuilder(args);

var sqlPassword = builder.AddParameter("sql-password", "Password12345@");
var sqlServer = builder.AddSqlServer("sql-server", password: sqlPassword);
var database = sqlServer.AddDatabase("DemoAspireWithCQRS");


var api = builder.AddProject<Projects.OrderAPI>("order-api")
    .WithReference(database)
    .WaitFor(sqlServer);

builder.Build().Run();