DB Migration
1. The "dotnet" CLI Tool
	1. create project
	2. add package
	3. database migration
	4. build/test/run application
2. To run the Migration
	1. dotnet ef migrations add <MIGRATION-NAME> --c <DB COntext Class Path e.g. namespace.DbContext>
		Note: The DbCOntext path is needed if the current project have more than one 
		DbCOntext classes
		The commans will generate migration classes
	2. dotnet ef database update --c <DB COntext Class Path e.g. namespace.DbContext>
		Note: The DbCOntext path is needed if the current project have more than one 
		DbCOntext classes
		The Command will run migration to generate database and tables
3. Use HttpMethod attribute to map the request to specific Method in ApiController
	HttpGetAttribute()
	HttpPostAttribute()
	HttpPutAttribute()
	HttpDeleteAttribute()


#========================================================================================

Creating Custom Middleware
1. The class must be ctor injected using the 'RequestDelegate' object
2. The RequestDelegate accepts HttpContext as input Parameter
3. The Middleware class must have 'InvokeAsync()' as async method. This method will contans
	logic for Middlware
4. Create an extension class for Middleware, that have an extension method for 
	IApplicationBuilder.
		This method will have the following code
			IApplicationBuilder.UseMiddleware<T>();
			The 'T' is the Custom Middleware class















